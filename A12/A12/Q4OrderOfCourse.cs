﻿using System;
using System.IO;
using System.Linq;
using TestCommon;
using System.Collections.Generic;
namespace A12
{
    public class Q4OrderOfCourse: Processor
    {
        public Q4OrderOfCourse(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);

        
        public long[] Solve(long nodeCount, long[][] edges)
        {
            List<List<long>> adjacents = new List<List<long>>();
            List<List<long>> revAdjecants = new List<List<long>>();
            for (int i = 0; i < nodeCount; i++)
            {
                adjacents.Add(new List<long>());
                revAdjecants.Add(new List<long>());
            }
            for (int i = 0; i < edges.Length; i++)
            {
                adjacents[(int)edges[i][0] - 1].Add(edges[i][1] - 1);
                revAdjecants[(int)edges[i][1] - 1].Add(edges[i][0] - 1);
            }
            List<long> topplogicalOrder = new List<long>();
            bool[] isChecked = new bool[nodeCount];
            while(topplogicalOrder.Count != nodeCount)
            {
                
                for (int i = 0; i < adjacents.Count; i++)
                {
                    if(adjacents[i].Count == 0 && !isChecked[i])
                    {
                        topplogicalOrder.Add(i + 1);
                        isChecked[i] = true;
                        for (int j = 0; j < revAdjecants[i].Count; j++)
                        {
                            adjacents[(int)revAdjecants[i][j]].Remove(i);
                        }
                    }
                }                
            }
            topplogicalOrder.Reverse();
            return topplogicalOrder.ToArray();
        }

        public override Action<string, string> Verifier { get; set; } = TopSortVerifier;

        /// <summary>
        /// کد شما با متد زیر راست آزمایی میشود
        /// این کد نباید تغییر کند
        /// داده آزمایشی فقط یک جواب درست است
        /// تنها جواب درست نیست
        /// </summary>
        public static void TopSortVerifier(string inFileName, string strResult)
        {
            long[] topOrder = strResult.Split(TestTools.IgnoreChars)
                .Select(x => long.Parse(x)).ToArray();

            long count;
            long[][] edges;
            TestTools.ParseGraph(File.ReadAllText(inFileName), out count, out edges);

            // Build an array for looking up the position of each node in topological order
            // for example if topological order is 2 3 4 1, topOrderPositions[2] = 0, 
            // because 2 is first in topological order.
            long[] topOrderPositions = new long[count];
            for (int i = 0; i < topOrder.Length; i++)
                topOrderPositions[topOrder[i] - 1] = i;
            // Top Order nodes is 1 based (not zero based).

            // Make sure all direct depedencies (edges) of the graph are met:
            //   For all directed edges u -> v, u appears before v in the list
            foreach (var edge in edges)
                if (topOrderPositions[edge[0] - 1] >= topOrderPositions[edge[1] - 1])
                    throw new InvalidDataException(
                        $"{Path.GetFileName(inFileName)}: " +
                        $"Edge dependency violoation: {edge[0]}->{edge[1]}");

        }
    }
}
