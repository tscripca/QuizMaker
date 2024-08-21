using System;
using System.Collections.Generic;

namespace QuizMaker
{
    [Serializable]
    public class QnA
    {
        public string Question { get; set; } = null;
        public List<string> Answers { get; set; } = new();
        public int? CorrectAnswer { get; set; } = null;

    }
}
