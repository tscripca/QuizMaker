namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QnACard myCard1 = new QnACard();         

            myCard1.gameQuestion = UIMethods.GetQuestion();
            myCard1.answersList = Logic.SetAnswer();

            Console.WriteLine($"Your question was: {myCard1.gameQuestion}");
            Console.WriteLine($"The list of answers is: {myCard1.answersList}");
        }
    }
}