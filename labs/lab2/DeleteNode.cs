using System;

namespace labs.lab2
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
            deleteElement(root, value,true);
        }
        public void deleteAll(int value)
        {
            deleteElement(root, value, false);
        }



        private void deleteElement(Node n,int value, bool isOne)
        {
            if (n.next == null)
                return;

            while (n.next.value == value)
            {
                n.next = new Node(n.next.next);
                if (isOne)
                    return;
            }
            deleteElement(n.next, value, isOne);
        }
    }
}