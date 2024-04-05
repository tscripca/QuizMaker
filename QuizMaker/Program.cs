using QuizMaker;
using System;
namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            QnACard QnACard = new QnACard();
            List<QnACard> gameQuestionsList = new List<QnACard>();
            List<QnACard> gameAnswersList = new List<QnACard>();
            QnACard.gameQuestion = UIMethods.GetQuestion();
            QnACard.gameAnswer = Logic.SetAnswer();
        }
    }
}