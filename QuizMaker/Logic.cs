﻿using QuizMaker;
using System.Collections.Generic;

namespace QuizMaker
{
    public class Logic
    {
        public static List<string> SetAnswer()
        {
            List<string> answerList = new List<string>();

            for (int answerCounter = 0; answerCounter <= 2; answerCounter++)
            {
                Console.WriteLine("Answer: ");
                string userAnswer = Console.ReadLine();  
                
                answerList.Add(userAnswer);
            }
            return answerList.ToList();
        } 
    }
}
