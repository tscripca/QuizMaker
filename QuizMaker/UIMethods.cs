using QuizMaker;

namespace QuizMaker
{
    public class UIMethods
    {
        public static string GetQuestion()
        {
            Console.WriteLine("Type question: ");
            string userQuestion = Console.ReadLine();

            return userQuestion;
        }
    }
}
