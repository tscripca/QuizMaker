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

            QuizzCard quizzQuestion = new QuizzCard();
            QuizzCard quizzAnswer = new QuizzCard();

            quizzQuestion.UserQuestion = UIMethods.GetQuestion().ToString();
            quizzAnswer.UserAnswer = LogicMethods.SetAnswer().ToString();            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    
}