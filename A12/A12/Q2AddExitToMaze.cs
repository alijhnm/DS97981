using System;
using TestCommon;
using System.Collections.Generic;
namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

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
                adjacents[edges[i][1] - 1].Add(edges[i][0] - 1);
            }
            Stack<long> stack = new Stack<long>();
            bool[] isChecked = new bool[nodeCount];
            long CCCount = 0;

            for (int node = 0; node < nodeCount;  node++)
            {
                if (!isChecked[node])
                {
                    CCCount++;
                    isChecked[node] = true;
                    for (int i = 0; i < adjacents[node].Count; i++)
                    {
                        stack.Push(adjacents[node][i]);
                    }
                    while (stack.Count > 0)
                    {
                        long node2 = stack.Pop();                       
                        if (!isChecked[node2])
                            {
                            isChecked[node2] = true;
                            for (int i = 0; i < adjacents[node2].Count; i++)
                            {
                                stack.Push(adjacents[node2][i]);
                            }
                        }
                       
                    }
                }
                
            }
            return CCCount;
        }
    }
}
