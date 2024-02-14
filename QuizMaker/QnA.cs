using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using QuizMaker;
namespace QuizMaker
{
    public class QnA
    {
        public static string GetUserQuestions()
        {
            Console.WriteLine("Type question: ");
            string userQuestion = Console.ReadLine();
            List<string> listOfQuestions = new List<string>();
            listOfQuestions.Add(userQuestion);
            return listOfQuestions.ToString();
        }
        public static string GetUserAnswers()
        {
            Console.WriteLine("Give answer: ");
            string userAnswer = Console.ReadLine();
            List<string> listOfAnswers = new List<string>();
            listOfAnswers.Add(userAnswer);
            return listOfAnswers.ToString();
        }
    }
}