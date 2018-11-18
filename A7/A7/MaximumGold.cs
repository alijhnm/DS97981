using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximumGold : Processor
    {
        public MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long n = goldBars.Length;
            long[,] knapsackResults = new long[n + 1, W + 1];
            

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < W + 1; j++)
                {
                    knapsackResults[i, j] = knapsackResults[i - 1, j];
                    if (goldBars[i - 1] <= j)
                    {
                        long newValue = knapsackResults[i - 1, j - goldBars[i - 1]] + goldBars[i - 1];
                        if (newValue > knapsackResults[i, j])
                        {
                            knapsackResults[i, j] = newValue;
                        }
                    }

                }
            }
            return knapsackResults[n, W];
        }
    }
}
