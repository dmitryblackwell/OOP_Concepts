using OOP_Concepts.Dorm;
using OOP_Concepts.MinedOut;
using OOP_Concepts.RecursiveList;
using System;

namespace OOP_Concepts
{ 
    partial class ConsoleInterface
    {
        private RList list;
        private Dormitory dorm;
        private bool isExit;
        private const String SCRIPT_FOLDER = "scripts/";
        public ConsoleInterface()
        {
            list = new RList();
            dorm = new Dormitory();
            isExit = false;
        }

        public void runConsole()  // run this console and read commands
        {
            while (!isExit)
            {
                Console.Write("cmd: ");
                String cmdLine = Console.ReadLine();
                cmdLine += " ";
                String[] cmd = cmdLine.Split(new char[0]);
                performCmd(cmd);
            }
        }

        private void fileCmd(String[] cmd)  // all cmds for file
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
                case "-h":
                case "--help":
                    Console.Write(FILE_HELP);
                    break;
                default:
                    notCmd(cmd[1]);
                    break;
            }
        }
        private void listCmd(String[] cmd) // all cmds for list
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
                case "-b":
                case "--addBefore":
                    list.addBefore(getArgs(cmd));
                    break;
                case "--deleteOne":
                    list.deleteOne(Int32.Parse(cmd[2]));
                    break;
                case "--deleteAll":
                    list.deleteAll(Int32.Parse(cmd[2]));
                    break;
                case "--deleteEven":
                    list.deleteEven();
                    break;
                case "--signedAverage":
                    list.signedAverage();
                    break;
                case "--printOdd":
                    list.printOdd();
                    break;
                case "--get":
                    list.get(getArgs(cmd));
                    break;
                case "--set":
                        list.set(getArgs(cmd));
                    break;
                case "-?":
                case "-h":
                case "--help":
                    Console.Write(LIST_HELP);
                    break;
                default:
                    notCmd(cmd[1]);
                    break;
            }
        }
        private void dormCmd(String[] cmd)
        {
            switch (cmd[1])
            {
                case "--add":
                    dorm.addStudent();
                    break;
                case "-f":
                case "--find":
                    if (cmd.Length == 4)
                        dorm.findStudent(cmd[2] + cmd[3]);
                    else
                        dorm.findStudent(cmd[2]);
                    break;
                case "--free":
                    dorm.printFreeRooms();
                    break;
                case "-o":
                case "--occupancy":
                    dorm.GetRoomOccupancy();
                    break;
                case "-p":
                case "--print":
                case "-a":
                case "--all":
                    dorm.printAllRooms();
                    break;
                case "-h":
                case "--help":
                    Console.Write(DORM_HELP);
                    break;
                default:
                    notCmd(cmd[1]);
                    break;
            }
        }

        private void gameCmd(String[] cmd)
        {
            GamePlay gp;
            switch (cmd[1])
            {
                case "-c":
                case "--create":
                    // custom map creation
                    break;
                case "-l":
                case "--load":
                    // loading the map
                    break;
                case "-n":
                case "--new":
                    gp = new GamePlay(true);
                    break;
                case "-r":
                case "--rating":
                    Rating r = new Rating();
                    r.print();
                    break;
                case "-w":
                case "-g":
                case "--graphic":
                    gp = new GamePlay(false);
                    break;
                case "-h":
                case "--help":
                    Console.WriteLine(GAME_HELP);
                    break;                
            }
        }
        private void performCmd(String[] cmd) //general cmds
        {
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
                case "game":
                    gameCmd(cmd);
                    break;
                case "help":
                    Console.Write(GENERAL_HELP);
                    break;
                case "e":
                case "q":
                case "exit":
                    isExit = true;
                    break;
                case "echo":
                    for (int i = 1; i < cmd.Length; ++i)
                        Console.Write(cmd[i] + " ");
                    Console.WriteLine("");
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "dorm":
                    dormCmd(cmd);
                    break;
                default:
                    if (isMacros(cmd[0]))
                        runFile(cmd[0] + ".txt");
                    else
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