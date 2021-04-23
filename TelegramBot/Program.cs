using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using Telegram.Bot;
using System.Collections.Generic;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using ApiForMedicalSystem.Models;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using ApiForMedicalSystem.ExpertSystem;

namespace TelegramBot
{
    class Program
    {
        static ITelegramBotClient botClient;
        static string serverPath = "https://localhost:44358";
        static long userId;
        static Test testNow;
        static Symptom questionNow;
        static AnswerUser answerNow;
        static bool questionEnded = false;
        static string question = "";
        static Dictionary<Disease, List<Symptom>> diseasesPredict = new Dictionary<Disease, List<Symptom>>();
        static ComparePriorProbability compare = new ComparePriorProbability();
        static void Main(string[] args)
        {
           
            string token = "1522965398:AAEep9oYU-cWCPE_-C1v05w-jgl8sbsAEL4";
            botClient = new TelegramBotClient(token);       
            
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
            botClient.OnMessage += Bot_OnMessage;
            botClient.OnCallbackQuery += Bot_OnCallbackQuery;
            botClient.StartReceiving();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }
        
        static InlineKeyboardMarkup keyboardTest = new InlineKeyboardMarkup(new InlineKeyboardButton[][]
        {
            new InlineKeyboardButton[]
            {
                InlineKeyboardButton.WithCallbackData("Да","yes"),
                InlineKeyboardButton.WithCallbackData("Не знаю", "nothing_callback"),
                InlineKeyboardButton.WithCallbackData("Нет", "no_callback" ),
            },
        });
        static InlineKeyboardMarkup GenerateButtonsList(Dictionary<Disease, List<Symptom>> dict)
        {
            var ikbList = new List<InlineKeyboardButton[]>();
            var index = 0;
            List<InlineKeyboardButton> ikb = new List<InlineKeyboardButton>();
            foreach (var disease in dict.Keys)
            {               

                if (index % 2 == 0 && index != 0 && index != dict.Keys.Count)
                {
                    ikbList.Add(ikb.ToArray());
                    ikb.Clear();
                }
                ikb.Add(new InlineKeyboardButton() { Text = disease.Name, Url = disease.Link});
                if (index == dict.Keys.Count-1)
                {
                    ikbList.Add(ikb.ToArray());
                }
                index++;
            }
            return new InlineKeyboardMarkup(ikbList.ToArray());
        }   

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {          
            string text = e.Message.Text;
            
            long chatId = e.Message.Chat.Id;
            userId = chatId;
            var keyboardMenu = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                    new[]
                    {
                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Новое тестирование!"),
                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Продолжить тестирование!"),
                    },
                    new[]
                    {
                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Посмотреть предсказание"),
                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Информация о заболеваниях"),
                    },
                    new[]
                    {
                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Помощь"),
                    }
                },
                ResizeKeyboard = true
            };
            switch(text.ToLower())
            {
                case BotCommands.Start:
                    await botClient.SendTextMessageAsync(chatId,
                        "Приветик " + e.Message.Chat.FirstName + " " + 
                        e.Message.Chat.LastName + "!!!",
                        replyMarkup: keyboardMenu);
                    List<ApiForMedicalSystem.Models.User> users;
                    using (WebClient wc = new WebClient())
                    {
                        Uri url = new Uri(serverPath + "/api/Users");                      
                        var json = wc.DownloadString(url);
                        users = JsonConvert.DeserializeObject<List<ApiForMedicalSystem.Models.User>>(json);                       
                    }
                    foreach (var user in users)
                    {
                        if(userId != user.Id)
                        {
                            postUserRequest(userId);
                        }
                    }                   
                    break;
                case BotCommands.Help:
                case BotCommands.HelpR:
                    string output = "Список доступных комманд:";
                    foreach (var item in BotCommands.GetCommands())
                    {
                        output += "\n" + item.Key + " -- " + item.Value;
                    }
                    await botClient.SendTextMessageAsync(chatId, output);
                    break;
                case BotCommands.NewTesting:
                case BotCommands.NewTestingR:
                    questionEnded = false;
                    if (testNow == null)
                    {
                        testNow = postTestRequest(1).Result;
                    }
                    testNow = postTestRequest(userId).Result;                   
                    await botClient.SendTextMessageAsync(chatId, "Ну что ж, начнем обследование...");
                    Thread.Sleep(1000);
                    question = getQuestion();
                    await botClient.SendTextMessageAsync(chatId, question, ParseMode.Default,false, false, 0, keyboardTest);
                    break;
                case BotCommands.ContinueTest:
                case BotCommands.ContinueTestR:
                    if (testNow == null)
                    {
                        testNow = postTestRequest(1).Result;
                    }
                    await botClient.SendTextMessageAsync(chatId, "Хорошо, давайте продолжим тестирование!");
                    Thread.Sleep(1000);
                    await botClient.SendTextMessageAsync(chatId, question, ParseMode.Default, false, false, 0, keyboardTest);
                    break;
                case BotCommands.ShowPredict:
                case BotCommands.ShowPredictR:
                    if (testNow == null)
                    {
                        testNow = postTestRequest(1).Result;
                    }
                    diseasesPredict = getPredict();
                    if (diseasesPredict.Count != 0)
                    {
                        string str = "Упс...Вероятно вы болеете чем-то из нижеперечисленного :\n";
                        str += "----------------------\n";
                        foreach (var predict in diseasesPredict.Keys)
                        {                            
                            str += predict.Name + " : " + predict.PriorProbability + "%\n";
                        }
                        str += "----------------------\n";
                        str += "Можете ознакомиться с этими заболеваниями подробнее,\nпо ссылкам ниже :";
                        InlineKeyboardMarkup keyboardLinks = GenerateButtonsList(diseasesPredict);
                        await botClient.SendTextMessageAsync(chatId, str, ParseMode.Default, false, false, 0, keyboardLinks);
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId, "Здоровски.Вероятность, что вы чем-то болеете, крайне мала:)");
                    }                   
                    break;
                case BotCommands.Info:
                case BotCommands.InfoR:
                    if (testNow == null)
                    {
                        testNow = postTestRequest(1).Result;
                    }
                    diseasesPredict = getPredict();
                    if (diseasesPredict.Count != 0)
                    {
                        string str = "";
                        foreach (var disease in diseasesPredict.Keys)
                        {
                            var s = "";
                            for (int i = 0; i <= disease.Name.Length; i++)
                            {
                                s += "\u203E";
                            }
                            str += disease.Name+ "\n" + s + "\n" + disease.Info + "\nСимптомы :\n";
                            s = "";
                            foreach (var symptom in diseasesPredict[disease])
                            {
                                str += "------ " +  symptom.Caption + "\n";
                            }
                            str += "\n";
                        }
                        await botClient.SendTextMessageAsync(chatId, str);
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId, "С вами все хорошо. Не забивайте голову лишней информацией:)");
                    }
                    break;
                default:                    
                    await botClient.SendTextMessageAsync(chatId, "Такой команды нет! " +
                        "Нажмите /help, для просмотра всех комманд");
                    break;
            }            
        }
        static async void Bot_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            var message = e.CallbackQuery;
            if (e.CallbackQuery.Data == "yes")
            {    
                if (!questionEnded)
                {
                    postAnswerYesRequest();
                }                
                question = getQuestion();
                if (question == null)
                {
                    questionEnded = true;
                    question = "Вопросы закончились.\n" +
                       "Начните новое тестирование /newtest\n" +
                       "Или посмотрите результат /showpredict";
                    await botClient.AnswerCallbackQueryAsync(message.Id, "");
                    await botClient.SendTextMessageAsync(message.Message.Chat.Id, question);
                }
                else
                {
                    await botClient.AnswerCallbackQueryAsync(message.Id);
                    await botClient.SendTextMessageAsync(message.Message.Chat.Id, question, ParseMode.Default, false, false, 0, keyboardTest);                    
                }             
            }
            else if (e.CallbackQuery.Data == "nothing_callback")
            {
                if (!questionEnded)
                {
                    postAnswerNothingRequest();
                }
                question = getQuestion();
                if (question == null)
                {
                    questionEnded = true;
                    question = "Вопросы закончились.\n" +
                       "Начните новое тестирование /newtest\n" +
                       "Или посмотрите результат /showpredict";
                    await botClient.AnswerCallbackQueryAsync(message.Id, "");
                    await botClient.SendTextMessageAsync(message.Message.Chat.Id, question);
                }
                else
                {
                    await botClient.AnswerCallbackQueryAsync(message.Id);
                    await botClient.SendTextMessageAsync(message.Message.Chat.Id, question, ParseMode.Default, false, false, 0, keyboardTest);
                }
            }
            else if (e.CallbackQuery.Data == "no_callback")
            {
                if (!questionEnded)
                {
                    postAnswerNoRequest();
                }
                question = getQuestion();
                if (question == null)
                {
                    questionEnded = true;
                    question = "Вопросы закончились.\n" +
                        "Начните новое тестирование /newtest\n" +
                        "Или посмотрите результат /showpredict";
                    await botClient.AnswerCallbackQueryAsync(message.Id, "");
                    await botClient.SendTextMessageAsync(message.Message.Chat.Id, question);
                }
                else
                {
                    await botClient.AnswerCallbackQueryAsync(message.Id);
                    await botClient.SendTextMessageAsync(message.Message.Chat.Id, question, ParseMode.Default, false, false, 0, keyboardTest);
                }
            }
        }

        private static void postAnswerYesRequest()
        {
            var answer = addAnswerRequest(true);
            answerNow = answer;
            var diseases = getDiseases();
            foreach (var disease in diseases)
            {
                Uri url = new Uri(serverPath + "/api/Results");
                Result res = new Result();
                res.DiseaseId = disease.Id;
                res.AnswerUserId = answer.Id;
                res.PriorProbability = getPriorYes(answer.TestId, answer.Id, disease.Id);
                var json = JsonConvert.SerializeObject(res);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using var client = new HttpClient();
                var response = client.PostAsync(url, data);
                string result = response.Result.Content.ReadAsStringAsync().Result;
                var answerNow = JsonConvert.DeserializeObject<AnswerUser>(result);
            }            
        }
        private static double getPriorYes(long idTest, int answerId, int diseaseId)
        {
            double res = 0.0;
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(serverPath + "/api/ExpertSystem/CallbackYes/" + idTest + "/" + answerId + "/" + diseaseId);
                var json = wc.DownloadString(url);
                res = JsonConvert.DeserializeObject<double>(json);
            }
            return res;
        }

        private static void postAnswerNoRequest()
        {
            var answer = addAnswerRequest(false);
            answerNow = answer;
            var diseases = getDiseases();
            foreach (var disease in diseases)
            {
                Uri url = new Uri(serverPath + "/api/Results");
                Result res = new Result();
                res.DiseaseId = disease.Id;
                res.AnswerUserId = answer.Id;
                res.PriorProbability = getPriorNo(answer.TestId, answer.Id, disease.Id);
                var json = JsonConvert.SerializeObject(res);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using var client = new HttpClient();
                var response = client.PostAsync(url, data);
                string result = response.Result.Content.ReadAsStringAsync().Result;
                var answerNow = JsonConvert.DeserializeObject<AnswerUser>(result);
            }
        }
        private static double getPriorNo(long idTest, int answerId, int diseaseId)
        {
            double res = 0.0;
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(serverPath + "/api/ExpertSystem/CallbackNo/" + idTest + "/" + answerId + "/" + diseaseId);
                var json = wc.DownloadString(url);
                res = JsonConvert.DeserializeObject<double>(json);
            }
            return res;
        }
        private static void postAnswerNothingRequest()
        {
            var answer = addAnswerRequest();
            answerNow = answer;
            var diseases = getDiseases();
            foreach (var disease in diseases)
            {
                Uri url = new Uri(serverPath + "/api/Results");
                Result res = new Result();
                res.DiseaseId = disease.Id;
                res.AnswerUserId = answer.Id;
                res.PriorProbability = getPriorNothing(answer.TestId, answer.Id, disease.Id);
                var json = JsonConvert.SerializeObject(res);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using var client = new HttpClient();
                var response = client.PostAsync(url, data);
                string result = response.Result.Content.ReadAsStringAsync().Result;
                var answerNow = JsonConvert.DeserializeObject<AnswerUser>(result);
            }
        }
        private static double getPriorNothing(long idTest, int answerId, int diseaseId)
        {
            double res = 0.0;
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(serverPath + "/api/ExpertSystem/CallbackNothing/" + idTest + "/" + answerId + "/" + diseaseId);
                var json = wc.DownloadString(url);
                res = JsonConvert.DeserializeObject<double>(json);
            }
            return res;
        }
        private static AnswerUser addAnswerRequest(bool answer)
        {
            Uri url = new Uri(serverPath + "/api/AnswerUsers");
            var answerUser = new AnswerUser();
            answerUser.TestId = testNow.Id;
            answerUser.SymptomId = questionNow.Id;
            answerUser.Answer = answer;
            var json = JsonConvert.SerializeObject(answerUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(url, data);            
            string result = response.Result.Content.ReadAsStringAsync().Result;
            var answerNow = JsonConvert.DeserializeObject<AnswerUser>(result);           
            return answerNow;
        }
        private static AnswerUser addAnswerRequest()
        {
            Uri url = new Uri(serverPath + "/api/AnswerUsers");
            var answerUser = new AnswerUser();
            answerUser.TestId = testNow.Id;
            answerUser.SymptomId = questionNow.Id;
            var json = JsonConvert.SerializeObject(answerUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(url, data);
            string result = response.Result.Content.ReadAsStringAsync().Result;
            var answerNow = JsonConvert.DeserializeObject<AnswerUser>(result);
            return answerNow;
        }
        private static List<Disease> getDiseases()
        {
            List<Disease> diseases = new List<Disease>();
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(serverPath + "/api/Diseases");
                var json = wc.DownloadString(url);
                diseases = JsonConvert.DeserializeObject<List<Disease>>(json);
            }
            return diseases;
        }
        private static async Task<Test> postTestRequest(long idUser)
        {
            Uri url = new Uri(serverPath + "/api/Tests");
            var test = new Test();
            test.UserId = idUser;
            var json = JsonConvert.SerializeObject(test);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            var testNow = JsonConvert.DeserializeObject<Test>(result);
            return testNow;
        }
        private static async void postUserRequest(long id)
        {
            Uri url = new Uri(serverPath + "/api/Users");
            var user = new ApiForMedicalSystem.Models.User();
            user.Id = id;
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
        }
        private static string getQuestion()
        {
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(serverPath + "/api/ExpertSystem/GetQuestion/" + testNow.Id);
                var json = wc.DownloadString(url);
              
                questionNow = JsonConvert.DeserializeObject<Symptom>(json);
            }
            if (questionNow == null)
            {
                return null;
            }
            var question = questionNow.Caption + "?";
            return question;
        }
        private static Dictionary<Disease, List<Symptom>> getPredict()
        {
            int index = 0;
            Dictionary<Disease, List<Symptom>> output = new Dictionary<Disease, List<Symptom>>();
            List<Result> results;
            List<Disease> diseases;
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(serverPath + "/api/AnswerUsers/IndexAnswer/" + testNow.Id);
                var json = wc.DownloadString(url);
                index = JsonConvert.DeserializeObject<int>(json);
            }
            if (index != 0)
            {
                results = new List<Result>();
                using (WebClient wc = new WebClient())
                {
                    Uri url = new Uri(serverPath + "/api/Results/ResultPredict/" + answerNow.Id);
                    var json = wc.DownloadString(url);
                    results = JsonConvert.DeserializeObject<List<Result>>(json);
                }
                diseases = new List<Disease>();
                using (WebClient wc = new WebClient())
                {
                    Uri url = new Uri(serverPath + "/api/Diseases");
                    var json = wc.DownloadString(url);
                    diseases = JsonConvert.DeserializeObject<List<Disease>>(json);
                }
                foreach (var disease in diseases)
                {
                    foreach (var result in results)
                    {
                        if (result.DiseaseId == disease.Id)
                        {
                            disease.PriorProbability = result.PriorProbability;
                        }
                    }
                }
            }
            else
            {
                diseases = new List<Disease>();
                using (WebClient wc = new WebClient())
                {
                    Uri url = new Uri(serverPath + "/api/Diseases");
                    var json = wc.DownloadString(url);
                    diseases = JsonConvert.DeserializeObject<List<Disease>>(json);
                }
            }
            List<Coefficient> coeffs = new List<Coefficient>();
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(serverPath + "/api/Coefficients");
                var json = wc.DownloadString(url);
                coeffs = JsonConvert.DeserializeObject<List<Coefficient>>(json);
            }
            List<Symptom> symptoms = new List<Symptom>();
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(serverPath + "/api/Symptoms");
                var json = wc.DownloadString(url);
                symptoms = JsonConvert.DeserializeObject<List<Symptom>>(json);
            }
            diseases.Sort(compare);
            List<Disease> r = new List<Disease>();
            foreach (var disease in diseases)
            {
                if (disease.PriorProbability > 0.01)
                {
                    disease.PriorProbability = Math.Round(disease.PriorProbability * 100, 2);
                    r.Add(disease);                    
                }
            }
            foreach (var disease in r)
            {
                List<Symptom> s = new List<Symptom>();
                foreach (var coeff in coeffs)
                {
                    if (disease.Id == coeff.DiseaseId)
                    {                       
                        foreach (var symptom in symptoms)
                        {
                            if (symptom.Id == coeff.SymptomId)
                            {
                                s.Add(symptom);
                            }
                        }
                       
                    }                                     
                }
                output.Add(disease, s);
            }
            return output;
        }
    }
}
