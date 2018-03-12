using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs.lab1
{
    public partial class Dormitory
    {

        private const int TOTAL_ROOMS = 9;
        private const int TOTAL_FLOORS = 3;
        Room[] rooms = new Room[TOTAL_ROOMS] {new Room(1, 1, 4, new String[] { "Franz Kafka", "Lev Tolstoi", "Mikhail Lermontov", "Vera Nabokov"}),
                                    new Room(2, 1, 1, new String[] {"Vladimir Nabokov"}),
                                    new Room(3, 1, 2, new String[] {"Richard Dawkins", "Stephen Hawking"}),

                                    new Room(4, 2, 0, new String[] { }),
                                    new Room(5, 2, 5, new String[] {"Mihail Bulgakov", "Ray Bradbury", "Bram Stoker", "Stephen King",  "Francis Fitzgerald"}),
                                    new Room(6, 2, 1, new String[] {"william shakespeare" }),

                                    new Room(7, 3, 2, new String[] {"Leil Lowndes", "Charles Bukowski"}),
                                    new Room(8, 3, 3, new String[] {"Joanne Rowling", "Charles Dickens", "Charles Darwin"}),
                                    new Room(9, 3, 4, new String[] {"Ayn Rand", "Jerome Salinger", "Herbert Schildt", "Bruce Eckel"})};        
        public Dormitory()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Write("cmd: ");
                String cmdLine = Console.ReadLine();
                String[] cmd = cmdLine.Split(new char[0]);
                if (cmd[0].Equals("find"))
                {
                    if (cmd.Length == 3)
                        findStudent(cmd[1] + " " + cmd[2]);
                    else
                        findStudent(cmd[1]);
                }
                else if (cmd[0].Equals("free"))
                    printFreeRooms();
                else if (cmd[0].Equals("occupancy"))
                    GetRoomOccupancy();
                else if (cmd[0].Equals("all"))
                    printAllRooms();
                else if (cmd[0].Equals("exit"))
                    isExit = true;
                else if (cmd[0].Equals("help"))
                    Console.Write("To find room print: find %RoomNumber% \n" +
                        "To print all free rooms: free \n" +
                        "To print occupancy on floor: occupancy\n" +
                        "To print all rooms: all\n" +  
                        "To get help: help\n" +
                        "To exit: exit");
                else
                    Console.WriteLine("not a command");
            }
        }

        private void printAllRooms()
        {
            foreach (Room r in rooms)
            {
                r.print();
                Console.WriteLine("");
            }
        }

    }
}
