namespace QuizMaker
{
    public class UIMethods
    {
        public static string GetQuestion()
        {
            Console.WriteLine("Type question: ");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }
        public static int StoreCorrectAnswer(List<string> listTocheck)
        {
            Console.WriteLine("Select the correct answer(0, 1, 2): ");
            int selectCorrectAnswer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Selected answer is: {listTocheck[selectCorrectAnswer]}");

            return selectCorrectAnswer;
        }
    }
}
