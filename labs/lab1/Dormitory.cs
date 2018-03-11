using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs.lab1
{
    class Dormitory
    {

        private const int TOTAL_ROOMS = 9;
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
                else if (cmd[0].Equals("all"))
                    printAllRooms();
                else if (cmd[0].Equals("exit"))
                    isExit = true;
                else
                    Console.WriteLine("not a command");
            }
        }
        private Room[] getSortedRooms(Room[] rooms)
        {
            Room temp;
            for(int i=0; i<rooms.Length; ++i)
            {
                for(int j=i+1; j< rooms.Length; ++j)
                {
                    if (rooms[i].StudentsCount > rooms[j].StudentsCount)
                    {
                        temp = rooms[i];
                        rooms[i] = rooms[j];
                        rooms[j] = temp;
                    }
                }
            }
            return rooms;
        }
        private void printFreeRooms()
        {
            Room[] sortedRooms = getSortedRooms(rooms);
            for(int i=0;i<TOTAL_ROOMS; ++i)
            {
                if(sortedRooms[i].StudentsCount != Room.MAX_STUDENTS_IN_ROOM)
                {
                    Console.WriteLine("Room " + sortedRooms[i].RoomNum + ": "
                        + (Room.MAX_STUDENTS_IN_ROOM - sortedRooms[i].StudentsCount) + "free beds");
                }
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
