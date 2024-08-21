using System.Xml.Serialization;


namespace P6_QuizMaker
{
    internal class XML
    {
        /// <summary>
        /// Converts the QuizCards into a plain text and exports the data locally
        /// </summary>
        /// <param name="quizDB"></param>
        public static void ExportFile(List<Quiz> quizDB)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            string username = Environment.UserName;
            using (StreamWriter writer = new StreamWriter($@"C:\Users\{username}\Downloads\QuizCards.xml"))
            {
                serializer.Serialize(writer, quizDB);
            }
        }

        public static void ImportFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfQuiz));
            using (StringReader reader = new StringReader(xml))
            {
                var test = (ArrayOfQuiz)serializer.Deserialize(reader);
            }
        }


    }
}
