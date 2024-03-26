using System;
using System.Collections.Generic;
using System.Text;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuizzCard card1 = new QuizzCard();

            card1.userQuestion = "Capital of France";

            Console.WriteLine($"Your question is: {card1}");

            //LogicMethods.GetUserQuestion();
        }        
    }        
}