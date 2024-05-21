using QuizMaker;
using System.Net.Sockets;
using System.Xml.Serialization;
namespace QuizMaker
{
    public class UIMethods
    {   
        /// <summary>
        /// Wait for key press before continuing.
        /// </summary>
        public static void PressKey()
        {
            Console.ReadKey();
        }
        /// <summary>
        /// Clears the screen.
        /// </summary>
        public static void ClearScreen()
        {
            Console.Clear();
        }
        /// <summary>
        /// Sets the number of questions in total.
        /// </summary>
        /// <returns>An integer</returns>
        public static int SetTotalNoOfQuestions()
        {
            int numberOfQuestions = 0;
            Console.WriteLine("How many questions?");
            numberOfQuestions = UserInputValidation(numberOfQuestions);
            return numberOfQuestions;
        }
        /// <summary>
        /// Sets the number of answers per question.
        /// </summary>
        /// <returns>An integer</returns>
        public static int SetNoOfAnswersPerQuestion()
        {
            int answersPerQuestion = 0;
            Console.WriteLine("Answers per each question?");
            answersPerQuestion = UserInputValidation(answersPerQuestion);
            return answersPerQuestion;
        }
        public static int UserInputValidation(int userDataIn)
        {
            bool validFormat = false;
            while (!validFormat)
            {
                try
                {
                    userDataIn = Convert.ToInt32(Console.ReadLine());
                    validFormat = true;
                }
                catch (Exception inputValidationFail)
                {
                    Console.WriteLine(inputValidationFail.Message);
                    Console.Write("Try Again: ");
                }
            }
            return userDataIn;
        }
        /// <summary>
        /// Set the number of possible answers per each question.
        /// </summary>
        /// <returns>An integer.</returns>
        /// <summary>
        /// Asks for user input
        /// </summary>
        /// <returns>A string</returns>
        public static string GetUserQuestion()
        {
            Console.WriteLine("Question: ");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }
        /// <summary>
        /// Stores answers for each question in a list.
        /// </summary>
        /// <returns>A list of strings.</returns>
        public static List<string> GetUserAnswers(int selectNoOfAnswers)
        {
            List<string> answersList = new List<string>();
            Console.WriteLine("Answers: ");
            for (int answerCounter = 0; answerCounter < selectNoOfAnswers; answerCounter++)
            {
                string userAnswer = Console.ReadLine();
                answersList.Add(userAnswer);
            }
            return answersList;
        }
        /// <summary>
        /// Code block that deals with all user interaction.
        /// </summary>
        public static void LoopTheQnACards()
        {
            int numberOfQuestions = SetTotalNoOfQuestions();
            int numberOfAnswersPerQuestion = SetNoOfAnswersPerQuestion();
            var theMainQuizz = new List<QuizzGame>();
        ClearScreen();
            for (int questionCounter = 0; questionCounter < numberOfQuestions; questionCounter++)
            {
                var QnACard = new QuizzGame();
                QnACard.gameQuestion = GetUserQuestion();
                QnACard.answersList = GetUserAnswers(numberOfAnswersPerQuestion);
                QnACard.correctAnswer = GetCorrectAnswer(QnACard.answersList);
                theMainQuizz.Add(QnACard);
            }
            Logic.ExportToDrive(theMainQuizz);
        }
        /// <summary>
        /// Stores the correct answer.
        /// </summary>
        /// <param name="listOfUserAnswers"></param>
        /// <returns>List index</returns>
        public static int GetCorrectAnswer(List<string> listOfUserAnswers)
        {
            Console.Write("Correct answer?: ");
            int correctAnswer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You have selected: {listOfUserAnswers[correctAnswer - Constants.MINUS_ONE]} as a correct answer." +
                $"(Press any key to continue.)");
            PressKey();
            return correctAnswer;
        }

        /// <summary>
        /// Validates user input based on chosen option.
        /// </summary>
        /// <returns>A char variable</returns>
        public static char ValidateGameChoiceInput()
        {
            bool validInput = false;
            char userSelection = ' ';
            while (!validInput)
            {
                Console.WriteLine($"{Constants.BUILD_GAME} - build a quizz game");
                Console.WriteLine($"{Constants.PLAY_GAME} - load a quizz game");
                try
                {
                    userSelection = Convert.ToChar(Console.ReadLine());
                    validInput = true;
                    ClearScreen();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again.");
                    PressKey();
                    ClearScreen();
                }
            }
            return userSelection;
        }
        /// <summary>
        /// Allows user to select a game mode.
        /// </summary>
        /// <returns>An Enum</returns>
        public static void DeployGame(char userSelectMode)
        {
            GameMode gameModeSelector;
            userSelectMode = ValidateGameChoiceInput();
            switch (userSelectMode)
            {
                case Constants.BUILD_GAME:gameModeSelector = GameMode.buildQuizz; LoopTheQnACards(); break;
                case Constants.PLAY_GAME: gameModeSelector = GameMode.playQuizz; Logic.ImportFromDrive(); break;
            }
        }
    }
}