using System;

namespace QuizMaker
{
    public class QuizzCard()
    {
        public string userQuestion;
        public string userAnswer;
        public List<QuizzCard> answersList;
        public int correctAnswer;        

        public override string ToString()
        {
            return $"{userQuestion}, {answersList}, {userAnswer}";
        }
    }
}
