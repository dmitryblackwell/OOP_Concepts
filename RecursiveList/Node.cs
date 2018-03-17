using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Concepts.RecursiveList
{
    class Node
    {
        public int value;
        public Node next;

        public Node(int v, Node n)
        {
            value = v;
            next = n;
        }

        public Node(int v) : this(v, null) { }
        public Node(): this(0, null) { }
        public Node(Node n) : this(n.value, n.next) { } 
    }
}
