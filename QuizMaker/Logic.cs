using QuizMaker;

namespace QuizMaker
{
    public class Logic
    {
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
