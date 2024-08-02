using System;
using System.IO;
using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;
using System.Security.Cryptography.X509Certificates;
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
            string numOfQst = default;
            Console.WriteLine("How many questions?");
            int numberOfQuestions = ValidateInputFormatInt(numOfQst);
            return numberOfQuestions;
        }
        /// <summary>
        /// Sets the number of answers per each question.
        /// </summary>
        /// <returns>An integer</returns>
        public static int SetNoOfAnswersPerEachQuestion()
        {
            int validInput = 0;
            string userInput = default;
            Console.WriteLine("Answers per each question?");
            validInput = ValidateInputFormatInt(userInput);
            return validInput;
        }
        /// <summary>
        /// Validates user input for int values only.
        /// </summary>
        /// <param name="userDataIn"></param>
        /// <returns>An integer value!</returns>
        public static int ValidateInputFormatInt(string userDataIn)
        {
            bool validFormat = false;
            int newVar = 0;
            while (!validFormat)
            {
                userDataIn = Console.ReadLine();
                validFormat = int.TryParse(userDataIn, out newVar);
                if (!validFormat)
                    Console.WriteLine("Only numbers please, try again!");
            }
            return newVar;
        }
        /// <summary>
        /// Asks for user input. Special characters/symbols are not allowed.
        /// </summary>
        /// <returns>A string</returns>
        public static string AskUserQuestion()
        {
            bool checkIfStringIsEmpty = true;
            bool retypeQuestion = true;
            string userQuestion = string.Empty;
            while (checkIfStringIsEmpty || retypeQuestion)
            {
                //no need to type the question mark, it will be displayed in PlayGame mode.                
                Console.Write($"Question : ");
                userQuestion = Console.ReadLine();
                if (userQuestion == string.Empty || userQuestion == " ")
                {
                    Console.WriteLine("Question is empty, try again!");
                }
                else checkIfStringIsEmpty = false;
                if (userQuestion.Any(char.IsPunctuation))
                {
                    Console.WriteLine("Contains symbols.");
                }
                else retypeQuestion = false;
            }
            return userQuestion;
        }
        /// <summary>
        /// Stores the answers for each question in a list of strings.
        /// </summary>
        /// <returns>A list of strings.</returns>
        public static List<string> SetUserAnswers(int selectNoOfAnswers)
        {
            var gameCard = new QuizzGame();
            string userAnswer = string.Empty;
            //bool retypeAnswer = true;
            List<string> answersList = new List<string>();
            Console.WriteLine("Answers: ");
            for (int answCount = 0; answCount < selectNoOfAnswers; answCount++)
            {
                bool checkIfAnswerIsEmpty = true;
                while (checkIfAnswerIsEmpty)
                {
                    Console.Write($"{answCount + Const.INDEX_ONE}) ");
                    userAnswer = Console.ReadLine();
                    if (userAnswer == string.Empty || userAnswer == " ")
                        Console.WriteLine("Answer is empty, try again!");
                    else if (userAnswer.Any(char.IsDigit) || userAnswer.Any(char.IsPunctuation))
                        Console.WriteLine("Contains strange characters, try again!");
                    else if (answersList.Contains(userAnswer))
                        Console.WriteLine("Duplicate answer, try again!");
                    else { answersList.Add(userAnswer); checkIfAnswerIsEmpty = false; break; }
                }
            }
            return answersList;
        }
        /// <summary>
        /// Method where the user creates the deck of QnA card.
        /// </summary>
        /// <param name="mainGameList"></param>
        /// <param name="numOfQuestions"></param>
        /// <param name="numOfAnswXQuestion"></param>
        public static void CreateDeckOfCards(List<QuizzGame> mainGameList, int numOfQuestions, int numOfAnswXQuestion)
        {
            for (int questionCounter = 0; questionCounter < numOfQuestions; questionCounter++)
            {
                var QnACard = new QuizzGame();
                QnACard.answersList = new List<string>();
                bool userWantstoEditText = true;
                while (userWantstoEditText)
                {
                    Console.WriteLine();
                    QnACard.quizzQuestion = AskUserQuestion();
                    QnACard.answersList = SetUserAnswers(numOfAnswXQuestion);
                    QnACard.listOfcorrectAnswers = GetCorrectAnswer(QnACard.answersList);
                    userWantstoEditText = EditText();
                }
                mainGameList.Add(QnACard);
            }
        }
        /// <summary>
        /// Set the initial number of questions and answers.
        /// </summary>
        public static void BuildTheGame()
        {
            int numberOfAnswersPerQuestion = 0;
            var theMainQuizz = new List<QuizzGame>();
            int numberOfQuestions = SetTotalNoOfQuestions();
            numberOfAnswersPerQuestion = SetNoOfAnswersPerEachQuestion();
            ClearScreen();
            CreateDeckOfCards(theMainQuizz, numberOfQuestions, numberOfAnswersPerQuestion);
            Logic.ExportToDrive(theMainQuizz);
        }
        /// <summary>
        /// Storesc the correct answers in a list.
        /// </summary>
        /// <param name="listOfUserAnswers"></param>
        /// <returns>List of strings</returns>
        public static List<string> GetCorrectAnswer(List<string> listOfUserAnswers)
        {
            var QnACard = new QuizzGame();
            var listOfIndexes = new List<int>();
            int correctAnswer = 0;
            string howManyCorrectAnswers = default;
            int howManyCorrAns = 0;
            bool indexRangeCorrect = false;
            bool correctNumOfAnsw = false;
            bool correctNumOfOptions = false;
            //check for indexOfAnswers out of range.
            while (!indexRangeCorrect)
            {
                Console.Write("How many correct answers?: ");
                while (!correctNumOfAnsw)
                {
                    howManyCorrAns = ValidateInputFormatInt(howManyCorrectAnswers);
                    if (howManyCorrAns <= listOfUserAnswers.Count)
                    {
                        correctNumOfAnsw = true;
                    }
                    else Console.WriteLine("Try again: ");
                }
                Console.WriteLine("Select answers: ");
                //The increment variable has been moved so it increments only when you choose a correct option.
                //If you type a value that is not available then the increment variable will stay to the last memmorized value.
                for (int loopThroughCorrectAnswers = 0; loopThroughCorrectAnswers < howManyCorrAns;)
                {
                    while (!correctNumOfOptions)
                    {
                        correctAnswer = ValidateInputFormatInt(howManyCorrectAnswers);
                        if (correctAnswer > listOfUserAnswers.Count)
                        {
                            Console.WriteLine($"Value too high, max {listOfUserAnswers.Count}");
                        }
                        else
                        {
                            QnACard.listOfcorrectAnswers.Add(listOfUserAnswers[correctAnswer - Const.INDEX_ONE]);
                            listOfIndexes.Add(correctAnswer);
                            loopThroughCorrectAnswers++;
                        }
                        break;
                    }
                }
                Console.WriteLine("Your selected answers are: ");
                for (int loopThroughListOfIndexes = 0; loopThroughListOfIndexes < QnACard.listOfcorrectAnswers.Count; loopThroughListOfIndexes++)
                {
                    Console.WriteLine($"{listOfIndexes[loopThroughListOfIndexes]}) {QnACard.listOfcorrectAnswers[loopThroughListOfIndexes]}");
                }
                indexRangeCorrect = true;
            }
            return QnACard.listOfcorrectAnswers;
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
                Console.WriteLine($"{Const.BUILD_MODE} - Build game.");
                Console.WriteLine($"{Const.PLAY_MODE} - Play game.");
                char userSelectsGameMode = default;
                string usrGameMod = default;
                userSelectsGameMode = ValidateInputFormatChar(usrGameMod);
                switch (userSelectsGameMode)
                {
                    case Const.BUILD_MODE: myGameMode = GameMode.build; BuildTheGame(); break;
                    case Const.PLAY_MODE:
                        myGameMode = GameMode.play;
                        if (File.Exists(Const.SAVED_PATH))
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
        public static char ValidateInputFormatChar(string userInput)
        {
            bool validInput = false;
            char newChar = default;
            while (!validInput)
            {
                userInput = Console.ReadLine();
                validInput = char.TryParse(userInput, out newChar);
                if (!validInput)
                    Console.WriteLine("Try again!");
            }
            return newChar;
        }
        /// <summary>
        /// Code block where user is playing the game.
        /// </summary>
        /// <param name="deckOfCards"></param>
        public static void PlayTheGame(List<QuizzGame> deckOfCards)
        {
            int supposedAnswers = 0;
            int totalScore = 0;
            Console.WriteLine($"Your deck contains {deckOfCards.Count} cards.");
            foreach (QuizzGame gameCard in deckOfCards)
            {
                string userSelectedAnswer = default;
                Console.WriteLine();
                //question mark will be added automatically.
                Console.WriteLine($"{gameCard.quizzQuestion}?");
                for (int eachAnswer = 0; eachAnswer < gameCard.answersList.Count; eachAnswer++)
                {
                    for (int bulletNum = eachAnswer; eachAnswer <= bulletNum;)
                    {
                        Console.WriteLine($"{bulletNum + Const.INDEX_ONE}) {gameCard.answersList[eachAnswer]}");
                        break;
                    }
                }
                totalScore += KeepTrackOfAnswers(userSelectedAnswer, gameCard);
                supposedAnswers += gameCard.listOfcorrectAnswers.Count;
            }
            AddEmptyLine();
            SetGradePassOrFail(totalScore, supposedAnswers);
            Console.WriteLine($"You've answered {totalScore} out of {supposedAnswers}");
        }
        /// <summary>
        /// Compares the user selection with the list of correct answers and, if correct, keeps track of points earned.
        /// </summary>
        /// <param name="userTryToAnswer"></param>
        /// <param name="cardAx"></param>
        /// <returns>Points earned</returns>
        public static int KeepTrackOfAnswers(string userTryToAnswer, QuizzGame cardAx)
        {
            int keepCountOfCorrectAnswers = 0;
            int userPickAnswer = 0;
            for (int bulletNoForCorrectAnsw = 0; bulletNoForCorrectAnsw < cardAx.listOfcorrectAnswers.Count; bulletNoForCorrectAnsw++)
            {
                bool indexExists = true;
                Console.Write($"Answer {bulletNoForCorrectAnsw + Const.INDEX_ONE}: ");
                userPickAnswer = ValidateInputFormatInt(userTryToAnswer);
                //comparing user choice with the list of correct answers to see if there is a match.
                //also check if the user selection in this case is not higher than the existing values.
                while (indexExists)
                {
                    if (userPickAnswer > cardAx.answersList.Count)
                    {
                        Console.WriteLine("Out of range, try again!");
                        bulletNoForCorrectAnsw--;
                        break;
                    }
                    for (int loopThroughCorrectAnswers = 0; loopThroughCorrectAnswers < cardAx.listOfcorrectAnswers.Count; loopThroughCorrectAnswers++)
                    {
                        if (cardAx.answersList[userPickAnswer - Const.INDEX_ONE] == cardAx.listOfcorrectAnswers[loopThroughCorrectAnswers])
                        {
                            keepCountOfCorrectAnswers++;
                            break;
                        }
                    }
                    break;
                }
            }
            Console.WriteLine($"You have {keepCountOfCorrectAnswers} correct answers.");
            return keepCountOfCorrectAnswers;
        }
        /// <summary>
        /// Allows to edit a game card before adding it to the deck.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool EditText()
        {
            bool validFormat = false;
            bool editText = true;
            char userEditText = default;
            while (!validFormat)
            {
                Console.Write("Continue(C) or Edit(E) card: ");
                string userChoice = default;
                userEditText = ValidateInputFormatChar(userChoice);
                if (userEditText == 'e') { editText = true; break; }
                else if (userEditText == 'c') { editText = false; break; }
                else Console.WriteLine("Try again!");
            }
            return editText;
        }
        /// <summary>
        /// Calculates the final score percentage and displays the result.
        /// </summary>
        /// <param name="finalScore"></param>
        /// <param name="supposedCorrectAnswers"></param>
        public static void SetGradePassOrFail(int finalScore, int supposedCorrectAnswers)
        {
            int passGrade = 80;
            int percentageRetreived = finalScore * 100 / supposedCorrectAnswers;
            if (percentageRetreived >= passGrade)
                Console.WriteLine($"Passed! Your score is: {percentageRetreived}%");
            else
                Console.WriteLine($"Failed! your score is: {percentageRetreived}%");
        }
    }
}