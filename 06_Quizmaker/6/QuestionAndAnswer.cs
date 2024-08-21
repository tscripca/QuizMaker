using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace quizgame
{
    [Serializable]
    public class QuestionAndAnswer 
    {
        public string Question;
        public List<QAPair> QAPairs = new List<QAPair>();
    }
}