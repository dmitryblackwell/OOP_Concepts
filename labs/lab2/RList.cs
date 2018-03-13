using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs.lab2
{
    class RList
    {
        private Node root;
        private bool isNodeDefined = false;
        public RList()
        {
            root = new Node();
        }        

        public void add(int[] ValuePack)
        {
            isNodeDefined = true;
            addRecursion(root, ValuePack, 0);
        }
        public void clear()
        {
            Console.WriteLine("Are you sure you want to delete all elements? [y/n]");
            String answer = Console.ReadLine();
            if (answer.Equals("y") || answer.Equals("Y"))
                root.next = null;
            isNodeDefined = false;
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

        private void addRecursion(Node n, int[] ValuePack,int index)
        {

            n.value = ValuePack[index];
            index++;

            if (index < ValuePack.Length-1)
            {
                n.next = new Node();
                Console.WriteLine("New node created: " + index);
                addRecursion(n.next, ValuePack, index);
            }
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
