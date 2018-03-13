using System;

namespace labs.lab2
{
    public partial class RList
    {

        public void create(int[] ValuePack)    
        {
            isNodeDefined = true;
            addRecursion(root, ValuePack, 0);
        }

        public void toEnd(int[] ValuePack)
        {
            toEndRecursion(root, ValuePack);
        }

        public void toStart(int[] ValuePack)
        {
            Node RootTmp = root;
            root = new Node();
            create(ValuePack);
            plusList(root, RootTmp);
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

            if (index < ValuePack.Length - 1)
            {
                n.next = new Node();
                addRecursion(n.next, ValuePack, index);
            }
        }
    }
}