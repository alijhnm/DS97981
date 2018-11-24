using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    public class Node
    {
        public long value;
        public List<Node> children = new List<Node>();
        public long height;


        public Node(long val)
        {
            this.value = val;
        }

        public void SetValue(long val)
        {
            this.value = val;
        }

        public void AddChild(Node n)
        {
            this.children.Add(n);
        }

        public void SetHeight(long n)
        {
            this.height = n ;
        }
    }
}
