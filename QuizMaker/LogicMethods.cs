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
        public static string LoopQnA()
        {
            QuizzCard quizzCard = new QuizzCard();

            List<QuizzCard> questionList = new List<QuizzCard>();
            List<QuizzCard> answerList = new List<QuizzCard>();

            for (int questionCount = 0; questionCount <= Constants.MAX_NUMBER_OF_QNA; questionCount++)
            {
                quizzCard.userQuestion = UIMethods.GetUserQuestion();
                questionList.Add(quizzCard);

                for (int answerCount = 0; answerCount <= Constants.MAX_NUMBER_OF_QNA; answerCount++)
                {
                    quizzCard.userAnswer = UIMethods.SetUserAnswer();
                    answerList.Add(quizzCard);
                }

                Console.WriteLine("Correct answer?: ");
                string correctAnswer = Console.ReadLine();

                UIMethods.ClearScreen();
            }
            return questionList.ToString() + answerList.ToString(); 
        }

        public XmlSerializer GetSerializer()
        {
            
        }
    }

   
}
