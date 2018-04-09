# OOP_Concepts

## Dorm

### Task

Create array with information about dormitory: room number, floor number, Students in room, surname of students. In one room can be 5 student maximum.
1) Read surname or name of student and write all rooms with students with this surname.
2) Write list of all rooms with free beds, sorted in descending order.
3) For every floor write number of free rooms and occupancy percent.
### Solution
I create Class Dormitory and Room. In Dormitory I create array of rooms and write there RoomNumber, FloorNumber, StudentsCount and array of Students names and surnames. In Room I get all this numbers, create constructor and method print.
#### Dorm parameters and methods with description

| Access level | Return value | Name | Description |
| ------------ | ------------ | ---- | ----------- |
| private      | const int    | TOTAL_ROOMS | Constant value of total rooms in one dormitory. For this data it is equals 9.|
| private      | const int    | TOTAL_FLOORS| Constant value of total floors in this dormitory. Equals 3.|
| private      | Room[]       | rooms       | Array of total Rooms in one dormitory. Length equals TOTAL_ROOMS|
| public       | void         | printAllRooms() | Print whole information about rooms in array rooms. | 
| public       | void         | printFreeRooms () | Print number of rooms and free beds there in increasing order. |
| public       | void         | findStudent (String name) | Finds student in all rooms. If there are two student with same surname, print both.|
| public       | void         | GetRoomOccupancy () | Print room occupancy on floor int percent | 
| public       | void         | addStudent () | Add student to the most free rooms | 
| private      | Room[]       | getSortedRooms (Room[] r) | Sorts r by number of free rooms there and returns a copy of room array. Realized with bubble sort.|

#### Here simple Tree of classes:

1. Dormitory
   - Parameters
     - `private const int TOTAL_ROOMS = 9;`
     - `private const int TOTAL_FLOORS = 3;`
     - `Room[] rooms = new Room [TOTAL_ROOMS];`
   - Methods
     - `public void printAllRooms();`
     - `public void printFreeRooms ();`
     - `public void findStudent (String name);`
     - `public void GetRoomOccupancy ();`
     - `public void addStudent ();`
     - `private Room[] getSortedRooms (Room[] r);`

1. Room
   - Parameters
     - `private int roomNum;`
     - `private int floorNum;`
     - `private int studentCount;`
     - `private String[] students;`
     - `public const int MAX_STUDENTS_IN_ROOM = 5;`
   - Methods
     - `public Room (Room r);`
     - `public Room (int roomNum, int floorNum, int studentCount, String[] students);`
     - `public bool isThereStudent (String name);`
     - `public void addStudent (String name);`
     - `public void print ();`
## RecursiveList
### Task
Create class, that realized one-way linked recursive list. Example:
```
class RList{
   private int info;
   private RList next;

   public RList(int i, RList n) {
       info = i;
       next = n;
   }
}
```
**Class should realize all methods below.**
1) Constructor with one parameter: value.
2) Constructor with two parameters: value, next element.
3) Method, that adds new element to start of list.
4) Method, that adds new element before another one.
5) Method, that deletes element(first one from many).
6) Method, that deletes all even elements.
7) Non-recursive Method, that print all odd elements.
8) Method, that print average of numbers under zero.
9) Get and Set methods for elements in list.
### Solution
I created two classes Node and RList. Node is a simple class, that contains value and link to next element. RList is more complicated class, that do almost everything. Also I created ElementNotFoundException, that throws, when you try to access node in list, which doesn't exist, usually in Get and Set methods.
#### Here simple Tree of classes:
1) Node
   - Parameters
     - `public int value;`
     - `public Node next;`
   - Methods
     - `public Node ();`
     - `public Node (Node n);`
     - `public Node (int v);`
     - `public Node (int v, Node n);`
2) RList
   - Parameters
     - `private Node root;`
     - `private bool isNodeDefined = false;`
   - Methods
     - `// General methods`
     - `public RList ();`
     - `public void print ();`
     - `public void signedAverage ();`
     - `public void printOdd ();`
     - `public void get (int[] num);`
     - `public void set (int[] args);`
     - `private int get (Node n, int count, int num);`
     - `private void set (Node n, int count, int num, int value);`
     - `private float signedAverage (Node n, int sum, int count);`
     - `private void printRecursion (Node n);`
     - `// Add elements`
     - `public void create (int[] ValuePack);`
     - `public void toEnd (int[] ValuePack);`
     - `public void toStart (int[] ValuePack);`
     - `public void addBefore (int[] args);`
     - `private void addBefore (Node n, int before, int value);`
     - `private void plusList (Node n, Node list);`
     - `private void toEndRecursion (Node n,int[] ValuePack);`
     - `private void addRecursion (Node n, int[] ValuePack, int index);`
     - `// Delete elements`
     - `public void clear ();`
     - `public void deleteOne(int value);`
     - `public void deleteAll(int value);`
     - `public void deleteEven();`
     - `private void deleteEven(Node n);`
     - `private void deleteElement(Node n,int value, bool isOne);`

## Mined-Out

### Install JSON library. 
To continue using this game you need to install JSON library. To do so follow instruction bellow.
```
"Project" -> "Manage NuGet packages" -> "Search for "newtonsoft json"  -> click "install"
``` 
![alt text](https://raw.githubusercontent.com/dmitryblackwell/OOP_Concepts/master/Screenshots/json.jpg)

**Coming soon...**
<br>
<br>
<br>

## Console User Interface - CUI
In this CUI exists simple constructor to build every program:
````
%ProgramName%  --%command% %arguments%
````
You can anytime get help. If you want to know what ProgramName exits there just print `help`, if you want to get help for special program, just print `%ProgramName% --help`. Also you can save a bunch of commands in file, just use program `file`. For first lab use `dorm` and for second `list`.

#### **General help**
```
file  - create, run or delete files with cmds, to get more info print: file --help
list  - operated with recurion list, to get more info print: list --help
dorm  - operated with dormitory, to get more info print: dorm --help
game  - run MinedOut game, to get more info print: game --help
```
```
#     - comment, put space after it
echo  - print everything that contains after this coommand
clear - clear console
help  - get this help
exit  - exit from console
```
     
#### **File help**
```
-c    --create    create new file enter name of the file plus .txt as parametr
      --delete    delete file with this name
"-r   --run       run this file or you can just simply type name of this file without .txt
-h    --help      get help
```
#### **List help**
```
-c    --create         create new list, add items as parametrs after
-e    --toEnd          add new items to the end
-s    --toStart        add new items to the start
-l    --length         print length of list, and set new length send as parametr
```                                          
```
      --clear          delete all elements
-p    --print          print all elements
-b    --addBefore      add one element before another
      --deleteOne      delete first element in list with this value
      --deleteAll      delete all elements in list with this value
```
```
      --deleteEvent    delete even elemens in list
      --signedAverage  print average of all elements under zerro
      --printOdd       print all odd elements
      --get            get and print elements
-h    --help           get help
```
#### **Dorm help**
```
-f    --find       print room number, where lives this student
      --free       print all free rooms
-o    --occupancy  print occupancy of all rooms in percent
-p    --print      print all rooms
-h    --help       get help
```
#### **Game help**
```
-n    --new       create and load new game
-r    --rating    print rating
-g    --graphic   run windows form application with graphi UI
-h    --help      get help
```



> author @dmitryblackwell
