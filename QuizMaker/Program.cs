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
            List<string> myListOfAnswers = new List<string>();           

            myCard.gameQuestion = UIMethods.GetQuestion();
            myListOfAnswers = Logic.SetAnswer();

            Console.WriteLine($"Your question is: {myCard.gameQuestion}");
            Console.WriteLine($"The list of answers: {myListOfAnswers}");
        }
    }
}