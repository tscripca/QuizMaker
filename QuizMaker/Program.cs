using System;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuizzCard questionsCard = new QuizzCard();
            QuizzCard answersCard1 = new QuizzCard();
            List<QuizzCard> listWithAnswers = new List<QuizzCard> ();

            questionsCard.GetQuestion();
            answersCard1.SetAnswer();
            listWithAnswers.Add(answersCard1);            

            Console.WriteLine($"Your question is: {questionsCard}");
            Console.WriteLine($"Your list of answers is: {listWithAnswers}");

        }
    }        
}