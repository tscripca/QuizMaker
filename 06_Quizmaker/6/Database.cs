using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace quizgame
{
    public static class Database
    {
        private static List<QuestionAndAnswer> _questionAndAnswers = new List<QuestionAndAnswer>();

        /// <summary>
        /// randomizing the list
        /// </summary>
        /// <returns>The shuffled questions and answers</returns>
        public static List<QuestionAndAnswer> ShuffledQuestionList() 
        {
            List<QuestionAndAnswer> x = new List<QuestionAndAnswer>();
            var rnd = new Random();
    
            x = _questionAndAnswers.OrderBy(x => rnd.Next(0,_questionAndAnswers.Count)).ToList();
         
            return x;
        }

        /// <summary>
        /// returns the number of questions in the game
        /// </summary>
        public static int QuestionCount
        {
            get
            {
                return _questionAndAnswers.Count;
            }
        }


        /// <summary>
        /// Contains the name of the file containing the questions
        /// </summary>
        private static string _questionFile = "Database.xml";

        /// <summary>
        /// Check if the Database file exists. If not, creates it.
        /// </summary>
        public static void CheckOrCreateDatabase()  
        {
            if (File.Exists(_questionFile))
            {
                return;
            }
            var filestream = File.Create(_questionFile);
            filestream.Close();
        }
        /// <summary>
        /// Adding questions and answers to the Database
        /// </summary>
        /// <param name="questionAndAnswers">Question and answers list</param>
        public static void Save()
        {
            var stream = new FileStream(_questionFile, FileMode.Create);
            new XmlSerializer(typeof(List<QuestionAndAnswer>)).Serialize(stream, Database._questionAndAnswers);
            stream.Close();
        }
        /// <summary>
        /// Putting the questions into the list
        /// </summary>
        /// <returns>Question and Answers object</returns>
        public static void Read()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<QuestionAndAnswer>));
            TextReader reader = new StreamReader(_questionFile);
            object obj = deserializer.Deserialize(reader);
            _questionAndAnswers = (List<QuestionAndAnswer>)obj;
            reader.Close();
        }


        /// <summary>
        /// Adding a QuestionAndAnswers object to the list _questionAndAnswers
        /// </summary>
        /// <param name="questionAndAnswer"></param>
        public static void AddQuestionToList(QuestionAndAnswer questionAndAnswer)
        {
            _questionAndAnswers.Add(questionAndAnswer);
        }
    }
}
