using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using QuizMaker;
namespace QuizMaker
{
    public class LogicMethods
    {
        public static string GetUserQuestion()
        {            
            Console.WriteLine("Type question: ");
            string userQuestion = Console.ReadLine();

            return userQuestion;
        }
        public static string SetUserAnswer()
        {
            Console.WriteLine("Answer: ");
            string userAnswer = Console.ReadLine();

            return userAnswer;
        }
        /// <summary>
        /// This method should loop the user input and add it into a List of type QuizzCard
        /// </summary>
        /// <returns>Should return a QuizzCard type List</returns>
        public static QuizzCard LoopQnA()
        {
            QuizzCard quizzCard = new QuizzCard();
            List<QuizzCard> testList = new List<QuizzCard>();

            for (int questionLoop = 0; questionLoop <= Constants.MAX_NUMBER_OF_QNA; questionLoop++)
            {
                quizzCard.userQuestion = GetUserQuestion();
                testList.Add(quizzCard);
                
                for (int answerLoop = 0; answerLoop <= Constants.MAX_NUMBER_OF_QNA; answerLoop++)
                {
                    quizzCard.userAnswers = SetUserAnswer();
                    testList.Add(quizzCard);
                }
                UIMethods.ClearScreen();
            }

            return quizzCard;
        }
    }

   
}
