using System;
using TestCommon;
using System.Linq;
using System.Collections.Generic;
namespace A9
{
    public class MergingTables : Processor
    {
        public MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public static long MaxSize(long[] sizes)
        {
            long maxSize = long.MinValue;
            for (long i = 0; i < sizes.Length; i++)
            {
                if (sizes[i] > maxSize)
                {
                    maxSize = sizes[i];
                }
            }
            return maxSize;
        }

        public static void Merge(long[] tableSizes, long[] symLinks, long source, long destination)
        {
            if (source == destination)
            {
                return;
            }
            else
            {
                if (tableSizes[source] != -1)
                {
                    if (tableSizes[destination] != -1)
                    {
                        tableSizes[destination] += tableSizes[source];
                        tableSizes[source] = -1;
                        symLinks[source] = destination;
                    }
                    else
                    {
                        destination = symLinks[destination];
                        Merge(tableSizes, symLinks, source, destination);
                    }
                }
                else
                {
                    source = symLinks[source];
                    Merge(tableSizes, symLinks, source, destination);
                }
            }
        }

        public long[] Solve(long[] tableSizes, long[] sourceTables, long[] targetTables)
        {
            
            long[] symLinks = new long[tableSizes.Length];
            List<long> result = new List<long>();

            for (int i = 0; i < symLinks.Length; i++)
            {
                symLinks[i] = -1;
            }

            long maxSize = tableSizes.Max();
            for (long tableIndex = 0; tableIndex < sourceTables.Length ; tableIndex++)
            {
                Merge(tableSizes, symLinks, sourceTables[tableIndex] - 1, targetTables[tableIndex] - 1);
                result.Add(tableSizes.Max());
            }

            return result.ToArray();
        }
    }
}