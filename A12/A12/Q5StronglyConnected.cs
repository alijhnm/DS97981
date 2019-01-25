using System;
using TestCommon;
using System.Collections.Generic;
using System.Linq;

namespace A12
{
    public class Q5StronglyConnected: Processor
    {
        public Q5StronglyConnected(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            List<long>[] adjacents = new List<long>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                adjacents[i] = new List<long>();
            }
            for (int i = 0; i < edges.Length; i++)
            {
                adjacents[edges[i][0] - 1].Add(edges[i][1] - 1);
            }
            List<List<long>> BfsResults = new List<List<long>>();
            for (int i = 0; i < nodeCount; i++)
            {
                BfsResults.Add(new List<long>());
            }
            bool[] isChecked = new bool[nodeCount];
            for (int node2 = 0; node2 < nodeCount; node2++)
            {
                Queue<long> queue = new Queue<long>();
                queue.Enqueue(node2);
                while (queue.Count > 0)
                {
                    long node = queue.Dequeue();    
                    if (!isChecked[node])
                    {
                        isChecked[node] = true;
                        for (int i = 0; i < adjacents[node].Count; i++)
                        {
                            if (node2 != adjacents[node][i])
                            {
                                BfsResults[node2].Add(adjacents[node][i]);
                            }
                            queue.Enqueue(adjacents[node][i]);
                        }
                    }
                    
                }
            }
            isChecked = new bool[nodeCount];
            long result = nodeCount;
            for (int j = 0; j < BfsResults.Count; j++)
            {
                if (!isChecked[j])
                {
                    for (int i = 0; i < BfsResults[j].Count; i++)
                    {
                        if (BfsResults[(int)BfsResults[j][i]].Contains(i))
                        {
                            result--;
                            isChecked[j] = true;
                        }
                    }
                }
            }
            return result;
        }
    }
}
