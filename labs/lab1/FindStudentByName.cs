using System;

namespace labs.lab1
{
    public partial class Dormitory
    {
        public void findStudent(String name)   // print all rooms, where lives students with name or surname this args
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
    }
}