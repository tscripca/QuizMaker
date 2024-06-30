using System;
using System.IO;
using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

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
            Console.Write("Question: ");
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
        public static void BuildTheGame()
        {
            var theMainQuizz = new List<QuizzGame>();
            int numberOfQuestions = SetTotalNoOfQuestions();
            int numberOfAnswersPerQuestion = SetNoOfAnswersPerEachQuestion();
            ClearScreen();
            for (int questionCounter = 0; questionCounter < numberOfQuestions; questionCounter++)
            {
                var QnACard = new QuizzGame();
                bool userWantstoEditText = true;
                while (userWantstoEditText)
                {
                    QnACard.quizzQuestion = AskUserQuestion();
                    QnACard.answersList = SetUserAnswers(numberOfAnswersPerQuestion);
                    QnACard.correctAnswer = GetCorrectAnswer(QnACard.answersList);
                    userWantstoEditText = EditText();
                }
                theMainQuizz.Add(QnACard);
                Console.WriteLine();
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
            Console.WriteLine($"You have selected: {listOfUserAnswers[correctAnswer - Const.INDEX_ONE]} as the correct answer." +
                $"(Press any key to continue.)");
            PressKey();
            return correctAnswer;
        }
        /// <summary>
        /// Validates user input based on chosen option.
        /// </summary>
        /// <returns>A char variable</returns>

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
                try
                {
                    userSelectsGameMode = Convert.ToChar(Console.ReadLine());
                    ClearScreen();
                }
                catch (Exception invalidFormat)
                {
                    Console.WriteLine(invalidFormat.Message);
                    ClearScreen();
                }

                // Console.WriteLine();
                switch (userSelectsGameMode)
                {
                    case '1': myGameMode = GameMode.build; BuildTheGame(); break;
                    case '2': myGameMode = GameMode.play; PlayTheGame(Logic.ImportFromDrive()); break;
                    default: myGameMode = GameMode.invalid; Console.WriteLine("Try again!"); break;
                }
            }
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
                userSelectedAnswer = ValidateUserInput(userSelectedAnswer);
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
        /// Allows to edit a game card before adding it to the game.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool EditText()
        {
            bool editText = false;
            char userDecision = default;
            Console.WriteLine("Have you changed your mind? \nPress 'E' to edit or 'C' to continue.");
            try
            {
                userDecision = Convert.ToChar(Console.ReadLine().ToLower());
            }
            catch (Exception invalidFormat)
            {
                Console.WriteLine(invalidFormat.Message);
            }
            if (userDecision == 'e')
            { editText = true; Console.WriteLine("Please edit tour text!"); AddEmptyLine(); }
            if (userDecision == 'c')
              editText = false;
            return editText;
        }
    }
}