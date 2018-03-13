using System;

namespace labs.lab2
{
    partial class ConsoleInterface
    {
        private RList list;
        private bool isExit;

        public ConsoleInterface()
        {
            list = new RList();
            isExit = false;
            runConsole();
        }

        private void runConsole()
        {
            while (!isExit)
            {
                Console.Write("cmd: ");
                String cmdLine = Console.ReadLine();
                cmdLine += " ";
                performCmd(cmdLine);
            }
        }

        private void fileCmd(String[] cmd)
        {
            switch (cmd[1])
            {
                case "-c":
                case "--create":
                    createFile(cmd[2]);
                    break;
                case "--delete":
                    deleteFile(cmd[2]);
                    break;
                case "-r":
                case "--run":
                    runFile(cmd[2]);
                    break;
                default:
                    notCmd(cmd[1]);
                    break;
            }
        }
        private void listCmd(String[] cmd)
        {
            switch (cmd[1])
            {
                case "-c":
                case "--create":
                    list.create(getArgs(cmd));
                    break;
                case "-e":
                case "--add":
                case "--toEnd":
                    list.toEnd(getArgs(cmd));
                    break;
                case "-s":
                case "--toStart":
                    list.toStart(getArgs(cmd));
                    break;
                case "--clear":
                    list.clear();
                    break;
                case "-p":
                case "--print":
                    list.print();
                    break;
                default:
                    notCmd(cmd[1]);
                    break;
            }
        }
        private void performCmd(String cmdLine)
        {
            String[] cmd = cmdLine.Split(new char[0]);
            switch (cmd[0])
            {
                case "#":
                    break;
                case "file":
                    fileCmd(cmd);
                    break;
                case "list":
                    listCmd(cmd);
                    break;
                case "help":
                    Console.WriteLine("Go Fuck yourself!");
                    break;
                case "exit":
                    isExit = true;
                    break;
                case "echo":
                    for (int i = 1; i < cmd.Length; ++i)
                        Console.Write(cmd[i] + " ");
                    Console.WriteLine("");
                    break;
                default:
                    notCmd(cmd[0]);
                    break;
            }
        }
        private void notCmd(String cmd)
        {
            Console.WriteLine(cmd + " not a command");
        }
        private int[] getArgs(String[] cmd)
        {
            int[] nums = new int[cmd.Length - 1];
            for (int i = 2; i < nums.Length; ++i)
                nums[i - 2] = Int32.Parse(cmd[i]);
            return nums;
        }
    }
}
