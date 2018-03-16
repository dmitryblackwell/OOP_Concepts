using System;

namespace labs.lab1
{
    public partial class Dormitory
    {
        private Room[] getSortedRooms(Room[] r)   //sorted all rooms by students in them.
        {
            Room[] rooms = new Room[TOTAL_ROOMS];
            for (int i = 0; i < TOTAL_ROOMS; ++i)
            {
                rooms[i] = new Room(r[i]);
            }
            Room temp;
            for (int i = 0; i < rooms.Length; ++i)
            {
                for (int j = i + 1; j < rooms.Length; ++j)
                {
                    if (rooms[i].StudentsCount > rooms[j].StudentsCount) //from less students to more students
                    {
                        temp = rooms[i];
                        rooms[i] = rooms[j];
                        rooms[j] = temp;
                    }
                }
            }
            return rooms;
        }

        public void printFreeRooms() // print all rooms with one free room or more
        {
            Room[] sortedRooms = getSortedRooms(rooms);
            for (int i = 0; i < TOTAL_ROOMS; ++i)
            {
                if (sortedRooms[i].StudentsCount != Room.MAX_STUDENTS_IN_ROOM)
                {
                    Console.WriteLine("Room " + sortedRooms[i].RoomNum + ": "
                        + (Room.MAX_STUDENTS_IN_ROOM - sortedRooms[i].StudentsCount) + " free beds");
                }
            }
        }
    }
}