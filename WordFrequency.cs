using System;
using System.Collections.Generic;
using System.Text;

namespace TouchSideAssessment
{
    public class WordFrequency : BaseWord
    {
        public override void Heighest(List<KeyValuePair<string, int>> pairList)
        {
            Console.WriteLine("Most frequent word: '{0}' occurred '{1}' times", pairList[0].Key, pairList[0].Value);

        }
    }
}
