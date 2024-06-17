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
            numberOfQuestions = ValidateUserInput(numberOfQuestions);
            return numberOfQuestions;
        }
        /// <summary>
        /// Sets the number of answers per question.
        /// </summary>
        /// <returns>An integer</returns>
        public static int SetNoOfAnswersPerEachQuestion()
        {
            int answersPerQuestion = 0;
            Console.WriteLine("Answers per each question?");
            answersPerQuestion = ValidateUserInput(answersPerQuestion);
            return answersPerQuestion;
        }
        /// <summary>
        /// Validates user input.
        /// </summary>
        /// <param name="userDataIn"></param>
        /// <returns>An integer value!</returns>
        public static int ValidateUserInput(int userDataIn)
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
        /// Asks for user input
        /// </summary>
        /// <returns>A string</returns>
        public static string AskUserQuestion()
        {
            Console.WriteLine("Question: ");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }
        /// <summary>
        /// Stores answers for each question in a list.
        /// </summary>
        /// <returns>A list of strings.</returns>
        public static List<string> SetUserAnswers(int selectNoOfAnswers)
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
        /// Code block where user build the quizz game and saves it to the local drive.
        /// </summary>
        public static void BuildingTheGame()
        {
            int numberOfQuestions = SetTotalNoOfQuestions();
            int numberOfAnswersPerQuestion = SetNoOfAnswersPerEachQuestion();
            var theMainQuizz = new List<QuizzGame>();
            ClearScreen();
            for (int questionCounter = 0; questionCounter < numberOfQuestions; questionCounter++)
            {
                var QnACard = new QuizzGame();
                QnACard.gameQuestion = AskUserQuestion();
                QnACard.answersList = SetUserAnswers(numberOfAnswersPerQuestion);
                QnACard.correctAnswer = GetCorrectAnswer(QnACard.answersList);
                theMainQuizz.Add(QnACard);
            }
            Logic.ExportToDrive(theMainQuizz);
        }
        /// <summary>
        /// Stores the correct answer.
        /// </summary>
        /// <param name="listOfUserAnswers"></param>
        /// <returns>Integer value</returns>
        public static int GetCorrectAnswer(List<string> listOfUserAnswers)
        {
            int correctAnswer = 0;
            Console.Write("Correct answer?: ");
            correctAnswer = ValidateUserInput(correctAnswer);
            Console.WriteLine($"You have selected: {listOfUserAnswers[correctAnswer - Constants.MINUS_ONE]} as the correct answer." +
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
        public static void StartGame()
        {
            char userSelectMode = ValidateGameChoiceInput();
            switch (userSelectMode)
            {
                case Constants.BUILD_GAME: BuildingTheGame(); break;
                case Constants.PLAY_GAME: PlayingTheGame(Logic.ImportFromDrive()); break;
            }
        }
        /// <summary>
        /// Code block where user is playing the game.
        /// </summary>
        /// <param name="listOfQnAToPrint"></param>
        public static void PlayingTheGame(List<QuizzGame> listOfQnAToPrint)
        {
            foreach (QuizzGame answerOption in listOfQnAToPrint)
            {
                int userSelectsAnswer = 0;
                Console.WriteLine($"Question: {answerOption.gameQuestion}");
                foreach (string eachIndividualAnswer in answerOption.answersList)
                {
                    Console.WriteLine($" {eachIndividualAnswer}");
                }                
                Console.Write("Correct answer: ");
                userSelectsAnswer = ValidateUserInput(userSelectsAnswer);
                if (userSelectsAnswer == answerOption.correctAnswer)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Sorry the correct answer was: {answerOption.correctAnswer}, {answerOption.answersList[answerOption.correctAnswer - Constants.MINUS_ONE]}");
                }
                Console.WriteLine();
            }
        }
    }
}