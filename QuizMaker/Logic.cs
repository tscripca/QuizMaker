namespace QuizMaker
{
    public class Logic
    {
        public static List<string> SetAnswer()
        {
            List<string> myList = new List<string>();

            for (int answerCounter = 0; answerCounter <= 2; answerCounter++)
            {
                Console.WriteLine("Answer: ");
                string userAnswer = Console.ReadLine();
                myList.Add(userAnswer);
            }
            return myList;
        }      

        public static int VerifyCorrectAnswer(int myAnswerCheck)
        {
            Console.WriteLine("What is the correct answer?: ");
            int correctAnswer = Convert.ToInt32(Console.ReadLine());

            if (correctAnswer == myAnswerCheck)
            {
                Console.WriteLine("CORRECT!");
            }
            else
            {
                Console.WriteLine("INCORRECT!");
            }

            return correctAnswer;
        }
    }
}
