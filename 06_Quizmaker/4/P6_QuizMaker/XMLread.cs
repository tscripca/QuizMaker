using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace P6_QuizMaker
{
    internal class XMLread
    {
        [XmlRoot(ElementName = "Answers", Namespace = "")]
        public class Answers
        {

            [XmlElement(ElementName = "string", Namespace = "")]
            public List<string> String { get; set; }
        }

        [XmlRoot(ElementName = "Quiz", Namespace = "")]
        public class Quiz
        {

            [XmlElement(ElementName = "Topic", Namespace = "")]
            public string Topic { get; set; }

            [XmlElement(ElementName = "Question", Namespace = "")]
            public string Question { get; set; }

            [XmlElement(ElementName = "Answers", Namespace = "")]
            public Answers Answers { get; set; }
        }

        [XmlRoot(ElementName = "ArrayOfQuiz", Namespace = "")]
        public class ArrayOfQuiz
        {

            [XmlElement(ElementName = "Quiz", Namespace = "")]
            public List<Quiz> Quiz { get; set; }

            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }

            [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsd { get; set; }

            [XmlText]
            public string Text { get; set; }
        }


    }
}
