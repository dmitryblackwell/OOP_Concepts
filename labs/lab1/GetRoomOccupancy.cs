using System;

namespace labs.lab1
{
    public partial class Dormitory
    {
        public struct Floor
        {
            public float StudentsOnFloor;
            public float TotalStudentsPossible;
        }
        private void GetRoomOccupancy()
        {
            Floor[] floors = new Floor[TOTAL_FLOORS];
            foreach (Room r in rooms)
            {
                floors[r.FloorNum - 1].StudentsOnFloor += r.StudentsCount;
                floors[r.FloorNum - 1].TotalStudentsPossible += Room.MAX_STUDENTS_IN_ROOM;
            }
            for (int i = 0; i < TOTAL_FLOORS; ++i)
            {
                Floor f = floors[i];
                Console.WriteLine("Floor: " + (i + 1) + " Free beds: " + (f.TotalStudentsPossible - f.StudentsOnFloor)
                    + " Percent occupancy: " + Math.Round((f.StudentsOnFloor / f.TotalStudentsPossible) * 100) + "%");
            }
        }
    }
}