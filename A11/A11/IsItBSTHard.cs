using System;
using TestCommon;
using System.Collections.Generic;

namespace A11
{
    public class IsItBSTHard : Processor
    {
        public IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            if (nodes.Length == 0)
            {
                return true;
            }

            Node[] madeNodes = new Node[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                Node node = new Node(nodes[i][0], nodes[i][1], nodes[i][2]);
                madeNodes[i] = node;
            }
            Tree tree = new Tree(madeNodes[0], madeNodes);
            return tree.IsBSTHard();

        }
    }
}
