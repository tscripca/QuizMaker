namespace QuizMaker
{
    internal class UserInterface
    {
        public static void GameIntroMessage()
        {
            Console.WriteLine("Welcome to QuizMaker");
        }

        public static void GameStartMessage()
        {
            Console.WriteLine("\n****** Ok, lets start the game ******\n");
        }
        /// <summary>
        /// console option between playing the game or build new game questions
        /// </summary>
        /// <returns>user input</returns>
        public static int CreateOrPlayMessage()
        {
            int createOrPlay = 0;
            bool validInput = false;

            while (validInput == false)
            {
                Console.Write("If you want to play press(1), if you want to create new questions press(2)\t");
                validInput = int.TryParse(Console.ReadLine(), out createOrPlay);

                if (createOrPlay <= 0 || createOrPlay > 2)
                {
                    Console.WriteLine("You can only play the game(1) or create a new question(2)");
                    validInput = false;
                }
            }
            return createOrPlay;
        }

        public static string AskForQuestion()
        {
            Console.WriteLine("Pls give me any question");
            string question = Console.ReadLine();
            return question;
        }

        public static string AskForRightAnswer()
        {
            Console.WriteLine("Pls put in the right answer");
            string rightAnswer = Console.ReadLine();
            return rightAnswer;
        }

        public static string AskForWrongAnswer()
        {
            Console.WriteLine("Pls put in a wrong answer");
            string wrongAnswer = Console.ReadLine();
            return wrongAnswer;
        }
        /// <summary>
        /// console option to create more game questions 
        /// </summary>
        /// <returns>true or false</returns>
        public static bool CreateOneMoreQuizcard()
        {
            bool createOneMoreQuiscard = true;

            Console.WriteLine("If you want to create one more question press 'Y':\t");

            string userInput = Console.ReadLine().ToUpper();

            if (userInput != "Y")
            {
                createOneMoreQuiscard = false;
            }
            return createOneMoreQuiscard;
        }
        /// <summary>
        /// prints a game question on console
        /// </summary>
        /// <param name="gameQuestion">question object</param>
        /// <returns>position of right answer</returns>
        public static int ShowGameQuestion(QuizCard gameQuestion)
        {
            Console.WriteLine($"\n{gameQuestion.question}");

            Random answerRotation = new Random();
            List<string> allAnswers = gameQuestion.allAnswers;

            int displayPos = 1;
            int rightAnswerPos = 0;


            while (allAnswers.Count > 0)
            {
                string rightAnswer = gameQuestion.rigthAnswer;

                int answerPosition = answerRotation.Next(allAnswers.Count);
                Console.WriteLine($"{displayPos}) {allAnswers[answerPosition]}");

                if (rightAnswer == allAnswers[answerPosition])
                {
                    rightAnswerPos = displayPos;
                }
                allAnswers.RemoveAt(answerPosition);
                displayPos++;
            }
            return rightAnswerPos;
        }
        /// <summary>
        /// prints question answers on console in random order
        /// </summary>
        /// <param name="gameQuestion">question object</param>
        /// <param name="MAX_WRONG_QUESTION_ANSWERS">number of max wrong answers for each question</param>
        /// <returns>user input</returns>
        public static int ShowQuestionAnswers(QuizCard gameQuestion, int MAX_WRONG_QUESTION_ANSWERS)
        { 
            int userAnswer = 0;
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Choose your answer:\t");
                validInput = int.TryParse(Console.ReadLine(), out userAnswer);

                if (userAnswer <= 0 || userAnswer > (MAX_WRONG_QUESTION_ANSWERS+1))
                {
                    Console.WriteLine($"Only answers between 1-{MAX_WRONG_QUESTION_ANSWERS+1} are aviable!!!");
                    validInput = false;
                }
            }
            return userAnswer;
        }

        public static void resultMessage (int rightAnswerCounter, int MAX_GAME_QUESTIONS)
        {
            Console.WriteLine($"\nCratulation, you have answered {rightAnswerCounter}/{MAX_GAME_QUESTIONS} questions correctly");
        }
    }
}
