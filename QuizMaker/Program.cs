using System;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
           QnA.GetUserQuestions();
            ExportToXML.StoreQuestions();
           QnA.GetUserAnswers();
            ExportToXML.StoreAnswers();

           
        }
    }
}