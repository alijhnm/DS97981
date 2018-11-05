using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class SpellChecker
    {
        public readonly FastLM LanguageModel;

        public SpellChecker(FastLM lm)
        {
            this.LanguageModel = lm;
        }

        public string[] Check(string misspelling)
        {
            List<WordCount> candidates = 
                new List<WordCount>();

            string[] allCandidates = CandidateGenerator.GetCandidates(misspelling);
            for (long i = 0; i < allCandidates.Length; i++)
            {
                ulong result = FastLM.BisectionSearch(LanguageModel.WordCounts, allCandidates[i]);
                if (result > 0)
                {
                    candidates.Add(new WordCount(allCandidates[i], result));
                }
            }

            return candidates
                    .OrderByDescending(x => x.Count)
                    .Select(x => x.Word)
                    .Distinct()
                    .ToArray();
        }

        public string[] SlowCheck(string misspelling)
        {
            List<WordCount> candidates =
                new List<WordCount>();
            for (long i = 0; i < LanguageModel.WordCounts.Length; i++)
            {
                if (EditDistance(misspelling, LanguageModel.WordCounts[i].Word) <= 1)
                {
                    candidates.Add(LanguageModel.WordCounts[i]);
                }
            }
            
            return candidates
                    .OrderByDescending(x => x.Count)
                    .Select(x => x.Word)
                    .Distinct()
                    .ToArray();
        }
        
        public static int Min(int num1, int num2, int num3)
        {
            return Math.Min(Math.Min(num1, num2), num3);
        }

        public int EditDistance(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            int[,] Distance = new int[n + 1, m + 1];

            for (int i = 0; i < n + 1; i++)
            {
                Distance[i, 0] = i;

            }

            for (int j = 0; j < m + 1; j++)
            {
                Distance[0, j] = j;

            }

            for (int j = 1; j <= m; j++)
            {
                for (int i = 1; i <= n; i++)
                {
                    int insertion = Distance[i, j - 1] + 1;
                    int deletion = Distance[i - 1, j] + 1;
                    int match = Distance[i - 1, j - 1];
                    int mismatch = Distance[i - 1, j - 1] + 1;
                    if (str1[i - 1] == str2[j - 1])
                    {
                        Distance[i, j] = Min(insertion, deletion, match);
                    }
                    else
                    {
                        Distance[i, j] = Min(insertion, deletion, mismatch);
                    }
                }
            }
            return Distance[n, m];

        }
        
    }
}
