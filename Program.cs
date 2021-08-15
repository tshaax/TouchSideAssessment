using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TouchSideAssessment
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(@"Please type the file path .e.g.'C:\file.txt'");
            string inputKey = Console.ReadLine();
            ProcessFile($@"{inputKey}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public static void ProcessFile(string fileName)
        {
            // Check the file path contains valid text file.
            ValidateFile(fileName);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            string pattern = @"[^a-zA-Z0-9'\- ]";

            //read  file content 
            using TextReader reader = File.OpenText(fileName);
            string line = reader.ReadLine();
            while (line != null)
            {
                string cleanedLine = Regex.Replace(line, pattern, string.Empty).ToLowerInvariant();
                string[] words = cleanedLine.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];
                    if (!string.IsNullOrEmpty(word))
                    {
                        int frequency = 1;
                        if (wordCounts.ContainsKey(word))
                        {
                            frequency = wordCounts[word] + 1;
                        }

                        wordCounts[word] = frequency;
                    }
                }

                line = reader.ReadLine();
            }

            //sort words based on frequency
            List<KeyValuePair<string, int>> pairList = new List<KeyValuePair<string, int>>(wordCounts);
            pairList.Sort((first, second) => { return second.Value.CompareTo(first.Value); });


            //print the results 
            BaseWord coutWordFrq = new WordFrequency();
            coutWordFrq.Heighest(pairList);

            BaseWord coutSevenChar =  new SevenCharacterWord();
            coutSevenChar.Heighest(pairList);

            BaseWord coutHighest = new HighestScoreWord();
            coutHighest.Heighest(pairList);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private static void ValidateFile(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName", "You must specify a file");
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Could not find the specified file.", fileName);
            }

            if (fi.Extension.ToLower() != ".txt")
            {
                throw new FileLoadException("Could not load the specified file, only txt files accepted.", fileName);
            }
        }


    }


}
