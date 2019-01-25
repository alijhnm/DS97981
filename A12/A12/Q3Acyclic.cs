using System;
using TestCommon;
using System.Collections.Generic;
namespace A12
{
    public class Q3Acyclic : Processor
    {
        public Q3Acyclic(string testDataName) : base(testDataName) { }

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
            Stack<long> stack = new Stack<long>();
            for (int node = 0; node < nodeCount; node++)
            {
                bool[] isChecked = new bool[nodeCount];
                
                for (int i = 0; i < adjacents[node].Count; i++)
                {
                    stack.Push(adjacents[node][i]);
                }
                while (stack.Count > 0)
                {
                    long node2 = stack.Pop();
                    isChecked[node2] = true;
                    if (node == node2)
                    {
                        return 1;
                    }
                    for (int i = 0; i < adjacents[node2].Count; i++)
                    {
                        if (!isChecked[adjacents[node2][i]])
                        {
                            stack.Push(adjacents[node2][i]);
                        }
                    }
                }
            }
            return 0;
        }
    }
}