using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    class Node
    {

        public long leftChild;
        public long rightChild;
        public long key;
        public bool leftChildConsidered;
        public bool rightChildConsidered;

        public Node(long key)
        {
            this.key = key;
        }

        public Node(long key, long leftChild, long rightChild)
        {
            this.key = key;
            this.rightChild = rightChild;
            this.leftChild = leftChild;
        }

        public bool HasLeftChild()
        {
            return leftChild != -1;
        }

        public bool HasRightChild()
        {
            return rightChild != -1;
        }
    }
}
