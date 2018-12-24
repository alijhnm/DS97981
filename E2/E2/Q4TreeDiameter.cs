using System;
using System.Collections.Generic;
using System.Linq;

namespace E2
{
    public class Q4TreeDiameter
    {
        /// <summary>
        /// ریشه همیشه نود صفر است.
        ///توی این آرایه در مکان صفر لیستی از بچه های ریشه موجودند.
        ///و در مکانه آی از این آرایه لیست بچه های نود آیم هستند
        ///اگر لیست خالی بود، بچه ندارد
        /// </summary>
        public List<int>[] Nodes;

        public Q4TreeDiameter(int nodeCount, int seed = 0)
        {
            Nodes = GenerateRandomTree(size: nodeCount, seed: seed);
            
        }

        public int TreeHeight()
        {
            List<Node> nodeList = new List<Node>();
            int nodeCount = Nodes.Length;
            for (int i = 0; i < nodeCount; i++)
            {
                nodeList.Add(new Node(Nodes[i], i));   
            }
            if (nodeList.Count == 15)
            {
                int a = 0;
            }
            Queue<int> q = new Queue<int>();
            Node root = nodeList[0];
            root.SetHeight(1);
            q.Enqueue(root.id);
            int height;
            int nextItemId = -1;
            while (q.Count() > 0)
            {
                nextItemId = q.Dequeue();
                height = nodeList[nextItemId].height;
                for (int i = 0; i < nodeList[nextItemId].children.Count(); i++)
                {
                    nodeList[nodeList[nextItemId].children[i]].SetHeight(height + 1);
                    q.Enqueue(nodeList[nodeList[nextItemId].children[i]].id);
                }
            }
            return nodeList[nextItemId].height;
        }

        public int TreeHeightFromNode(int node)
        {
            List<Node> nodeList = new List<Node>();
            int nodeCount = Nodes.Length;
            for (int i = 0; i < nodeCount; i++)
            {
                nodeList.Add(new Node(Nodes[i], i));
            }
            for (int i = 0; i < nodeList.Count; i++)
            {
                for (int j = 0; j < nodeList[i].children.Count; j++)
                {
                    nodeList[nodeList[i].children[j]].parrent = nodeList[i].id;
                }
            }
            Queue<int> q = new Queue<int>();
            nodeList[node].SetHeight(1);
            q.Enqueue(node);
            int height;
            int nextItemId = -1;
            List<int> checkList = new List<int>(0);
            while (q.Count() > 0)
            {
                nextItemId = q.Dequeue();
                height = nodeList[nextItemId].height;
                if (!checkList.Contains(nodeList[nodeList[nextItemId].parrent].id))
                {
                    nodeList[nodeList[nextItemId].parrent].SetHeight(height + 1);
                    q.Enqueue(nodeList[nodeList[nextItemId].parrent].id);
                    checkList.Add(nodeList[nodeList[nextItemId].parrent].id);
                }
                for (int i = 0; i < nodeList[nextItemId].children.Count(); i++)
                {
                    if (!checkList.Contains(nodeList[nodeList[nextItemId].children[i]].id))
                    {
                        nodeList[nodeList[nextItemId].children[i]].SetHeight(height + 1);
                        q.Enqueue(nodeList[nodeList[nextItemId].children[i]].id);
                        checkList.Add(nodeList[nodeList[nextItemId].children[i]].id);
                    }
                }
            }
            return nodeList[nextItemId].height;

        }

        public int TreeDiameterN2()
        {
            return 0;
        }

        public int TreeDiameterN()
        {
            return 0;
        }

        private static List<int>[] GenerateRandomTree(int size, int seed)
        {
            Random rnd = new Random(seed);
            List<int>[] nodes = Enumerable.Range(0, size)
                .Select(n => new List<int>())
                .ToArray();
            
            List<int> orphans = 
                new List<int>(Enumerable.Range(1, size-1)); // 0 is root it will remain orphan
            Queue<int> parentsQ = new Queue<int>();
            parentsQ.Enqueue(0);
            while (orphans.Count > 0)
            {
                int parent = parentsQ.Dequeue();
                int childCount = rnd.Next(1, 4);
                for (int i=0; i< Math.Min(childCount, orphans.Count); i++)
                {
                    int orphanIdx = rnd.Next(0, orphans.Count-1);
                    int orphan = orphans[orphanIdx];
                    orphans.RemoveAt(orphanIdx);
                    nodes[parent].Add(orphan);
                    parentsQ.Enqueue(orphan);
                }
            }
            return nodes;
        }
    }
}