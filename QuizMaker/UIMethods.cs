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
            while (checkIfStringIsEmpty || retypeQuestion == true)
            {
                Console.Write("Question: ");
                userQuestion = Console.ReadLine();
                if (userQuestion == string.Empty)
                {
                    checkIfStringIsEmpty = String.IsNullOrEmpty(userQuestion);
                    Console.WriteLine("Question cannot be empty!");
                    PressKey();
                    ClearScreen();
                }
                else checkIfStringIsEmpty = false;
                if (!userQuestion.Any(char.IsDigit) || !userQuestion.Any(char.IsPunctuation))
                {
                    if (!userQuestion.StartsWith("?") && userQuestion.EndsWith("?"))
                        retypeQuestion = false;
                }
                else
                {
                    Console.WriteLine("Contains numbers/symbols!");
                    retypeQuestion = true;
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
            Console.WriteLine("Answers: ");
            for (int answerCounter = 0; answerCounter < selectNoOfAnswers; answerCounter++)
            {
                while (checkIfAnswerIsEmpty || retypeAnswer)
                {
                    userAnswer = Console.ReadLine();
                    if (userAnswer == string.Empty)
                    {
                        Console.WriteLine("Answer is empty!");
                    }
                    else if (userAnswer.Any(char.IsDigit) || userAnswer.Any(char.IsPunctuation))
                        Console.WriteLine("Contains strange characters.");
                    else
                    {
                        answersList.Add(userAnswer);
                        checkIfAnswerIsEmpty = false;
                        break;
                    }
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
            correctAnswer = ValidateUserInputInt(correctAnswer);
            Console.WriteLine($"You have selected: {listOfUserAnswers[correctAnswer - Const.INDEX_ONE]} as the correct answer.");
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
            bool editText = false;
            bool validFormat = false;
            char userDecision = default;
            List<char> listOfDigits = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Console.WriteLine("'E' to (edit)/'C' to (continue).");
            while (!validFormat)
            {
                try
                {
                    userDecision = Convert.ToChar(Console.ReadLine().ToLower());
                    if (userDecision == 'e') { Console.Write("Edit "); validFormat = true; editText = true; break; }
                    if (userDecision == 'c') { editText = false; break; }
                    //check if user input is a number.
                    for (int inputcounter = 0; inputcounter < listOfDigits.Count; inputcounter++)
                    {
                        if (userDecision == listOfDigits[inputcounter])
                        {
                            validFormat = false;
                            break;
                        }
                    }
                }                
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //if it's anything else than a number or 'c'/'e' it will ask for another input.
                if (userDecision != 'e' && userDecision != 'c')
                {
                    Console.WriteLine("Try again: ");
                }
            }
            return editText;
        }
    }
}