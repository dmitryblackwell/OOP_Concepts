using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs.lab1
{
    class Dormitory
    {
        Room[] rooms = new Room[9] {new Room(1, 1, 4, new String[] { "Franz Kafka", "Lev Tolstoi", "Mikhail Lermontov", "Vera Nabokov"}),
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
                if (cmd[0].Equals("exit"))
                    isExit = true;                    
            }
        }
        private void findStudent(String name)
        {
            bool wasStudentFind = false;
            foreach (Room r in rooms)
                if (r.isThereStudent(name))
                {
                    Console.WriteLine("Floor: " + r.FloorNum + ", Room: " + r.RoomNum);
                    wasStudentFind = true;
                }

            if (!wasStudentFind)
                Console.WriteLine("Student not found");
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
