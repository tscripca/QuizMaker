namespace QuizMaker
{
    public class UIMethods
    {
        public string GetQuestion()
        {
            Console.WriteLine("Type question: ");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }
    }
}
