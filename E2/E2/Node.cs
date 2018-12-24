using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2
{
    class Node
    {
        public List<int> children;
        public int height ;
        public int id;
        public int parrent = -1;

        public Node(List<int> children, int id)
        {
            this.children = children;
            this.id = id;
        }
        
        public void SetHeight(int h)
        {
            this.height = h;
        }
    }
}
