using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchSideAssessment
{
    public class SevenCharacterWord : BaseWord
    {
        public override void Heighest(List<KeyValuePair<string, int>> pairList)
        {
            var sevenchar = pairList.Where(w => w.Key.Length == 7).OrderByDescending(o => o.Value).FirstOrDefault();

            Console.WriteLine("Most frequent 7-character: '{0}' occurred '{1}' times", sevenchar.Key, sevenchar.Value);

        }
    }
}
