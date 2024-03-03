using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaker;

namespace QuizMaker
{
    public class LogicMethods
    {        
        public static string SetAnswer()
        {
            string gameAnswer = "";
            int maxQuestions = 2;

            for (int i = 0; i <= maxQuestions; i++)
            {
                Console.WriteLine("Answer: ");
                gameAnswer = Console.ReadLine();                
            }
            return gameAnswer;            
        }
    }
}
