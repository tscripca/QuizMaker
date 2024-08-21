using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace quizgame
{
    class Program
    {
        static void Main(string[] args)
        {
            int userScore = 0;

            Database.CheckOrCreateDatabase();
            Database.Read();
            
            UI.WelcomeMessage();
            UI.CurrentQuestionNumber(Database.QuestionCount);
            bool wantToAdd = UI.RequestAddingQuestion();
            while (wantToAdd)
            {
                Database.AddQuestionToList(UI.AddQuestion());
                wantToAdd = UI.RequestAddingQuestion();
            }
            Database.Save();
            if (Database.QuestionCount == 0)
            {
                UI.NoQuestionsInTheDatabase();
                Environment.Exit(0);
            }
            bool wantToPlay = UI.ContinueGame();
            List<QuestionAndAnswer> shuffledList = Database.ShuffledQuestionList();
            int count = 0;
            while (wantToPlay)
            {
                if (count == Database.QuestionCount)
                {
                    UI.NoQuestionsLeft();
                    break;
                }
                QAPair selectedAnswer = UI.DisplayQuestion(shuffledList, count);
                bool gameRound = CorrectOrIncorrect(selectedAnswer);
                if (gameRound)
                {
                    userScore++;
                    UI.UserWonARound(userScore);
                }
                else
                {
                    userScore--;
                    UI.UserLostARound(userScore);
                }
                count++;
                wantToPlay = UI.ContinueGame();
            }


                  
        }

        public static bool CorrectOrIncorrect(QAPair answer)
        {
            if (answer.isCorrect)
            {
                return true;
            }
            return false;
        }



    }
}