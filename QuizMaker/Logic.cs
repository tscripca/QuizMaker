namespace QuizMaker
{
    public class Logic
    {
        public List<string> SetAnswer()
        {
            List<string> QnAList = new List<string>();
            for (int answerCounter = 0; answerCounter <= 2; answerCounter++)
            {
                Console.WriteLine("Answer: ");
                string userAnswer = Console.ReadLine();
                QnAList.Add(userAnswer);
            }
            return QnAList;
        }

        public int StoreCorrectAnswer(List<string> listTocheck)
        {
            Console.WriteLine("Select the correct answer(0, 1, 2): ");
            int selectCorrectAnswer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Selected answer is: {listTocheck[selectCorrectAnswer]}");

            return selectCorrectAnswer;
        }

        public int VerifyCorrectAnswer(int myAnswerCheck)
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
