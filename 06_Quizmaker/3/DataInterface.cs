namespace QuizMaker
{
    internal class DataInterface
    {
        /// <summary>
        /// creates a new question object
        /// </summary>
        /// <param name="QuizCardRepository">List with all stored questions</param>
        /// <param name="MAX_WRONG_QUESTION_ANSWERS">number of max wrong answers for each question</param>
        /// <returns>updated List with all stored questions</returns>
        public static List<QuizCard> CreateQuestion(List<QuizCard> QuizCardRepository, int MAX_WRONG_QUESTION_ANSWERS)
        {
            QuizCard newQuizCard = new QuizCard();

            newQuizCard.question = UserInterface.AskForQuestion();

            newQuizCard.rigthAnswer = UserInterface.AskForRightAnswer();
            newQuizCard.allAnswers.Add(newQuizCard.rigthAnswer);

            int maxWrongAnswers = MAX_WRONG_QUESTION_ANSWERS;

            while (maxWrongAnswers >= 0)
            {
                newQuizCard.allAnswers.Add(UserInterface.AskForWrongAnswer());
                maxWrongAnswers--;
            }

            QuizCardRepository.Add(newQuizCard);

            return QuizCardRepository;
        }     
    }
}
