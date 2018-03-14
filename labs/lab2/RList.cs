using System;

namespace labs.lab2
{
    public partial class RList
    {
        private Node root;
        private bool isNodeDefined = false;


        public RList()
        {
            root = new Node();
        }        

        
        public void print()
        {
            if(isNodeDefined)
                printRecursion(root);
            else
                Console.Write("null");
            Console.Write("\n");
        }


        private void printRecursion(Node n)
        {
            if (n == null)
                return;
            Console.Write(n.value + ( (n.next == null) ? "" : " -> " ) );
            printRecursion(n.next);
        }
    }
}
