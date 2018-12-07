using System;
using TestCommon;
using System.Collections.Generic;
namespace A9
{
    public class ParallelProcessing : Processor
    {
        public ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public static long MinIndex(long[] array)
        {
            long minIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();
            long[] threads = new long[threadCount];
            for (long i = 0; i < Math.Min(threadCount, jobDuration.Length); i++)
            {
                result.Add(Tuple.Create(i, (long)0));
                threads[i] = jobDuration[i];
            }

            for (long i = Math.Min(threadCount, jobDuration.Length); i < jobDuration.Length; i++)
            {
                long minIndex = MinIndex(threads);
                result.Add(Tuple.Create(minIndex, threads[minIndex]));
                threads[minIndex] += jobDuration[i];
            }

            return result.ToArray();
        }
    }
}
