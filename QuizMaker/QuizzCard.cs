using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using QuizMaker;

namespace QuizMaker
{
    public class QuizzCard
    {
        public string userQuestion;
        public string userAnswers;
        public int correctAnswer;

        private string _Question;
        private string _Answer; 

        public string GetQuestion
        {
            get
            {
                LogicMethods.GetUserQuestion();
                return GetQuestion;
            }
            set
            {
                LogicMethods.SetUserAnswer();
            }
        }

        public string SetAnswer
        {
            get
            {
                LogicMethods.SetUserAnswer();
                return _Answer;
            }
            set
            {
                _Answer = value;
            }
        }
    }    
}
