using System;
using System.Text;
using System.Xml.Serialization;
namespace QuizMaker
{
    public class QnACard
    {
        public static List<string> listOfQnA  = new List<string> ();        

        /// <summary>
        /// This method stores a set of questions and answers defined by user.
        /// </summary>
        /// <returns>Returnts a list type</returns>
        public static string SetQnA()
        {            
            Console.WriteLine("How many questions does your quizz have?: ");
            int quizzQuestions = Convert.ToInt32(Console.ReadLine());

            for (int questionsCounter = 0;  questionsCounter < quizzQuestions; questionsCounter++)
            {
                Console.WriteLine("Type question: ");
                string userQuestion = Console.ReadLine();
                listOfQnA.Add(userQuestion);
                for (int answersCounter = 0; answersCounter < Constants.DEFAULT_NUMBER_OF_ANSWERS; answersCounter++)
                {
                    Console.WriteLine("Give answer: ");
                    string userAnswer = Console.ReadLine();
                    listOfQnA.Add(userAnswer);
                }
                UIMethods.ClearScreen();
            }
            Serializer.StoreMyQnA(listOfQnA);
            return listOfQnA.ToString();
        }
    }
}