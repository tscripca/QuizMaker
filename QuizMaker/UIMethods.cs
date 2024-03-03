using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaker;

namespace QuizMaker
{
    public class UIMethods
    {
        public static string GetQuestion()
        {
            Console.WriteLine("Type question: ");
            string gameQuestion = Console.ReadLine();
            return gameQuestion;
        }
    }
}
