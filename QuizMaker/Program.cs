using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            for(int userQuestion = 0; userQuestion <= 2; userQuestion++)
            {
                QnACard myCard1 = new QnACard();
                myCard1.gameQuestion = UIMethods.GetUserQuestion();
                myCard1.answersList = Logic.GetUserAnswers();
            }
        }        
    }
}