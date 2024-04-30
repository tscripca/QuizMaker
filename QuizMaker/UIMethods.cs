using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class UIMethods
    {
        public static int NoOfQuestions()
        {
            Console.WriteLine("How many questions: ");
            int numberOfQuestions = Convert.ToInt32(Console.ReadLine());

            return numberOfQuestions;
        }

        public static int NoOfAnswersPerQuestion()
        {
            Console.WriteLine("How many answers per each question?");
            int answersPerQuestion = Convert.ToInt32(Console.ReadLine());

            return answersPerQuestion;  
        }

        /// <summary>
        /// Asks for user input
        /// </summary>
        /// <returns>Returns a string</returns>
        public static string GetUserQuestion()
        {
            Console.WriteLine("Type question: ");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }

        /// <summary>
        /// Stores answers in a list
        /// </summary>
        /// <returns>Returns list of strings</stirng></returns>
        public static List<string> GetUserAnswers()
        {
            List<string> answersList = new List<string>();            

            for (int answerCounter = 0; answerCounter <= 2; answerCounter++)
            {
                Console.WriteLine("Answer: ");
                string userAnswer = Console.ReadLine();
                answersList.Add(userAnswer);
            }
            return answersList;
        }
    }
}
