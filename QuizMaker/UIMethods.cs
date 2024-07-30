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
            string answersPerQuestion = " ";
            Console.WriteLine("Answers per each question?");
            int ansXQst = ValidateInputFormatInt(answersPerQuestion);
            return ansXQst;
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
                if(!validFormat)
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
                Console.Write("Question: ");
                userQuestion = Console.ReadLine();
                if (userQuestion == string.Empty)
                {
                    checkIfStringIsEmpty = String.IsNullOrEmpty(userQuestion);
                    ClearScreen();
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
        /// Stores answers for each question in a list.
        /// </summary>
        /// <returns>A list of strings.</returns>
        public static List<string> SetUserAnswers(int selectNoOfAnswers)
        {
            var gameCard = new QuizzGame();
            string userAnswer = string.Empty;
            bool checkIfAnswerIsEmpty = true;
            bool retypeAnswer = true;
            List<string> answersList = new List<string>();
            Console.WriteLine("Answers: ");
            for (int answCount = 0; answCount < selectNoOfAnswers; answCount++)
            {
                Console.Write($"{answCount + Const.INDEX_ONE}) ");
                while (checkIfAnswerIsEmpty || retypeAnswer)
                {
                    userAnswer = Console.ReadLine();
                    if (userAnswer == string.Empty)
                        Console.WriteLine("Answer is empty!");
                    else if (userAnswer.Any(char.IsDigit) || userAnswer.Any(char.IsPunctuation))
                        Console.WriteLine("Contains strange characters.");
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
            var theMainQuizz = new List<QuizzGame>();
            int numberOfQuestions = SetTotalNoOfQuestions();
            int numberOfAnswersPerQuestion = SetNoOfAnswersPerEachQuestion();
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
                try
                {
                    for (int i = 0; i < howManyCorrAns; i++)
                    {
                        correctAnswer = Convert.ToInt32(Console.ReadLine());
                        QnACard.listOfcorrectAnswers.Add(listOfUserAnswers[correctAnswer - Const.INDEX_ONE]);
                        listOfIndexes.Add(correctAnswer);
                    }
                    Console.WriteLine("Your selected answers are: ");
                    for (int j = 0; j < QnACard.listOfcorrectAnswers.Count; j++)
                    {
                        Console.WriteLine($"{listOfIndexes[j]}) {QnACard.listOfcorrectAnswers[j]}");
                    }
                    indexRangeCorrect = true;
                }
                catch (Exception outOfRange)
                {
                    Console.WriteLine(outOfRange.Message);
                    indexRangeCorrect = false;
                }
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
            while(!validInput)
            {
                userInput = Console.ReadLine();
                validInput = char.TryParse(userInput, out newChar);
                if(!validInput)
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
            SetPassOrFail(totalScore, supposedAnswers);
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
            int userTry = 0;
            for (int k = 0; k < cardAx.listOfcorrectAnswers.Count; k++)
            {
                Console.Write($"Answer {k + Const.INDEX_ONE}: ");
                userTry = ValidateInputFormatInt(userTryToAnswer);
                //comparing user choice with the list of correct answers to see if there is a match.
                for (int p = 0; p < cardAx.listOfcorrectAnswers.Count; p++)
                {
                    if (cardAx.answersList[userTry - Const.INDEX_ONE] == cardAx.listOfcorrectAnswers[p])
                    {
                        keepCountOfCorrectAnswers++;
                        break;
                    }
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
        /// <summary>
        /// Calculates the final score percentage and displays the result.
        /// </summary>
        /// <param name="finalScore"></param>
        /// <param name="supposedCorrectAnswers"></param>
        public static void SetPassOrFail(float finalScore, float supposedCorrectAnswers)
        {
            int passGrade = 80;
            float percentageRetreived = finalScore * 100 / supposedCorrectAnswers;
            if (percentageRetreived >= passGrade)
                Console.WriteLine($"Passed! Your score is: {percentageRetreived}%");
            else
                Console.WriteLine($"Failed! your score is: {percentageRetreived}%");
        }
    }
}