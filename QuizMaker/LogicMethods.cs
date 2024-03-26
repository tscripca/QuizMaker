using System;
using System.Collections.Generic;
using System.Text;
using QuizMaker;

namespace QuizMaker
{    public class LogicMethods
    {
        public string GetUserQuestion()
        {
            Console.WriteLine("Type question: ");
            string myQuestion = Console.ReadLine();

            return myQuestion;
        }

        public string SetUserAnswer()
        {
            Console.WriteLine("Answer: ");
            string userAnswer = Console.ReadLine();

            return userAnswer;
        }
    }
}
