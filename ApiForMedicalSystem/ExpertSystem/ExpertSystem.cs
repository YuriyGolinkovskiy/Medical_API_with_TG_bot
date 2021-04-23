using ApiForMedicalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.ExpertSystem
{
    public class ExpertSystem
    {
        public Dictionary<int, double> RuleValue { get; set; } = new Dictionary<int, double>();
        //public ObservableCollection<DiseaseToPrint> DiseaseToPrint { get; private set; } = new ObservableCollection<DiseaseToPrint>();
        private int indexQuestion;
        ComparePriorProbability compareDiseases = new ComparePriorProbability();
        ComparePriorProbabilityResult compareResults = new ComparePriorProbabilityResult();
        //Disease disease;
        //public List<Symptom> Symptoms { get; private set; } = new List<Symptom>();
        //public List<Coefficient> Coefficient { get; private set; } = new List<Coefficient>();
        //public List<Result> Result { get; private set; } = new List<Result>();
        //public List<Test> Test { get; private set; } = new List<Test>();
        //public List<AnswerUser> AnswerUser { get; private set; } = new List<AnswerUser>();
        private DatabaseContext dbContext { get; set; }
        public ExpertSystem(DatabaseContext db)
        {
            dbContext = db;
            //dbContext.DiseaseItem.ToList().Sort(compare);
        }
        public void CountDiseases() 
        {
            ////DiseaseToPrint.Clear();
            //var disease = dbContext.DiseaseItem.ToList();
            //disease.Sort(compare);
            //var index = 0;
            //foreach (var d in disease)
            //{
            //    if (d.PriorProbability >= 0.01)
            //    {
            //        //Result.Add(new Result());
            //        //Result[index].Name = disease.Name;
            //        //Result[index].PriorProbability = Math.Round(disease.PriorProbability * 100, 2);
            //        //index++;
            //    }
            //}

        }
        private double countThePriorProbability(Disease disease, Symptom symptom)
        {
            double res = disease.PriorProbability;
            var coeffs = dbContext.CoefficientItem.ToList();
            foreach (var item in coeffs)
            {               
                if (item.DiseaseId == disease.Id && item.SymptomId == symptom.Id)
                {
                    var numerator = item.ExodusIsTrue * disease.PriorProbability;
                    var denominator = numerator + (item.ExodusIsFalse * (1 - disease.PriorProbability));
                    res = numerator / denominator;
                }
            }
            return res;
        }
        private double countThePriorProbability(Result disease, Symptom symptom)
        {
            double res = disease.PriorProbability;
            var coeffs = dbContext.CoefficientItem.ToList();
            foreach (var item in coeffs)
            {              
                if (item.DiseaseId == disease.DiseaseId && item.SymptomId == symptom.Id)
                {
                    var numerator = item.ExodusIsTrue * disease.PriorProbability;
                    var denominator = numerator + (item.ExodusIsFalse * (1 - disease.PriorProbability));
                    res = numerator / denominator;
                }
            }
            return res;
        }
        private double countThePriorProbabilityNothing(Disease disease, Symptom symptom)
        {
            double res = disease.PriorProbability;
            var coeffs = dbContext.CoefficientItem.ToList();
            foreach (var item in coeffs)
            {
                if (item.DiseaseId == disease.Id && item.SymptomId == symptom.Id)
                {
                    res = disease.PriorProbability;
                }
            }
            return res;
        }
        private double countThePriorProbabilityNothing(Result disease, Symptom symptom)
        {
            double res = disease.PriorProbability;
            var coeffs = dbContext.CoefficientItem.ToList();
            foreach (var item in coeffs)
            {
                if (item.DiseaseId == disease.DiseaseId && item.SymptomId == symptom.Id)
                {
                    res = disease.PriorProbability;
                }
            }
            return res;
        }
        private double countThePriorProbabilityFalse(Disease disease, Symptom symptom)
        {
            double res = disease.PriorProbability;
            var coeffs = dbContext.CoefficientItem.ToList();
            foreach (var item in coeffs)
            {
                if (item.DiseaseId == disease.Id && item.SymptomId == symptom.Id)
                {
                    var numerator = (1 - item.ExodusIsTrue) * disease.PriorProbability;
                    var denominator = numerator + ((1 - item.ExodusIsFalse) * (1 - disease.PriorProbability));                   
                    res = numerator / denominator;
                }
            }
            return res;
        }
        private double countThePriorProbabilityFalse(Result disease, Symptom symptom)
        {
            double res = disease.PriorProbability;
            var coeffs = dbContext.CoefficientItem.ToList();
            foreach (var item in coeffs)
            {
                if (item.DiseaseId == disease.DiseaseId && item.SymptomId == symptom.Id)
                {
                    var numerator = (1 - item.ExodusIsTrue) * disease.PriorProbability;
                    var denominator = numerator + ((1 - item.ExodusIsFalse) * (1 - disease.PriorProbability));
                    res = numerator / denominator;
                }
            }
            return res;
        }

        public void countTheRules(int idTest)
        {
            var answers = dbContext.AnswerUserItem.Where(a => a.TestId == idTest).ToList();           

            if (answers.Count == 0)
            {
                foreach (var coeff in dbContext.CoefficientItem.ToList())
                {
                    var disease = dbContext.DiseaseItem.Find(coeff.DiseaseId);
                    var symptom = dbContext.SymptomItem.Find(coeff.SymptomId);
                    double prior = countThePriorProbability(disease, symptom);
                    if (RuleValue.ContainsKey(symptom.Id))
                    {
                        RuleValue[symptom.Id] += Math.Abs(prior - (1 - prior));
                    }
                    else
                    {
                        RuleValue.Add(symptom.Id, prior);
                    }
                }
            }
            else
            {
                var usedAnswer = answers.Select(c => c.SymptomId).ToList();
                List<Coefficient> coeffs = new List<Coefficient>();
                foreach (var coeff in dbContext.CoefficientItem.ToList())
                {
                    if (!usedAnswer.Contains(coeff.SymptomId))
                    {
                        coeffs.Add(coeff);
                    }
                }
                var answer = answers.Last();
                var results = dbContext.ResultItem.Where(r => r.AnswerUserId == answer.Id);
                foreach (var coeff in coeffs)
                {
                    var disease = results.Where(r => r.DiseaseId == coeff.DiseaseId).First();                   
                    var symptom = dbContext.SymptomItem.Find(coeff.SymptomId);
                    double prior = countThePriorProbability(disease, symptom);
                    if (RuleValue.ContainsKey(symptom.Id))
                    {
                        RuleValue[symptom.Id] += Math.Abs(prior - (1 - prior));
                    }
                    else
                    {
                        RuleValue.Add(symptom.Id, prior);
                    }
                }
            }
            RuleValue = RuleValue.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        
        public double hypothesisIsTrue(int idTest ,int answerId, int diseaseId)
        {
            double prior = 0.0;
            var answers = dbContext.AnswerUserItem.Where(a => a.TestId == idTest).ToList();
            var answer = dbContext.AnswerUserItem.Find(answerId);
            if (answers.Count == 1)
            {
                var disease = dbContext.DiseaseItem.Find(diseaseId);
                var symptom = dbContext.SymptomItem.Find(answer.SymptomId);
                prior = countThePriorProbability(disease, symptom);
            }
            else
            {
                answer = dbContext.AnswerUserItem.Find(answerId);
                var results = dbContext.ResultItem.Where(r => r.AnswerUserId == answer.Id-1);
                var disease = results.Where(r => r.DiseaseId == diseaseId).First();
                var symptom = dbContext.SymptomItem.Find(answer.SymptomId);
                prior = countThePriorProbability(disease, symptom);
            }
            return prior;
        }
        public double hypothesisIsFalse(int idTest, int answerId, int diseaseId)
        {
            double prior = 0.0;
            var answers = dbContext.AnswerUserItem.Where(a => a.TestId == idTest).ToList();
            var answer = dbContext.AnswerUserItem.Find(answerId);
            if (answers.Count == 1)
            {
                var disease = dbContext.DiseaseItem.Find(diseaseId);
                var symptom = dbContext.SymptomItem.Find(answer.SymptomId);
                prior = countThePriorProbabilityFalse(disease, symptom);
            }
            else
            {
                answer = dbContext.AnswerUserItem.Find(answerId);
                var results = dbContext.ResultItem.Where(r => r.AnswerUserId == answer.Id - 1);
                var disease = results.Where(r => r.DiseaseId == diseaseId).First();
                var symptom = dbContext.SymptomItem.Find(answer.SymptomId);
                prior = countThePriorProbabilityFalse(disease, symptom);
            }
            return prior;
        }
        public double hypothesisIsNothing(int idTest, int answerId, int diseaseId)
        {
            double prior = 0.0;
            var answers = dbContext.AnswerUserItem.Where(a => a.TestId == idTest).ToList();
            var answer = dbContext.AnswerUserItem.Find(answerId);
            if (answers.Count == 1)
            {
                var disease = dbContext.DiseaseItem.Find(diseaseId);
                var symptom = dbContext.SymptomItem.Find(answer.SymptomId);
                prior = countThePriorProbabilityNothing(disease, symptom);
            }
            else
            {
                answer = dbContext.AnswerUserItem.Find(answerId);
                var results = dbContext.ResultItem.Where(r => r.AnswerUserId == answer.Id - 1);
                var disease = results.Where(r => r.DiseaseId == diseaseId).First();
                var symptom = dbContext.SymptomItem.Find(answer.SymptomId);
                prior = countThePriorProbabilityNothing(disease, symptom);
            }
            return prior;
        }
       
        public Symptom takeQuestion(int idTest)
        {
            var answers = dbContext.AnswerUserItem.Where(a => a.TestId == idTest).ToList();
            if (answers.Count >= dbContext.SymptomItem.ToList().Count-1)
            {
                return null;
            }
            RuleValue.Clear();
            countTheRules(idTest);
            indexQuestion = RuleValue.First().Key;
            var symptom = dbContext.SymptomItem.Find(indexQuestion);
            return symptom;
        }
    }
}
