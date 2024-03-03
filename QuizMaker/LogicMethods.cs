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
            List<string> storeAllAnswers = new List<string>();
            int maxQuestionsPerquizz = 4;
            int maxAnswersPerQuestion = 2;

            for (int answerCounter = 0; answerCounter <= maxAnswersPerQuestion; answerCounter++)
            {
                Console.WriteLine("Answer: ");
                string gameAnswer = Console.ReadLine();    
                storeAllAnswers.Add(gameAnswer);
            }
            return storeAllAnswers.ToString();            
        }
    }
}
