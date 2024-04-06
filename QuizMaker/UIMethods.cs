using System.Collections.Generic;
using QuizMaker;

namespace QuizMaker
{
    public class UIMethods
    {
        public string userQuestion;
        public static string GetQuestion(QnACard userQuestion)
        {
            Console.WriteLine("Type question: ");
            userQuestion = Console.ReadLine();
            return userQuestion;

            public override string ToString()
        {
            return $"{userQuestion}";
        }

    }
    }
}
