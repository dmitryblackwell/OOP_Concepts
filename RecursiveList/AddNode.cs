using System;

namespace OOP_Concepts.RecursiveList
{
    public partial class RList
    {
        public void create(int[] ValuePack)  // create list and 
        {
            isNodeDefined = true;
            addRecursion(root, ValuePack, 0);
        }

        public void toEnd(int[] ValuePack) // add elements to the end
        {
            toEndRecursion(root, ValuePack);
        }

        public void toStart(int[] ValuePack) // add elemnts to the start
        {
            Node RootTmp = root;
            root = new Node();
            create(ValuePack);
            plusList(root, RootTmp);
        }

        public void addBefore(int[] args) // add one element before another
        {
            if (root.value == args[0])
            {
                root = new Node(args[1], root);
            }
            else
                addBefore(root, args[0], args[1]);
        }
         


        private void addBefore(Node n, int before, int value)
        {
            if (n.next != null && n.next.value == before)
                n.next = new Node(value, n.next);
            else if (n.next != null)
                addBefore(n.next, before, value);
        }

        private void plusList(Node n, Node list)
        {
            if (n.next != null)
                plusList(n.next, list);
           else
                n.next = new Node(list);
        }

        private void toEndRecursion(Node n,int[] ValuePack)
        {
            if (n.next != null)
                toEndRecursion(n.next, ValuePack);
            else 
            {
                n.next = new Node();
                addRecursion(n.next, ValuePack, 0);
            }
        }

        private void addRecursion(Node n, int[] ValuePack, int index)
        {
            n.value = ValuePack[index];
            index++;
            if (index < ValuePack.Length - 2)
            {
                n.next = new Node();
                addRecursion(n.next, ValuePack, index);
            }
        }
    }
}