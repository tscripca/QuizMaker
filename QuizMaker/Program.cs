using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QnACard myCard1 = new QnACard();

            myCard1.gameQuestion = UIMethods.GetUserQuestion();
            myCard1.answersList = Logic.GetUserAnswers();

            Console.WriteLine($"Your question was: {myCard1.gameQuestion}");

            foreach (string answer in myCard1.answersList)
            {
                Console.WriteLine($"The list of answers contains: {answer}");
            }
        }        
    }
}