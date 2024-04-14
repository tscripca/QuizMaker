namespace QuizMaker
{
    public class Logic
    {
        public static List<string> SetAnswer()
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

        public static int CheckCorrectAnswer(List<string> listToCheck)
        {
            int i = 0;
            for(i = 0; i < listToCheck.Count; i++)
            {
                Console.WriteLine($"list contains {i} questions.");
            }
            return i;
        }
    }
}
