using QuizMaker;
using System;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            QnACard gameCardQuestion = new QnACard();
            QnACard gameCardAnswer = new QnACard();

            List<QnACard> gameQuestionsList = new List<QnACard>();
            List<QnACard> gameAnswersList = new List<QnACard>();

            gameCardQuestion.gameQuestion = UIMethods.GetQuestion();
            gameCardAnswer.gameAnswer = Logic.SetAnswer();

            gameQuestionsList.Add(gameCardQuestion);
            gameAnswersList.Add(gameCardAnswer);


        }
    }
}