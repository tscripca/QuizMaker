using QuizMaker;
using System;
using System.Collections.Generic;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            QnACard myCard = new QnACard();
            List<QnACard> myListOfAnswers = new List<QnACard>();

            myCard.gameQuestion = UIMethods.GetQuestion();
            myCard.answersList = Logic.SetAnswer(myListOfAnswers);

            Console.WriteLine($"Your question is: {myCard.gameQuestion}");
        }
    }
}