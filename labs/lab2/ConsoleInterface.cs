using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs.lab2
{
    class ConsoleInterface
    {
        public ConsoleInterface()
        {
            bool isExit = false;
            RList list = new RList();
            while (!isExit)
            {
                Console.Write("cmd: ");
                String cmdLine = Console.ReadLine();
                cmdLine += " ";
                String[] cmd = cmdLine.Split(new char[0]);

                if (cmd[0].Equals("add"))
                {
                    int[] nums = new int[cmd.Length - 1];
                    for (int i = 1; i < nums.Length; ++i)
                        nums[i - 1] = Int32.Parse(cmd[i]);
                    list.add(nums);
                }
                else if (cmd[0].Equals("print"))
                    list.print();
                else if (cmd[0].Equals("clear"))
                    list.clear();
                else if (cmd[0].Equals("exit"))
                    isExit = true;
                else if (cmd[0].Equals("help"))
                    Console.WriteLine("Go Fuck yourself!");
                else
                    Console.WriteLine("not a command");
                    
            }
        }
    }
}
