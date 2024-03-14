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

            List<QuizzCard> listOfQuestions = new List<QuizzCard>();
            List<QuizzCard> listOfAnswers = new List<QuizzCard>();

            for (int numOfQuestions = 0; numOfQuestions <= 2; numOfQuestions++)
            {
                myCardWithQuestions.userQuestion = UIMethods.GetUserQuestion();
                listOfQuestions.Add(myCardWithQuestions);

                for (int numOfAnswers = 0; numOfAnswers <= 2; numOfAnswers++)
                {
                    myCardWithAnswers.userAnswer = UIMethods.SetUserAnswer();
                    listOfAnswers.Add(myCardWithAnswers);
                }
                //serialize it
                //then empty the list
            }            
        }      
    }    
}