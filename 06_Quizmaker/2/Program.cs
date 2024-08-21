namespace QuizMaker
{
    internal class Program
    {
        private static readonly int QUESTION_COUNT = 10;

        static void Main(string[] args)
        {
            bool questionsAdded = false;
            int score = 0;
            int questionsAsked = 0;
            List<int> listOfNumbersUsed = new List<int>();
            List<QuestionAndAnswers> listOfQuestionsAndAnswers = Logic.Deserialize();

            UI.PrintWelcomeMessage();
            UI.PrintInstructions();

            while (true)
            {
                string addQuestions = UI.ChoiceToAddQuestions();
                if (addQuestions != "y")
                {
                    break;
                }

                string question = UI.CreateQuestion();
                int answerCount = UI.NumberOfAnswers();
                List<string> answers = UI.CreateAnswers(answerCount);
                int correctAnswerIndex = UI.CreateCorrectAnswerIndex();
                QuestionAndAnswers newQuestion = Logic.CompileNewQuestionAndAnswers(question, answers, correctAnswerIndex);
                listOfQuestionsAndAnswers.Add(newQuestion);
                questionsAdded = true;
            }

            if (questionsAdded)
            {
                Logic.Serialize(listOfQuestionsAndAnswers);
            }


            for (int i = 0; i < QUESTION_COUNT; i++)
            {
                if (i >= listOfQuestionsAndAnswers.Count)
                {
                    break;
                }

                int index = Logic.GetRandomQuestion(listOfQuestionsAndAnswers, listOfNumbersUsed);
                UI.PrintQuestionAndAnswers(listOfQuestionsAndAnswers[index]);
                int guess = UI.GetGuess();
                bool result = Logic.CheckResultOfGuess(listOfQuestionsAndAnswers[index], guess);
                UI.PrintResultOfGuess(listOfQuestionsAndAnswers[index], result);
                questionsAsked++;
                score = Logic.IncreaseScoreCount(score, result);
            }
            UI.PrintScore(score, questionsAsked);
        }
    }
}