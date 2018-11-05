using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class FastLM
    {
        public readonly WordCount[] WordCounts;


        public FastLM(WordCount[] wordCounts)
        {
            this.WordCounts = wordCounts.OrderBy(wc => wc.Word).ToArray();
        }
        public static ulong BisectionSearch(WordCount[] wordCounts, string target)
        {
            long min = 0;
            long max = wordCounts.Length - 1;

            while (min <= max)
            {
                long mid = (min + max) / 2;
                WordCount A = wordCounts[mid];
                if (target == A.Word)
                {
                    return A.Count;
                }
                else if (string.Compare(target, A.Word) < 0)
                {
                    max = mid - 1;
                }
                else
                    min = mid + 1;
            }

            return 0;
        }
        public bool GetCount(string word, out ulong count)
        {

            count = BisectionSearch(WordCounts, word);
            if (count != 0)
            {
                return true;
            }
            return false;
        }
    }
}
