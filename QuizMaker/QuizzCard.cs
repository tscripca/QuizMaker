using System;
using QuizMaker;

namespace QuizMaker
{
    public class QuizzCard()
    {
        public string userQuestion;
        public string userAnswer;
        public List<QuizzCard> answersList;
        public int correctAnswer;

        public string GetQuestion()
        {
            Console.WriteLine("Type question: ");
            userQuestion = Console.ReadLine();
            return userQuestion.ToString();
        }

        public string SetAnswer()
        {
            Console.WriteLine("Answer: ");
            userAnswer = Console.ReadLine();
            return userAnswer.ToString();
        }

        public override string ToString()
        {
            return $"{userQuestion}, {answersList}, {userAnswer}";
        }
    }
}
