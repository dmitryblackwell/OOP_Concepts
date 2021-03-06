﻿using System;

namespace OOP_Concepts.RecursiveList
{
    public partial class RList
    {
        private Node root;
        private bool isNodeDefined = false;
        private int length;

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
            Console.WriteLine(signedAverage(root, 0f, 0f));
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


        public int Length
        {
            get { return length; }
            set
            {
                if (value > length)
                {
                    int[] Zerros = new int[value - length+2];
                    //Array.Clear(Zerros, 0, Zerros.Length);
                    for (int i = 0; i < Zerros.Length; ++i)
                        Zerros[i] = 0;
                    toEnd(Zerros);
                    length = value;
                }
                if (value < length)
                {
                    if (value == 0)
                        clear();
                    else
                    {
                        cut(root, value, 0);
                        length = value;
                    }
                }

            }
        }


        private void cut(Node n,int newLength, int count)
        {
            if (count == newLength-1)
                n.next = null;
            else if (n.next != null)
                cut(n.next, newLength, ++count);
        }


        public int this[int key]                   // indexator         //here
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
        private float signedAverage(Node n, float sum, float count)
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

        // a and b - index of two elements
        public void swap(int a, int b)
        {
            try
            {
                int NodeA = get(root, 0, a);
                int NodeB = get(root, 0, b);

                set(root, 0, a, NodeB);
                set(root, 0, b, NodeA);
            }catch(ElementNotFoundException e)
            {
                Console.WriteLine("Element no found");
            }
        }

        private Node getNextNode(Node n, int count, int num)
        {
            if (num == -1)
                return root;

            if (count == num)
                return n.next;

            if (n.next != null)
                return getNextNode(n.next, ++count, num);
            throw new ElementNotFoundException();
        }
        private void setNextNode(Node n, int count, int num, Node next)
        {
            if (num == -1)
                root.next = next;

            if (count == num)
            {
                n.next = next;
                return;
            }
            if (n.next == null)
                throw new ElementNotFoundException();
            setNextNode(n.next, ++count, num, next);
        }

        private void setNextNode(int num, Node node)
        {
            setNextNode(root, 0, num, node);
        }
        private Node getNextNode(int n)
        {
            return getNextNode(root, 0, n);
        }


        // !!! this shit doesn't work
        // by I don't care, because it is not in documentation
        private void swapByLinks(int a, int b)
        {
            Node nA = getNextNode(a);
            Node nB = getNextNode(b);
            
            setNextNode(b, nA);
            setNextNode(a, nB);

            Node a_ = getNextNode(a - 1);
            Node b_ = getNextNode(b - 1);

            setNextNode(a - 1, b_);
            setNextNode(b - 1, a_);
        }

        private int get(int n)
        {
            return get(root, 0, n);
        }

        private void set(int index, int value)
        {
            set(new int[2] { index, value });
        }


        public void sort()  // selection sort
        {
            for (int i = 0; i < length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (get(j) < get(maxIndex))
                        maxIndex = j;
                }
                swap(i, maxIndex);
            }
        }
        
    }
}