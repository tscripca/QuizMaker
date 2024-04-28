using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class UIMethods
    {
        public static string GetUserQuestion()
        {
            Console.WriteLine("Type question: ");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }
    }
}
