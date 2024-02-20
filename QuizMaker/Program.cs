using System;
using System.Text;
using System.Runtime.ConstrainedExecution;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type question: ");
            string myQuestion = Console.ReadLine();
            Console.WriteLine("How many options would you like to give? ");
            int howManyAnswers = Convert.ToInt32(Console.ReadLine());

            for (int countAnswers = 0; countAnswers < howManyAnswers; countAnswers++)
            {
                Console.WriteLine("Type answer: ");
                string myAnswer = Console.ReadLine();
            }

            Console.WriteLine("Which one is the correct answer?");
            string setCorrectAnswer = Console.ReadLine();
        }
    }
}