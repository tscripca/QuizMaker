using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class UIMethods
    {
        public static string GetUserQuestion()
        {
            Console.WriteLine("Type question: ");
            string userQuestion = Console.ReadLine();

            return userQuestion;
        }
        public static string SetUserAnswer()
        {           
            Console.WriteLine("Answer: ");
            string userAnswer = Console.ReadLine();

            return userAnswer;
        }
    }
}
