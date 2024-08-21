namespace QuizMaker_RM
{
	public class Quiz
	{
		public string quizQuestion;
		public List<string> Answers = new List<string>();
        private static char[] asterisk = { '*' };
        public override string ToString()
		{
			
			string joinedStrings = "";

			for (int answersIndex = 0; answersIndex < Answers.Count; answersIndex++)
			{
				string trimmedString = Answers[answersIndex].Trim(asterisk);

				joinedStrings += $"\n{answersIndex + 1}. {trimmedString}";
                if (answersIndex <= Answers.Count -1)
                {
                    joinedStrings += ", ";
                }
            }
			return $"{quizQuestion} \nAnswers:{joinedStrings}";

		}

	}

}