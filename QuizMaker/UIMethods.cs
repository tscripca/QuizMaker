using System;
using System.IO;
using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
namespace QuizMaker
{
    public class UIMethods
    {
        /// <summary>
        /// Adds an empty line.
        /// </summary>
        public static void AddEmptyLine()
        {
            Console.WriteLine();
        }
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
        /// Sets the number of questions the game will have.
        /// </summary>
        /// <returns>An integer</returns>
        public static int SetTotalNoOfQuestions()
        {
            int numberOfQuestions = 0;
            Console.WriteLine("How many questions?");
            numberOfQuestions = ValidateUserInputInt(numberOfQuestions);
            return numberOfQuestions;
        }
        /// <summary>
        /// Sets the number of answers per each question.
        /// </summary>
        /// <returns>An integer</returns>
        public static int SetNoOfAnswersPerEachQuestion()
        {
            int answersPerQuestion = 0;
            Console.WriteLine("Answers per each question?");
            answersPerQuestion = ValidateUserInputInt(answersPerQuestion);
            return answersPerQuestion;
        }
        /// <summary>
        /// Validates user input for int values only.
        /// </summary>
        /// <param name="userDataIn"></param>
        /// <returns>An integer value!</returns>
        public static int ValidateUserInputInt(int userDataIn)
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
        /// Asks for user input. Special characters/symbols are not allowed.
        /// </summary>
        /// <returns>A string</returns>
        public static string AskUserQuestion()
        {
            bool checkIfStringIsEmpty = true;
            bool retypeQuestion = false;
            string userQuestion = string.Empty;
            while (checkIfStringIsEmpty || retypeQuestion)
            {
                string stringOfSymbols = "!#$%&'()*+,-./:;<=>@[\\]^_`{|}~0123456789";
                Console.Write("Question: ");
                userQuestion = Console.ReadLine();
                if (userQuestion == string.Empty)
                {
                    checkIfStringIsEmpty = String.IsNullOrEmpty(userQuestion);
                    ClearScreen();
                }
                else checkIfStringIsEmpty = false;
                foreach (char letter in userQuestion)
                {
                    foreach (char symbol in stringOfSymbols)
                    {
                        if (symbol == letter)
                        {
                            retypeQuestion = true;
                            break;
                        }
                    }
                    break;
                }
            }
            return userQuestion;
        }
        /// <summary>
        /// Stores answers for each question in a list.
        /// </summary>
        /// <returns>A list of strings.</returns>
        public static List<string> SetUserAnswers(int selectNoOfAnswers)
        {
            string userAnswer = string.Empty;
            bool checkIfAnswerIsEmpty = true;
            bool retypeAnswer = true;
            List<string> answersList = new List<string>();
            string letterString = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine("Answers: ");
            for (int answerCounter = 0; answerCounter < selectNoOfAnswers; answerCounter++)
            {
                Console.Write($"{letterString[answerCounter]}) ");
                for (int letterCounter = answerCounter; letterCounter <= answerCounter;)
                {
                    while (checkIfAnswerIsEmpty || retypeAnswer)
                    {
                        userAnswer = Console.ReadLine();
                        if (userAnswer == string.Empty)
                            Console.WriteLine("Answer is empty!");
                        else if (userAnswer.Any(char.IsDigit) || userAnswer.Any(char.IsPunctuation))
                            Console.WriteLine("Contains strange characters.");
                        else { answersList.Add(userAnswer); checkIfAnswerIsEmpty = false; break; }
                    }
                    break;
                }
            }
            return answersList;
        }
        /// <summary>
        /// Code block where user build the quizz game and saves it to the local drive.
        /// </summary>
        public static void BuildTheGame()
        {
            var theMainQuizz = new List<QuizzGame>();
            int numberOfQuestions = SetTotalNoOfQuestions();
            int numberOfAnswersPerQuestion = SetNoOfAnswersPerEachQuestion();
            ClearScreen();
            CreateDeckOfCards(theMainQuizz, numberOfQuestions, numberOfAnswersPerQuestion);
            Logic.ExportToDrive(theMainQuizz);
        }
        /// <summary>
        /// Creates the deck of game cards.
        /// </summary>
        /// <param name="mainGameList"></param>
        /// <param name="numOfQuestions"></param>
        /// <param name="numOfAnswXQuestion"></param>
        /// <returns>Only the list of possible answers without the question.</returns>
        public static List<string> CreateDeckOfCards(List<QuizzGame> mainGameList, int numOfQuestions, int numOfAnswXQuestion)
        {
            var QnACard = new QuizzGame();
            QnACard.answersList = new List<string>();
            for (int questionCounter = 0; questionCounter < numOfQuestions; questionCounter++)
            {
                bool userWantstoEditText = true;
                while (userWantstoEditText)
                {
                    QnACard.quizzQuestion = AskUserQuestion();
                    QnACard.answersList = SetUserAnswers(numOfAnswXQuestion);
                    QnACard.correctAnswer = GetCorrectAnswer(QnACard.answersList);
                    userWantstoEditText = EditText();
                }
                mainGameList.Add(QnACard);
            }
            return QnACard.answersList;
        }
        /// <summary>
        /// Stores the correct answer.
        /// </summary>
        /// <param name="listOfUserAnswers"></param>
        /// <returns>Integer value</returns>
        public static int GetCorrectAnswer(List<string> listOfUserAnswers)
        {
            bool indexOutOfRange = true;
            int correctAnswer = 0;
            int howManyCorrectAnswers = 0;
            string stringOfLetters = "abcdefghijklmnopqrstuvwxyz";
            var listOfCorrectAnswers = new List<string>();
            //check for index out of range.
            while (indexOutOfRange)
            {
                Console.Write("How many correct answers?: ");
                howManyCorrectAnswers = ValidateUserInputInt(howManyCorrectAnswers);
                Console.WriteLine("Select answers: ");
                for (int i = 0; i < howManyCorrectAnswers; i++)
                {
                    correctAnswer = Convert.ToInt32(Console.ReadLine());
                    listOfCorrectAnswers.Add(listOfUserAnswers[correctAnswer - 1]);
                }
                Console.WriteLine("Your selected answers are: ");
                for (int j = 0; j < listOfCorrectAnswers.Count; j++)
                {
                    for (int letterCount = j; letterCount <= j;)
                    {
                        Console.WriteLine($"{stringOfLetters[letterCount]}) {listOfCorrectAnswers[j]}");
                        break;
                    }                    
                }
            }
            return correctAnswer;
        }
        /// <summary>
        /// Ask user to select a game mode.
        /// </summary>
        /// <returns>An Enum</returns>
        public static void StartGame()
        {
            GameMode myGameMode = GameMode.invalid;
            while (myGameMode == GameMode.invalid)
            {
                Console.WriteLine("1 - Build game.");
                Console.WriteLine("2 - Play game.");
                char userSelectsGameMode = default;
                userSelectsGameMode = ValidateUserInputChar(userSelectsGameMode);
                switch (userSelectsGameMode)
                {
                    case Const.OPTION_ONE: myGameMode = GameMode.build; BuildTheGame(); break;
                    case Const.OPTION_TWO:
                        myGameMode = GameMode.play;
                        if (Logic.ImportFromDrive().Count != 0)
                        {
                            PlayTheGame(Logic.ImportFromDrive());
                        }
                        else
                        {
                            Console.WriteLine("Your deck is empty, create a game first!");
                        }
                        break;
                    default: myGameMode = GameMode.invalid; Console.WriteLine("Try again!"); break;
                }
            }
        }
        /// <summary>
        /// Check if input value is a char and returns its value;
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>Char</returns>
        public static char ValidateUserInputChar(char userInput)
        {
            try
            {
                userInput = Convert.ToChar(Console.ReadLine());
                ClearScreen();
            }
            catch (Exception invalidFormat)
            {
                Console.WriteLine(invalidFormat.Message);
                ClearScreen();
            }
            return userInput;
        }
        /// <summary>
        /// Code block where user is playing the game.
        /// </summary>
        /// <param name="deckOfCards"></param>
        public static void PlayTheGame(List<QuizzGame> deckOfCards)
        {
            int keepCountOfCorrectAnswers = 0;
            Console.WriteLine($"Your deck contains {deckOfCards.Count} cards.");
            foreach (QuizzGame gameCard in deckOfCards)
            {
                int userSelectedAnswer = 0;
                Console.WriteLine();
                Console.WriteLine($"Question: {gameCard.quizzQuestion}");
                foreach (string eachAnswerOption in gameCard.answersList)
                {
                    Console.WriteLine($" {eachAnswerOption}");
                }
                Console.Write("Correct answer: ");
                userSelectedAnswer = ValidateUserInputInt(userSelectedAnswer);
                if (userSelectedAnswer == gameCard.correctAnswer)
                {
                    keepCountOfCorrectAnswers++;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Sorry the correct answer was: {gameCard.answersList[gameCard.correctAnswer - Const.INDEX_ONE]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"You have {keepCountOfCorrectAnswers} correct answers!");
        }
        /// <summary>
        /// Allows to edit a card before adding it to the deck.
        /// </summary>
        /// <returns>Boolean</returns>       
        public static bool EditText()
        {
            bool validFormat = false;
            bool editText = true;
            while (!validFormat)
            {
                Console.Write("Enter(Continue) or E(Edit) card: ");
                try
                {
                    ConsoleKeyInfo userpress = Console.ReadKey();
                    char userInput = userpress.KeyChar;
                    Console.WriteLine();
                    if (userInput == 'e') { Console.Write("Edit "); validFormat = true; editText = true; }
                    if (userpress.Key == ConsoleKey.Enter) { validFormat = true; editText = false; }
                }
                catch (Exception invalidFormat)
                {
                    Console.WriteLine(invalidFormat.Message);
                }
            }
            return editText;
        }
    }
}