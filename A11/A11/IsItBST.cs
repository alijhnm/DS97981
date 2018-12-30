using System;
using TestCommon;
using System.Collections.Generic;

namespace A11
{
    public class IsItBST : Processor
    {
        public IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            Node[] madeNodes = new Node[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                Node node = new Node(nodes[i][0], nodes[i][1], nodes[i][2]);
                madeNodes[i] = node;
            }
            
            Tree tree = new Tree(madeNodes[0], madeNodes);
            long[] inOrderTraversal = tree.InOrderTraversal();
            List<long> inOrderList = new List<long>();
            List<long> tmp = new List<long>();
            
            for (int i = 0; i < inOrderTraversal.Length; i++)
            {
                inOrderList.Add(inOrderTraversal[i]);
                tmp.Add(inOrderTraversal[i]);
            }
            tmp.Sort();
            for (int i = 0; i < inOrderTraversal.Length - 1; i++)
            {
                if (inOrderTraversal[i] == inOrderTraversal[i + 1])
                {
                    return false;
                }
            }
            for (int i = 0; i < inOrderList.Count; i++)
            {
                if(inOrderList[i] != tmp[i])
                {
                    return false;
                }
            }
            return true;

        }
    }    
}
