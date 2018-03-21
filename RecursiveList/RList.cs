using System;

namespace OOP_Concepts.RecursiveList
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
            while (n.next != null && n.next.next != null)
            {
                n = new Node(n.next.next);
                Console.Write(n.value + " -> ");
            }
            Console.WriteLine();
        }
        public int get(int[] num)
        {
            try
            {
                int element = get(root, 0, num[0]);
                Console.WriteLine(element);
                return element;
            }
            catch (ElementNotFoundException e)
            {
                Console.WriteLine("Element no found");
            }
            return 0;
        }
        public void set(int[] args)
        {
            try
            {
                set(root, 0, args[0], args[1]);
            }
            catch (ElementNotFoundException e)
            {
                Console.WriteLine("Element no found");
            }
        }
        public int this[int key]
        {
            get
            {
                int[] k = { key };
                return get(k);
            }
            set
            {
                int[] data = { key, value };
                set(data);
            }
        }
        private int get(Node n, int count, int num)
        {
            if (count == num)
                return n.value;

            if (n.next != null)
                return get(n.next, ++count, num);
            throw new ElementNotFoundException();
        }
        private void set(Node n, int count, int num, int value)
        {
            if (count == num)
            {
                n.value = value;
                return;
            }
            if (n.next == null)
                throw new ElementNotFoundException();
            set(n.next, ++count, num, value);
        }
        private float signedAverage(Node n, int sum, int count)
        {
            if (n.value < 0)
            {
                sum += n.value;
                ++count;
            }

            if (n.next == null) {
                try{
                    return sum / count;
                }
                catch (ArithmeticException e)
                {
                    return 0f;
                }
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