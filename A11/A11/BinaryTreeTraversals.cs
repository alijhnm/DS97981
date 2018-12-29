using System;
using TestCommon;

namespace A11
{
    public class BinaryTreeTraversals : Processor
    {
        public BinaryTreeTraversals(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);


        public long[][] Solve(long[][] nodes)
        {

            Node[] madeNodes = new Node[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                Node node = new Node(nodes[i][0], nodes[i][1], nodes[i][2]);
                madeNodes[i] = node;
            }

            Tree tree = new Tree(madeNodes[0], madeNodes);
            long[] inOrderTraversal = tree.InOrderTraversal();
            long[] preOrderTraversal = tree.PreOrderTraversal();
            long[] postOrderTraversal = tree.PostOrderTraversal();
            long[][] result = new long[3][];

            result[0] = inOrderTraversal;
            result[1] = preOrderTraversal;
            result[2] = postOrderTraversal;
            return result;

        }
    }
}
