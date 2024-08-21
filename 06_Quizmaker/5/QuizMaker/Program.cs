using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();
            string filePath = ConfigurationManager.AppSettings.Get("path");
            List<QnA> qnaQuestions = Data.LoadQuestionList(filePath);
            List<QnA> deserializedList = new();

            Data.Serialize(qnaQuestions);
            deserializedList = Data.Desirialize<List<QnA>>();

            if (deserializedList.Count == 0)
            {
                UI.PrintErrorToReadTheFile();
                return;
            }

            if (deserializedList.Count > 0)
            {
                int? answer;
                int answerTry;
                int correctCount = 0;
                int wrongCount = 0;

                var reorderedQuestions = deserializedList.OrderBy(x => rnd.Next());

                foreach (var reorderedQuestion in reorderedQuestions)
                {
                    answerTry = 0;
                    do
                    {
                        answer = UI.PrintQuestionAndGetAnswer(reorderedQuestion);
                        answerTry++;
                    } while (answer == null && answerTry < 3);

                    if (answerTry < 3)
                    {
                        if (IsItCorrectAnswer(reorderedQuestion, answer))
                        {
                            correctCount++;
                        }
                        else
                        {
                            wrongCount++;
                        }
                    }

                    if ((correctCount + wrongCount) < deserializedList.Count)
                    {
                        if (!UI.AskUserToContinue(correctCount, wrongCount))
                        {
                            break;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Verify if user answer is correct
        /// </summary>
        /// <param name="question">selected question object</param>
        /// <param name="answerIndex">answer index(0 to 3)</param>
        /// <returns></returns>
        public static bool IsItCorrectAnswer(QnA question, int? answerIndex)
        {
            bool correctAnswer = false;

            if (answerIndex == question.CorrectAnswer)
            {
                correctAnswer = true;
            }

            return correctAnswer;
        }
    }
}
