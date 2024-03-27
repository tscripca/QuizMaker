using System;
using QuizMaker;

namespace QuizMaker
{
    public class QuizzCard()
    {
        public string userQuestion;
        public string userAnswer;
        public List<string> answersList = new List<string>();
        public int correctAnswer;

        public string GetQuestion()
        {
            Console.WriteLine("Type question: ");
            userAnswer = Console.ReadLine();
            return userAnswer;
        }

        public List<string> SetAnswer()
        {
            for(int answersCounter = 0; answersCounter <= 2; answersCounter++)
            {
                Console.WriteLine("Answer: ");
                userAnswer = Console.ReadLine();

                answersList.Add(userAnswer);
            }          

            return answersList;
        }

        public override string ToString()
        {
            return $"{userQuestion}, {answersList}, {userAnswer}";
        }
    }
}
