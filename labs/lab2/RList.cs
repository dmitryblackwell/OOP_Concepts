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
            Console.WriteLine("Recursion list: ");
            if(isNodeDefined)
                printRecursion(root);
            else
                Console.Write("null");
            Console.WriteLine("");
        }


        private void printRecursion(Node n)
        {
            if (n == null)
                return;
            Console.Write(n.value + " -> ");
            printRecursion(n.next);
        }
    }
}
