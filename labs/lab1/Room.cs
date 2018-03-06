using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs.lab1
{
    class Room
    {
        private int roomNum;
        private int floorNum;
        private int studentCount;
        private String[] students;
        public const int MAX_STUDENTS_IN_ROOM = 5;

        public Room(int roomNum, int floorNum,int studentCount,String[] students)
        {
            this.roomNum = roomNum;
            this.floorNum = floorNum;
            this.studentCount = studentCount;
            if (studentCount > MAX_STUDENTS_IN_ROOM || studentCount < 0)
                Console.WriteLine("Can not create room with less than 1 student or more than 5");
            else
            {
                this.students = new String[MAX_STUDENTS_IN_ROOM];
                for (int i = 0; i < studentCount; ++i)
                    this.students[i] = students[i];
            }
        }

        public void print()
        {
            Console.Write("Room number: " + roomNum +
                "\nFloor number: " + floorNum +
                "\nStudents in room: " + studentCount+
                "\nStudents: ");
            for(int i=0; i<studentCount; ++i)
                Console.Write(students[i] + (( (studentCount-1) == i)  ?  "\n":", "));
        }

        public bool isThereStudent(String name)
        {
            for (int i = 0; i < studentCount; ++i)
            {
                String[] studentName = students[i].Split(new char[0]);
                if (students[i].Equals(name) || studentName[0].Equals(name) || studentName[1].Equals(name))
                    return true;
            }
            return false;
        }
        
        public int FloorNum {
            get { return this.floorNum; }
        }
        public int RoomNum {
            get { return this.roomNum;  }
        }
    }
}
