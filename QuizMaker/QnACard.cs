using QuizMaker;

namespace QuizMaker
{
    public class QnACard
    {
        public string gameQuestion;
        public List<string> answersList = new List<string>();
        public int correctAnswer;

        public override string ToString()
        {
            return $"The list contains: {answersList}";
        }
    }
}
