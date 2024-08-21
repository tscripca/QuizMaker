using System.Xml.Serialization;

namespace QuizMaker
{
    public class BackUp
    {
        /// <summary>
        /// creates a backup repository for storing questions on harddrive
        /// </summary>
        /// <param name="quizCardRepository">List with all stored questions</param>
        /// <param name="writer">XmlSerializer Oject which writes backup</param>
        /// <param name="path">path where repository should be stored</param>
        public static void CreateRepositoryBackup(List<QuizCard> quizCardRepository, XmlSerializer writer, string path)
        {
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, quizCardRepository);
            }
        }
        /// <summary>
        /// gets a backup repository of stored questions from harddrive
        /// </summary>
        /// <param name="quizCardRepository">List with all stored questions</param>
        /// <param name="reader">XmlSerializer Oject which reads out backup</param>
        /// <param name="path">path where repository should be stored</param>
        /// <returns></returns>
        public static List<QuizCard> GetRepositoryBackup(List<QuizCard> quizCardRepository, XmlSerializer reader, string path)
        {
            using (FileStream file = File.OpenRead(path))
            {
                quizCardRepository = reader.Deserialize(file) as List<QuizCard>;
            }
            return quizCardRepository;

        }

    }
}
