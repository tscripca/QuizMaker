using System.Xml.Serialization;

namespace QuizMaker_RM
{
	public static class GameLogic
	{
		public const string PATH = "../../../QuizSheet.xml";
		static XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
        private static int currentScore;

		public static void WriteToXML(List<Quiz> quizList)
		{
			// writes our written quiz to our xml QuizSheet.xml
			using (FileStream file = File.OpenWrite(PATH))
			{
				serializer.Serialize(file, quizList);
			}

		}

		public static List<Quiz> ReadFromXML()
		{
			List<Quiz> quizList = new();

			using (FileStream file = File.OpenRead(PATH))
			{
				quizList = serializer.Deserialize(file) as List<Quiz>;
			}

			return quizList;
		}

		public static int GetScore()
		{
			return currentScore;
		}

		public static List<bool> CheckIfAnswerIsCorrect(Quiz quiz, List<int> currentAnswerToCheckIfCorrect)
		{
			List<bool> WinOrLoseResults = new();

			for (int answer = 0; answer < currentAnswerToCheckIfCorrect.Count; answer++)
			{
				if (answer < quiz.Answers.Count)
				{
					if (quiz.Answers[answer].Contains('*'))
					{
						WinOrLoseResults.Add(true);
					}
					else
					{
						WinOrLoseResults.Add(false);
					}

				}
				else
				{
					throw new ArgumentOutOfRangeException("Parameter is out of range.");
				}

			}

			return WinOrLoseResults;
		}

        public static void AddPoints()
		{
            currentScore += Constants.ADD_POINTS;
        }
		
	}
}