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
            var randomPickedCard = new QuizzGame();
            var deckWithShuffledCards = new List<QuizzGame>();
            var importedQnADeck = new List<QuizzGame>();

            using (FileStream loadedFile = File.OpenRead(Const.SAVED_PATH))
            {
                var readFromDisk = new XmlSerializer(typeof(List<QuizzGame>));
                importedQnADeck = readFromDisk.Deserialize(loadedFile) as List<QuizzGame>;
                ShuffleCards(randomPickedCard, importedQnADeck, deckWithShuffledCards);
            }
            return deckWithShuffledCards;
        }
        public static void ShuffleCards(QuizzGame randomCard, List<QuizzGame> loadedFromDriveDeckOfCards, List<QuizzGame> deckOfMixedCards)
        {
            Random rng = new Random();
            bool allCardsAreInTheDeck = false;
            int myIndex = 0;
            while (!allCardsAreInTheDeck)
            {
                for (int i = 0; i < loadedFromDriveDeckOfCards.Count; i++)
                {
                    foreach (QuizzGame shuffledCard in loadedFromDriveDeckOfCards)
                    {
                        myIndex = rng.Next(loadedFromDriveDeckOfCards.Count);
                        randomCard = loadedFromDriveDeckOfCards[myIndex];
                        if (!deckOfMixedCards.Contains(randomCard))
                        {
                            deckOfMixedCards.Add(randomCard);
                        }
                    }
                    if (loadedFromDriveDeckOfCards.Count == deckOfMixedCards.Count)
                    {
                        allCardsAreInTheDeck = true;
                        break;
                    }
                }
            }
        }
    }
}
