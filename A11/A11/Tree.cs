using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    class Tree
    {
        public Node[] nodes;
        public Node root;
        
        public Tree(Node root, Node[] nodes)
        {
            this.root = root;
            this.nodes = nodes;
        }

        public long[] InOrderTraversal()
        {
            Stack<Node> nodesStack = new Stack<Node>();
            nodesStack.Push(root);
            List<long> result = new List<long>();
            while (nodesStack.Count != 0)
            {
                Node topNode = nodesStack.Peek();
                if (topNode.HasLeftChild() && topNode.leftChildConsidered == false)
                {
                    topNode.leftChildConsidered = true;
                    nodesStack.Push(nodes[topNode.leftChild]);
                }
                else if (topNode.HasLeftChild() && topNode.leftChildConsidered == true)
                {
                    result.Add(topNode.key);
                    nodesStack.Pop();
                    if (topNode.HasRightChild())
                    {
                        nodesStack.Push(nodes[topNode.rightChild]);
                    }
                }
                else
                {
                    result.Add(topNode.key);
                    nodesStack.Pop();
                    if (topNode.HasRightChild())
                    {
                        nodesStack.Push(nodes[topNode.rightChild]);
                    }
                }
            }
            return result.ToArray();
        }
        public bool IsBSTHard()
        {
            Stack<Node> nodesStack = new Stack<Node>();
            nodesStack.Push(root);
            List<long> result = new List<long>();

            while (nodesStack.Count != 0)
            {
                Node topNode = nodesStack.Peek();
                if (topNode.HasLeftChild() && topNode.leftChildConsidered == false)
                {
                    if (topNode.key <= nodes[topNode.leftChild].key)
                    {
                        return false;
                    }
                    topNode.leftChildConsidered = true;
                    nodesStack.Push(nodes[topNode.leftChild]);
                }
                else if (topNode.HasLeftChild() && topNode.leftChildConsidered == true)
                {
                    result.Add(topNode.key);
                    nodesStack.Pop();
                    if (topNode.HasRightChild())
                    {
                        nodesStack.Push(nodes[topNode.rightChild]);
                    }
                }
                else
                {
                    result.Add(topNode.key);
                    nodesStack.Pop();
                    if (topNode.HasRightChild())
                    {
                        nodesStack.Push(nodes[topNode.rightChild]);
                    }
                }
            }
            List<long> inOrderList = new List<long>();
            List<long> tmp = new List<long>();

            for (int i = 0; i < result.Count; i++)
            {
                inOrderList.Add(result[i]);
                tmp.Add(result[i]);
            }
            for (int i = 0; i < inOrderList.Count - 2; i++)
            {
                if (inOrderList[i] == inOrderList[i + 1] && inOrderList[i + 1] == inOrderList[i + 2])
                {
                    return false;
                }
            }
            tmp.Sort();
            for (int i = 0; i < inOrderList.Count; i++)
            {
                if (inOrderList[i] != tmp[i])
                {
                    return false;
                }
            }
            return true;

        }

        public long[] PreOrderTraversal()
        {
            List<long> result = new List<long>();
            Stack<Node> nodesStack = new Stack<Node>();
            nodesStack.Push(root);

            while (nodesStack.Count() != 0)
            {
                Node topNode = nodesStack.Pop();
                result.Add(topNode.key);

                if (topNode.HasRightChild())
                {
                    nodesStack.Push(nodes[topNode.rightChild]);
                }
                if (topNode.HasLeftChild())
                {
                    nodesStack.Push(nodes[topNode.leftChild]);
                }
                
            }
            return result.ToArray();
        }
        public long[] PostOrderTraversal()
        {
            List<long> result = new List<long>();
            Stack<Node> nodesStack = new Stack<Node>();
            nodesStack.Push(root);

            while (nodesStack.Count() != 0)
            {
                Node TopNode = nodesStack.Pop();
                result.Add(TopNode.key);
                if (TopNode.HasLeftChild())
                {
                    nodesStack.Push(nodes[TopNode.leftChild]);
                }
                if (TopNode.HasRightChild())
                {
                    nodesStack.Push(nodes[TopNode.rightChild]);
                }
            }
            result.Reverse();
            return result.ToArray();
        }
    }
}
