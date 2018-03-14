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
        public void signedAverage()
        {
            Console.WriteLine(signedAverage(root, 0, 0));
        }
        public void printOdd()
        {
            if (!isNodeDefined)
                return;
            
            Node n = root;
            Console.Write(n.value + ((n.next.next == null) ? "" : " -> "));
            while (n.next.next != null)
            {
                n = new Node(n.next.next);
                Console.Write(n.value + ((n.next.next == null) ? "" : " -> "));
            }
        }

        private float signedAverage(Node n, int sum, int count)
        {
            if (n.next == null) {
                try{
                    return sum / count;
                }
                catch (ArithmeticException e)
                {
                    return 0f;
                }
            }

            if (n.value < 0)
            {
                sum += n.value;
                ++count;
            }
            return signedAverage(n.next, sum, count);
            
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
