using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot
{
    public static class BotCommands
    {       
        public const string
        Start = "/start",
        Help = "/help",
        HelpR = "помощь",
        NewTesting = "/newtest",
        NewTestingR = "новое тестирование!",
        ShowPredict = "/showpredict",
        ShowPredictR = "посмотреть предсказание",
        Info = "/infodisease",
        InfoR = "информация о заболеваниях",
        ContinueTest = "/continuetest",
        ContinueTestR = "продолжить тестирование!";
        public static Dictionary<string,string> GetCommands()
        {
            Dictionary<string, string> lst = new Dictionary<string, string>();
            lst.Add(Start, "Запуск бота");
            lst.Add(Help, "Вызвать список доступных комманд");
            lst.Add(NewTesting, "Начать новое тестирование");
            lst.Add(ShowPredict, "Показать предсказание болезней");
            lst.Add(Info, "Показать подробную информацию о болезнях");
            lst.Add(ContinueTest, "Продолжить начатое тестирование");
            return lst;
        }
    }
}
