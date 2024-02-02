using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using QuizMaker;

namespace QuizMaker
{
    internal class UIMethods
    {
        public static string GetUserQnA(QnAClass myQuestions)
        {
            bool userWillType = true;

            while (userWillType)
            {
                Console.WriteLine("Type question: ");
                myQuestions.userQuestion = Console.ReadLine();
                Console.WriteLine("Give answer: ");
                myQuestions.userAnswer = Console.ReadLine();
                SerializerClass.StoreQnA(myQuestions);
                Console.WriteLine("Would you like to type another question?");
                string userWantsToContinue = Console.ReadLine();
                if (userWantsToContinue == "yes")
                    userWillType = true;
                else
                    userWillType = false;
            }
            return myQuestions.ToString();            
        }
    }
}
