using QuizMaker;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
namespace QuizMaker
{
    public class QuizzGame
    {
        public string gameQuestion;
        public List<string> answersList = new List<string>();
        public int correctAnswer;
        private int _totalNumberOfQuestions;
        private int _answersXQuestion;
        public int TotalNumberOfQuestions
        {
            get
            {
                return _totalNumberOfQuestions;
            }
            set
            {
                UIMethods.ValidateUserInput(TotalNumberOfQuestions);
                _totalNumberOfQuestions = value;
            }
        }
        public int AnswersXQuestion
        {
            get
            {
                return _answersXQuestion;
            }
            set
            {
                UIMethods.ValidateUserInput(AnswersXQuestion);
                _answersXQuestion = value;
            }
        }
    }
    public enum GameMode
    {
        invalid,
        buildQuizz,
        playQuizz
    }
}