using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuizzCard myCardWithQuestions = new QuizzCard();
            QuizzCard myCardWithAnswers = new QuizzCard();

            myCardWithQuestions.userQuestion = UIMethods.GetUserQuestion();
            myCardWithAnswers.userAnswer = UIMethods.SetUserAnswer();

        }      
    }    
}