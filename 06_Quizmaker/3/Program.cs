using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        const int MAX_GAME_QUESTIONS = 5;
        const int MAX_WRONG_QUESTION_ANSWERS = 3;
        static void Main(string[] args)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<QuizCard>));
            XmlSerializer reader = new XmlSerializer(typeof(List<QuizCard>));
            var path = @"C:\Users\user\source\repos\QuizMaker\QuizCardRepository\QuizCardRepository.xml";

            List<QuizCard> quizcardRepository = new List<QuizCard>();
            int rightAnswerCounter = 0;

            UserInterface.GameIntroMessage();

            int createOrPlay = UserInterface.CreateOrPlayMessage();

            if (createOrPlay == 2)
            {
                bool createQuizcards = true;

                while (createQuizcards == true)
                {
                    quizcardRepository = BackUp.GetRepositoryBackup(quizcardRepository, reader, path);
                    DataInterface.CreateQuestion(quizcardRepository, MAX_WRONG_QUESTION_ANSWERS);
                    createQuizcards = UserInterface.CreateOneMoreQuizcard();
                    BackUp.CreateRepositoryBackup(quizcardRepository, writer, path);
                }
                createOrPlay = 1;
            }

            if (createOrPlay == 1)
            {
                UserInterface.GameStartMessage();

                quizcardRepository = BackUp.GetRepositoryBackup(quizcardRepository, reader, path);
     
                List<QuizCard> listOfPossibleQuestions = quizcardRepository;
                List<QuizCard> gameQuestions = new List<QuizCard>();
                Random random = new Random();

                while (gameQuestions.Count < MAX_GAME_QUESTIONS)
                {
                    int repositoryQuestionIndex = random.Next(listOfPossibleQuestions.Count);
                    gameQuestions.Add(listOfPossibleQuestions[repositoryQuestionIndex]);
                    listOfPossibleQuestions.RemoveAt(repositoryQuestionIndex);
                }

                while (gameQuestions.Count > 0)
                {
                    int rightAnswer = UserInterface.ShowGameQuestion(gameQuestions[0]);
                    int userAnswer = UserInterface.ShowQuestionAnswers(gameQuestions[0], MAX_WRONG_QUESTION_ANSWERS);

                    if (rightAnswer == userAnswer)
                    {
                        rightAnswerCounter++;
                    }

                    gameQuestions.RemoveAt(0);
                }
                UserInterface.resultMessage(rightAnswerCounter, MAX_GAME_QUESTIONS);
            }
        }
    }
}