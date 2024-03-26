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
            QuizzCard answersCard2 = new QuizzCard();
            QuizzCard answersCard3 = new QuizzCard();

            questionsCard.userQuestion = "Capital of France";
            answersCard1.userAnswer = "Paris";
            questionsCard.answersList.Add(answersCard1);
            answersCard2.userAnswer = "Rome";
            questionsCard.answersList.Add(answersCard2);
            answersCard3.userAnswer = "Madrid";
            questionsCard.answersList.Add(answersCard3);

            Console.WriteLine($"Your question is: {questionsCard}");
            Console.WriteLine($"Your list of answers is: {answersCard1}, {answersCard2}, {answersCard3}");

            LogicMethods.GetUserQuestion();

        }
    }        
}