namespace KeyLogger
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myQnACard = new QnACard();
            string myAnswer = " ";
            Console.WriteLine("Type question: ");
            myQnACard.gameQuestion = Console.ReadLine();
            Console.WriteLine("How many answers?: ");
            int numberOfAnswers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Answers: ");
            for (int i = 0; i < numberOfAnswers; i++)
            {
                myAnswer = Console.ReadLine();
                myQnACard.listOfAnswers.Add(myAnswer);
            }
            Console.WriteLine("Your answers are: ");
            foreach (string answer in myQnACard.listOfAnswers)
            {
                Console.WriteLine(answer);
            }
        }
    }
}