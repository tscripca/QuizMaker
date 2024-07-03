using System;
using System.IO;
using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace QuizMaker
{
    public class QuizzGame
    {
        public string quizzQuestion;
        public List<string> answersList = new List<string>();
        public int correctAnswer;
        public int listIndex;
    }
}