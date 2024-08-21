using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace quizgame
{
    class UI
    {
        /// <summary>
        /// Simple welcome message
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello! This is a quiz game, let's do some smartening!");
        }

        /// <summary>
        /// Requesting a question and correct/incorrect answers from a user
        /// </summary>
        /// <returns>question and answers</returns>
        public static QuestionAndAnswer AddQuestion()
        {
            var questionAndAnswer = new QuestionAndAnswer();
            Console.WriteLine("Enter a question:");
            questionAndAnswer.Question = Console.ReadLine();
            bool wantToAdd = true;
            while (wantToAdd)
            {
                Console.Clear();
                QAPair x = new QAPair();
                Console.WriteLine("Enter an answer(right or wrong):");
                x.Answer = Console.ReadLine();
                Console.WriteLine("Is this the right answer?(y/n)");
                string isTheRightAnswer = Console.ReadLine();

                if (isTheRightAnswer == "y")
                {
                    x.isCorrect = true;
                }
                else
                {
                    x.isCorrect = false;
                }
                questionAndAnswer.QAPairs.Add(x);
                Console.WriteLine("Do you want to add more answers?(y/n)");
                string moreQuestion = Console.ReadLine();
                if(moreQuestion != "y")
                {
                    wantToAdd = false;
                }
                
                
            }
            Console.Clear();
            return questionAndAnswer;
        }

        /// <summary>
        /// Displaying the number of questions in the system
        /// </summary>
        /// <param name="count">number of questions</param>
        public static void CurrentQuestionNumber(int count)
        {
            Console.WriteLine($"There is {count} questions in my database!");
        }
        /// <summary>
        /// Ask the user if he wants to add a new question to the database
        /// </summary>
        /// <returns>Bool; y = true, else = false</returns>
        public static bool RequestAddingQuestion()
        {
            Console.WriteLine("Do you want to add a question to my database?(y/n)");
            string i = Console.ReadLine().ToLower();
            if (i == "y")
            {
                return true;
            }
            return false;
        }
        public static QAPair DisplayQuestion(List<QuestionAndAnswer> questionAndAnswers, int index)
        {
               
            Console.Clear();
            Console.WriteLine(questionAndAnswers[index].Question);
            for (int i = 0; i < questionAndAnswers[index].QAPairs.Count; i++)
            {
                QAPair answer = questionAndAnswers[index].QAPairs[i];
                Console.WriteLine($"{i}: {answer.Answer}");
            }
            Console.WriteLine("Please select the correct answer!");
            string select = Console.ReadLine();
            int selectedCase = Int32.Parse(select);
            QAPair selectedAnswer = questionAndAnswers[index].QAPairs[selectedCase];
            return selectedAnswer;
        }


        /// <summary>
        /// asking the user if he wants to play/play again
        /// </summary>
        /// <returns>y = true , else = false</returns>
        public static bool ContinueGame()
        {
            Console.WriteLine("Push the SpaceBar to get a question!");
            ConsoleKeyInfo answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Spacebar)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Message when getting points
        /// </summary>
        /// <param name="userScore">the current score of the user</param>
        public static void UserWonARound(int userScore)
        {
            if (userScore > 10)
            {
                Console.WriteLine($"Your answer was, again, correct! Wow! You have {userScore} points! NOOICE!");
            }
            Console.WriteLine($"You are correct! Your score currently is {userScore}");
        }
        /// <summary>
        /// Message when losing a point
        /// </summary>
        /// <param name="userScore">the current score of the user</param>
        public static void UserLostARound(int userScore)
        {
            Console.WriteLine($"You lost a point and now have {userScore} points");
        }


        /// <summary>
        /// If there's no questions in the file, the game cannot be played
        /// </summary>
        public static void NoQuestionsInTheDatabase()
        {
            Console.WriteLine("You cannot play as I have no questions, sorry :(");
        }

        public static void NoQuestionsLeft()
        {
            Console.WriteLine("As I ran out of questions, we have to stop now!");
        }
    }
}
