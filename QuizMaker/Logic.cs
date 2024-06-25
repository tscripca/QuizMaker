using System;
using System.IO;
using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace QuizMaker
{
    public class Logic
    {
        public XmlSerializer serializer = new XmlSerializer(typeof(List<QuizzGame>));
        /// <summary>
        /// Exports the object and saves it as an XML file.
        /// </summary>
        /// <param name="QnADeckToExport"></param>
        public static void ExportToDrive(List<QuizzGame> QnADeckToExport)
        {
            using (FileStream file = File.Create(Const.SAVED_PATH))
            {
                var writeDsk = new XmlSerializer(typeof(List<QuizzGame>));
                writeDsk.Serialize(file, QnADeckToExport);
            }
        }
        /// <summary>
        /// Loads the XML file into an object list.
        /// </summary>
        /// <returns>The object list</returns>
        public static List<QuizzGame> ImportFromDrive()
        {
            var importedQnADeck = new List<QuizzGame>();
            using (FileStream loadedFile = File.OpenRead(Const.SAVED_PATH))
            {
                var readFromDisk = new XmlSerializer(typeof(List<QuizzGame>));
                importedQnADeck = readFromDisk.Deserialize(loadedFile) as List<QuizzGame>;
            }
            return importedQnADeck;
        }        
    }
}
