using System;

namespace OOP_Concepts.RecursiveList
{
    public partial class RList
    {
        public void clear()
        {
            Console.WriteLine("Are you sure you want to delete all elements in list? [y/n]");
            String answer = Console.ReadLine();
            if (answer.Equals("y") || answer.Equals("Y"))
                root.next = null;
            isNodeDefined = false;
        }
        public void deleteOne(int value)
        {
            if (root.value == value)
            {
                if (root.next != null)
                    root = new Node(root.next);
                else
                    clear();
            }
            else
                deleteElement(root, value,true);
        }
        public void deleteAll(int value)
        {
            deleteElement(root, value, false);
        }
        public void deleteEven()
        {
            deleteEven(root);
        }


        private void deleteEven(Node n)
        {
            if (n.next == null)
                return;
            else if (n.next.next == null)
                n.next = null;
            else
            {
                n.next = new Node(n.next.next);
                deleteEven(n.next);
            }
        }
        private void deleteElement(Node n,int value, bool isOne)
        {
            if (n.next == null)
                return;

            while (n.next.value == value)
            {
                if (n.next.next == null)
                    n.next = null;
                else
                    n.next = new Node(n.next.next);
                if (isOne)
                    return;
            }
            deleteElement(n.next, value, isOne);
        }
    }
}