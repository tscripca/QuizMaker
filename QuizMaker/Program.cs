using System;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {

        static void Main(string[] args)
        {
            QnAClass myQuestions = new QnAClass();

            UIMethods.GetUserQnA(myQuestions);
        }
    }
}