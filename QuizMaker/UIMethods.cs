using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class UIMethods
    {
        public static int AskHowManyquestions()
        {
            Console.WriteLine("How many questions in total?: ");
            int maxQuestionsPerquizz = Convert.ToInt32(Console.ReadLine()) - Constants.BYPASS_INDEXING;
            return maxQuestionsPerquizz;
        }
        public static int AskHowManyAnswers()
        {
            Console.WriteLine("How many possible answers per question?: ");
            int maxAnswersPerQuestion = Convert.ToInt32(Console.ReadLine()) - Constants.BYPASS_INDEXING;
            return maxAnswersPerQuestion;
        }
        public static string SetQuestion()
        {
            Console.WriteLine("Type Question: ");
            string gameQuestion = Console.ReadLine();

            return gameQuestion;
        }
        public static string SetAnswer()
        {
            Console.WriteLine("Type Answer: ");
            string gameAnswer = Console.ReadLine();

            return gameAnswer;
        }
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static int DisplayQuestionsCounter(int questionCounter)
        {
            Console.WriteLine($"Question number: {questionCounter + Constants.BYPASS_INDEXING}");
            return questionCounter;
        }
    }
}
