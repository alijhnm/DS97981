using System;
using TestCommon;
using System.Collections.Generic;
namespace A12
{
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
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
            Queue<long> queue = new Queue<long>();
            bool[] isChecked = new bool[nodeCount];
            isChecked[StartNode - 1] = true;
            for (int i = 0; i < adjacents[StartNode - 1].Count; i++)
            {
                queue.Enqueue(adjacents[StartNode - 1][i]);
            }
            while(queue.Count > 0)
            {
                long node = queue.Dequeue();
                if (node == EndNode - 1)
                {
                    return 1;
                }
                else
                {
                    if (!isChecked[node])
                    {
                        isChecked[node] = true;
                        for (int i = 0; i < adjacents[node ].Count; i++)
                        {
                            queue.Enqueue(adjacents[node][i]);
                        }
                    }
                }
            }
            return 0;
        }    
     }
}
