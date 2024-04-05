using QuizMaker;

namespace QuizMaker
{
    public class Logic
    {
        public static string SetAnswer()
        {
            List<string> answerList = new();
            string userAnswer = "";
            for (int answerCounter = 0; answerCounter <= 2; answerCounter++)
            {
                Console.WriteLine("Answer: ");
                userAnswer = Console.ReadLine();   
                
                answerList.Add(userAnswer);
            }
            return answerList.ToString();
        }
    }
}
