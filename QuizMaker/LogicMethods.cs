using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaker;

namespace QuizMaker
{
    public class LogicMethods
    {
        public static List<QuizzCard> SetQnALoop()
        {
            
            int answersCounter;
            int questionCounter;
            int howManyquestionsInTotal = UIMethods.AskHowManyquestions();
            int howManyAnswersPerQuestion = UIMethods.AskHowManyAnswers();
            
            for (questionCounter = 0; questionCounter <= howManyquestionsInTotal; questionCounter++)
            {
                UIMethods.DisplayQuestionsCounter(questionCounter);
                UIMethods.SetQuestion();
                for (answersCounter = 0; answersCounter <= howManyAnswersPerQuestion; answersCounter++)
                {
                    string usertypesTheAnswer = UIMethods.SetAnswer();
                    QuizzCard.Add(usertypesTheAnswer);
                }
                UIMethods.ClearScreen();
            }

        }
    }
}
