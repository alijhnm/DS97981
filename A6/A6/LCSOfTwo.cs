using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfTwo: Processor
    {
        public LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public int Max(int num1, int num2, int num3)
        {
            return Math.Max(Math.Max(num1, num2), num3);
        }

        public long Solve(long[] seq1, long[] seq2)
        {
            int n = seq1.Length;
            int m = seq2.Length;

            int[,] Distance = new int[n + 1, m + 1];

            for (int i = 0; i < n + 1; i++)
            {
                Distance[i, 0] = 0;

            }

            for (int j = 0; j < m + 1; j++)
            {
                Distance[0, j] = 0;

            }

            for (int j = 1; j <= m; j++)
            {
                for (int i = 1; i <= n; i++)
                {
                    int insertion = Distance[i, j - 1];
                    int deletion = Distance[i - 1, j];
                    int match = Distance[i - 1, j - 1];
                    if (seq1[i - 1] == seq2[j - 1])
                    {
                        Distance[i, j] = match + 1;
                    }
                    else
                    {
                        Distance[i, j] = Max(insertion, deletion, match);
                    }
                }
            }
            return Distance[n, m];
        }
    }
}
