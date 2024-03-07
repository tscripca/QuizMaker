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
        public static string SetNumberOfQnA()
        {
            List<string> storeAllQnAs = new List<string>();
            Console.WriteLine("How many questions in total?: ");
            int maxQuestionsPerquizz = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("How many possible answers per question?: ");
            int maxAnswersPerQuestion = Convert.ToInt32(Console.ReadLine()) - 1;

            for (int i = 0; i <= maxQuestionsPerquizz; i++)
            {
                Console.WriteLine("Question: ");
                string gameQuestion = Console.ReadLine();
                storeAllQnAs.Add(gameQuestion);

                for (int answerCounter = 0; answerCounter <= maxAnswersPerQuestion; answerCounter++)
                {
                    Console.WriteLine("Answer: ");
                    string gameAnswer = Console.ReadLine();
                    storeAllQnAs.Add(gameAnswer);
                }
            }            
            return storeAllQnAs.ToString();            
        }

        public override string ToString()
        {
            return $"{LogicMethods.SetNumberOfQnA()}";
        }
    }
}
