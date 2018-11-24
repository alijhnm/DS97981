using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class TreeHeight : Processor
    {
        public TreeHeight(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            List<Node> nodeList = new List<Node>();
            for (int i = 0; i < nodeCount; i++)
            {
                nodeList.Add(new Node(i));
            }

            long rootValue = -1;
            Queue<Node> q = new Queue<Node>();
            for (int i = 0; i < tree.Length; i++)
            {
                if (tree[i] == -1)
                {
                    rootValue = i;
                }
                else
                {
                    nodeList[(int)tree[i]].AddChild(nodeList[i]);
                }
            }
            Node root = nodeList[(int)rootValue];
            root.SetHeight(1);
            q.Enqueue(root);
            long height;
            Node nextItem = new Node(-1);
            while (q.Count() > 0)
            {
                nextItem = q.Dequeue();
                height = nextItem.height;
                for (int i = 0; i < nextItem.children.Count(); i++)
                {
                    nextItem.children[i].SetHeight(height + 1);
                    q.Enqueue(nextItem.children[i]);
                }
            }
            return nextItem.height;
        }
        
    }
}
