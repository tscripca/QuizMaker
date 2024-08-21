namespace QuizMaker
{
    internal class UI
    {
        /// <summary>
        /// Prints the welcome message to the console
        /// </summary>
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine(@"Welcome to THE QUIZMAKER!!!
All you need to play are: some friends to challenge (well not really, but I'm sure it's more fun with friends).
Let's get started");
        }

        /// <summary>
        /// Gives the user the option to have the instructions printed to console and then prints if the user wants to see them
        /// </summary>
        public static void PrintInstructions()
        {
            Console.WriteLine("Would you like to know how to play?\nY/N");
            string printInstructions = Console.ReadLine().ToLower();
            if (printInstructions == "y")
            {
                Console.WriteLine(@"There are two things you need to know:
1. How to answer questions: A question will show up on your screen, something like this:
Christmas is in December
1. True
2. False
Then you enter the number that corresponds to the answer you believe to be correct.
In this case we would enter 1
Finally, you will get a message that tells you if you are right or wrong.

2. How to add questions: If you choose to add questions to the list.
You will be prompted to: 'Please enter the question you would like to ask'
Then you enter the question: 'What month is Christmas in?'
Another prompt: 'How many answers would you like to provide?'
And you will enter a number like: '4'
Then you will be prompted to enter as many answers for your question as the number you provided.
In this case you would be asked four times to enter an answer:
'Now enter an answer'
'January'
'Now enter an answer'
'March'
'Now enter an answer'
'December'
'Now enter an answer'
'October'
Finally you will be asked to: 'enter the number correspoonding to the answer you gave that was correct'
In this case the number you woud enter would be '3' as December is the correct answer.");
            }
        }

        /// <summary>
        /// gives the user the option to add more questions
        /// </summary>
        /// <returns></returns>
        public static string ChoiceToAddQuestions()
        {
            Console.WriteLine("Would you like to add questions?\nY/N");
            string input = Console.ReadLine().ToLower();
            return input;
        }

        /// <summary>
        /// Asks the user to enter the question they want to ask
        /// </summary>
        /// <returns></returns>
        public static string CreateQuestion()
        {
            Console.WriteLine("Please enter the question you would like to ask");
            string question = Console.ReadLine();
            return question;
        }

        /// <summary>
        /// Asks the user for how many answers they would like to provide
        /// </summary>
        /// <returns></returns>
        public static int NumberOfAnswers()
        {
            Console.WriteLine("How many answers would you like to provide?");
            int answerCount = 0;
            while (answerCount <= 0)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (input.All(Char.IsNumber))
                {
                    answerCount = Convert.ToInt32(input);

                }
                else
                {
                    continue;
                }
            }
            return answerCount;
        }

        /// <summary>
        /// gets the user to provide answers
        /// </summary>
        /// <param name="answerCount"></param>
        /// <returns></returns>
        public static List<string> CreateAnswers(int answerCount)
        {
            List<string> answers = new List<string>();
            for (int j = 0; j < answerCount; j++)
            {
                Console.WriteLine("Now enter an answer");
                answers.Add(Console.ReadLine());
            }

            return answers;
        }

        /// <summary>
        /// gets the user to provide a number corresponding to the correct answer
        /// </summary>
        /// <returns></returns>
        public static int CreateCorrectAnswerIndex()
        {
            Console.WriteLine("Now enter the number correspoonding to the answer you gave that was correct");
            int correctAnswerIndex = 0;
            while (correctAnswerIndex <= 0)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (input.All(Char.IsNumber))
                {
                    correctAnswerIndex = Convert.ToInt32(input);

                }
                else
                {
                    continue;
                }
            }
            return correctAnswerIndex - 1;
        }

        /// <summary>
        /// prints a set of questions and answers to the console
        /// </summary>
        /// <param name="questionAndAnswers"></param>
        public static void PrintQuestionAndAnswers(QuestionAndAnswers questionAndAnswers)
        {
            Console.WriteLine();
            Console.WriteLine(questionAndAnswers.Question);
            for (int i = 0; i < questionAndAnswers.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {questionAndAnswers.Answers[i]}");
            }
        }

        /// <summary>
        /// Gets the input guess of the user
        /// </summary>
        /// <returns></returns>
        public static int GetGuess()
        {
            Console.WriteLine("Which answer do you think is correct?\nEnter the corresponding number.");
            int guess = 0;
            while (guess <= 0)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (input.All(Char.IsNumber))
                {
                    guess = Convert.ToInt32(input);

                }
                else
                {
                    continue;
                }
            }
            return guess - 1;
        }

        /// <summary>
        /// Tells the user whether their guess was correct or incorrect
        /// </summary>
        /// <param name="questionAndAnswers"></param>
        public static void PrintResultOfGuess(QuestionAndAnswers questionAndAnswers, bool resut)
        {
            if (resut)
            {
                Console.WriteLine("You are correct");
            }
            else
            {
                Console.WriteLine($"Sorry, that is not the correct answer, the correct answer was {questionAndAnswers.Answers[questionAndAnswers.CorrectAnswerIndex]}");
            }

        }

        /// <summary>
        /// Prints the users total score
        /// </summary>
        /// <param name="score"></param>
        /// <param name="questionsAsked"></param>
        public static void PrintScore(int score, int questionsAsked)
        {
            Console.WriteLine($"You got {score} out of {questionsAsked} questions right!!");
        }
    }
}
