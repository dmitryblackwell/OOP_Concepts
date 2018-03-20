using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Concepts.Dorm
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
        

        public void addStudent()
        {
            Room[] sortedRooms = getSortedRooms(rooms);
            int RoomNumber = 0;
            if (sortedRooms[0].StudentsCount != Room.MAX_STUDENTS_IN_ROOM)
                RoomNumber = sortedRooms[0].RoomNum;
            else
                return;
            Console.WriteLine("Enter student name: ");
            String name = Console.ReadLine();
            rooms[RoomNumber - 1].addStudent(name);
            Console.WriteLine("Student added to room " + RoomNumber);
        }

        public void printAllRooms()
        {
            foreach (Room r in rooms)
            {
                r.print();
            }
        }

    }
}
