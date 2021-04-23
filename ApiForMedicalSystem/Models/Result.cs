using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int DiseaseId { get; set; }
        public int AnswerUserId { get; set; }
        public double PriorProbability { get; set; }
    }
}
