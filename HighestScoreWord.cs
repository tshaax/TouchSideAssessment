using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchSideAssessment
{
    public class HighestScoreWord : BaseWord
    {
        public override void Heighest(List<KeyValuePair<string, int>> pairList)
        {
            Dictionary<string, int> letterCounts = new Dictionary<string, int>();

            for (int i = 0; i < pairList.Count; i++)
            {
                KeyValuePair<string, int> pair = pairList[i];
                char[] charLetters = pair.Key.ToCharArray();
                int totalScore = 0;
                for (int j = 0; j < charLetters.Length; j++)
                {
                    char letter = charLetters[j];
                    totalScore += LetterScore(letter.ToString());
                }

                letterCounts[pair.Key] = totalScore;

            }

            var highScoreletter = letterCounts.OrderByDescending(o => o.Value).FirstOrDefault();

            Console.WriteLine($"Highest scoring word(s) (according to the score table): '{highScoreletter.Key}' with a score of '{highScoreletter.Value}' ");
        }

        private static int LetterScore(string letter)
        {
            Dictionary<string, int> letterScores = new Dictionary<string, int>
            {
                { "A", 1 },
                { "B", 3 },
                { "C", 3 },
                { "D", 2 },
                { "E", 1 },
                { "F", 4 },
                { "G", 2 },
                { "H", 4 },
                { "I", 1 },
                { "J", 8 },
                { "K", 5 },
                { "L", 1 },
                { "M", 3 },
                { "N", 1 },
                { "O", 1 },
                { "P", 3 },
                { "Q", 10 },
                { "R", 1 },
                { "S", 1 },
                { "T", 1 },
                { "U", 1 },
                { "V", 4 },
                { "W", 4 },
                { "X", 8 },
                { "Y", 4 },
                { "Z", 10 }
            };

            letterScores.TryGetValue(letter.ToUpper(), out int score);

            return score;
        }
    }
}
