using System;

namespace labs.lab2
{
    public partial class RList
    {
        public void clear()
        {
            Console.WriteLine("Are you sure you want to delete all elements? [y/n]");
            String answer = Console.ReadLine();
            if (answer.Equals("y") || answer.Equals("Y"))
                root.next = null;
            isNodeDefined = false;
        }
    }
}