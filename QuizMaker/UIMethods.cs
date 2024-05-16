﻿using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class UIMethods
    {
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
            Console.Write("How many questions: ");
            int numberOfQuestions = Convert.ToInt32(Console.ReadLine());

            return numberOfQuestions;
        }
        /// <summary>
        /// Set the number of possible answers per each question.
        /// </summary>
        /// <returns>An integer.</returns>
        public static int SetNoOfAnswersPerQuestion()
        {
            Console.Write("Answers per each question: ");
            int answersPerQuestion = Convert.ToInt32(Console.ReadLine());            

            return answersPerQuestion;  
        }

        /// <summary>
        /// Asks for user input
        /// </summary>
        /// <returns>A string</returns>
        public static string GetUserQuestion()
        {
            Console.Write("Question: ");
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
            Logic.ImportFromDrive(theMainQuizz);
        }
        public static int GetCorrectAnswer(List<string> listOfUserAnswers)
        {
            Console.Write("Correct answer?: ");
            int correctAnswer = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"You have selected: {listOfUserAnswers[correctAnswer - Constants.MINUS_ONE]} as a correct answer.");

            return correctAnswer;
        }
    }
}
