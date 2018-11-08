using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfThree: Processor
    {
        public LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public int Max(int num1, int num2, int num3, int num4)
        {
            return Math.Max(Math.Max(num1, num2), Math.Max(num3, num4));
        }

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            int n = seq1.Length;
            int m = seq2.Length;
            int p = seq3.Length;

            int[,,] Distance = new int[n + 1, m + 1, p + 1];

            for (int i = 0; i < n + 1; i++)
            {
                Distance[i, 0, 0] = 0;
            }

            for (int j = 0; j < m + 1; j++)
            {
                Distance[0, j, 0] = 0;
            }

            for (int k = 0; k < p + 1; k++)
            {
                Distance[0, 0, k] = 0;
            }

            for (int k = 1; k <= p; k++)
            {
                for (int j = 1; j <= m; j++)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        int res1 = Distance[i, j - 1, k];
                        int res2 = Distance[i - 1, j, k];
                        int res3 = Distance[i, j, k - 1];
                        int res4 = Distance[i - 1, j - 1, k - 1];

                        if (seq1[i - 1] == seq2[j - 1] && seq1[i - 1] == seq3[k - 1])
                        {
                            Distance[i, j, k] = res4 + 1;
                        }
                        else
                        {
                            Distance[i, j, k] = Max(res1, res2, res3, res4);
                        }
                    }
                }
            }
            return Distance[n, m, p];
        }
    }
}
