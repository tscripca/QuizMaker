namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QnACard myCard1 = new QnACard();

            UIMethods readQuestion = new UIMethods();
            Logic setTheAnswer = new Logic();
            Logic verifyTheAnswer = new Logic();
            Logic storeTheAnswer = new Logic();

            myCard1.gameQuestion = readQuestion.GetQuestion();
            myCard1.answersList = setTheAnswer.SetAnswer();
            myCard1.correctAnswer = storeTheAnswer.StoreCorrectAnswer(myCard1.answersList);
            verifyTheAnswer.VerifyCorrectAnswer(myCard1.correctAnswer);

            Console.WriteLine($"Your question is: {readQuestion.GetQuestion()}");            
            Console.WriteLine($"The list of answers: {setTheAnswer.SetAnswer()}");
            Console.WriteLine($"Answer stored is: {myCard1.correctAnswer}");            
        }
    }
}