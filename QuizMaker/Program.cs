using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuizzCard questionsCard = new QuizzCard();
            QuizzCard answersCard1 = new QuizzCard();
            List<QuizzCard> answersList = new List<QuizzCard> ();


            questionsCard.GetQuestion();
            answersCard1.SetAnswer();
            answersList.Add (answersCard1);            

            Console.WriteLine($"Your question is: {questionsCard}");
            Console.WriteLine($"Your list of answers is: {answersList}");


        }
    }        
}