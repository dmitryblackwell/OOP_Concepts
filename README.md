# OOP_Concepts

## Content
1. [Dorm](#dorm)
   - [Task](#task)
   - [Solution](#solution)
     - [Dorm description](#description)
     - [Tree of classes](#DormTree)
1. [Recursive List](#list)
   - [Task](#ListTask)
   - [Solution](#ListSolution)
1. [Mined Out](#MinedOut)
   - [Install JSON library](#json)
   - [Project tree](#MinedTree)
     - [GamePlay](#GamePlay)
     - [Cell](#Cell)
     - [Map](#Map)
     - [Player](#Player)
     - [ConsoleUI](#cui)
     - [GraphicalUI](#gui)
     - [Coordinates](#coord)
     - [Rating](#rating)
1. [Console User Interface - CUI](#UserInterface)
   - [General help](#general)
   - [File help](#file)
   - [List help](#listHelp)
   - [Dorm help](#dormHelp)
   - [Game help](#gameHelp)


## <a name="dorm"></a> Dorm

### <a name="task"></a> Task

Create array with information about dormitory: room number, floor number, Students in room, surname of students. In one room can be 5 student maximum.
1) Read surname or name of student and write all rooms with students with this surname.
2) Write list of all rooms with free beds, sorted in descending order.
3) For every floor write number of free rooms and occupancy percent.
### <a name="solution"></a> Solution
I create Class Dormitory and Room. In Dormitory I create array of rooms and write there RoomNumber, FloorNumber, StudentsCount and array of Students names and surnames. In Room I get all this numbers, create constructor and method print.
#### <a name="description"></a> Dorm parameters and methods with description

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

#### <a name="DormTree"></a> Here simple Tree of classes:

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
## <a name="list"></a>  RecursiveList
### <a name="ListTask"></a>  Task
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
###  <a name="ListSolution"></a> Solution
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

## <a name="MinedOut"></a>  Mined-Out

### <a name="json"></a>  Install JSON library. 
To continue using this game you need to install JSON library. To do so follow instruction bellow.
```
"Project" -> "Manage NuGet packages" -> "Search for "newtonsoft json"  -> click "install"
``` 
![alt text](https://raw.githubusercontent.com/dmitryblackwell/OOP_Concepts/master/Screenshots/json.jpg)

### <a name="MinedTree"></a>  Project tree

<br>

#### <a name="GamePlay"></a>  GamePlay
Class simply pick up bool and call appropriate constructor: ConsoleUI, GraphicalUI.

| Modifier and Type | Name | Description |
| ----------------- | ---- | ----------- |
| private Map       | map  | New Map exemplar from CustomMaps |
| private ConsoleUI | cui  | New ConsoleUI from CustomMaps |
| public            | GamePlay(bool isConsole)| Constructor |

<br>
<br>

#### <a name="Cell"></a>  Cell
Cell or Field of every dot on the map, Mainly contains symbol to draw and it key equivalent.  

| Modifier and Type | Name | Description |
| ----------------- | ---- | ----------- |
| public enum  | Field | { FREE_SPACE, WALL, BOMB, PLAYER, DOT, MONEY, LIFE }|
| private char | symbol| Symbol that contains in this cell|
| private int  | key   | Key of that symbol|
| public       | Cell(int k) | Constructor for key |
| public       | Cell(char s)| Constructor for symbol |
| public       | Cell(Field f)| Get Symbol as Field enum above|
| public char  | getSymbol() | Return this.symbol |
| public int   | getKey()    | Return this.key |
| public bool  | isThisPlayer()| Return true if this cell contain player|
| public char  | GetPrintAbleSymbol() | Return symbol for printing. For example if it is bomb, this method return " "|
| public void  | print() | Print this cell |
| private char |getSymbol(int key) | Convert key to symbol |
| private int  | getKey(char ch) | Convert symbol to key"

<br>
<br>

#### <a name="Map"></a>  Map
Contains everything map does. Array of cell and method to rule it.

| Modifier and Type | Name | Description |
| ----------------- | ---- | ----------- |
| private Player    |player|  |
| private Cell[,]   | map  |  |
| private int       | lengthX, lengthY | Width and height of the map |
| public bool       | getPlayersAlive()| Return true if player alive |
| private void      | movePlayer(int whereTo)| Moves player to direction, that depends on pressed key |
| public void       | movePlayerLeft() | |
| public void       | movePlayerRight()| |
| public void       | movePlayerUp() | |
| public void       | movePlayerDown()| |
| private void      | MapInit(String[] MapStart)| Initialization of Map from String |  
| public            | Map(String[] map) | Calls MapInit and then fill it randomly with elements | 
| private void      | fillRandom() | Fill whole map in random position with bombs, money and lives |
| public enum       | GameEnd | { Continue, Dead, Finish } |
| public int        | isGameFinish() | Return true if GameOver |
| public int        | GetLengthX() | |  
| public int        | GetLengthY() | |
| public Cell       | GetCell(int line, int row) | Return map[line, row] |
| public Player     | GetPlayer() | Return player |
| public char       | getSymbolFor(int i,int j) | Return symbol for y,x |
| public class      | DataPack | Class with public parameters: _id, lifes, money, saveMap, for saving it to JSON|
| private const String | SAVE_FILE |File where we save and load our game: "saves.json"|
| public void       | save() | Save game |
| public void       | load() | Load game |

<br>
<br>

#### <a name="Player"></a>  Player
Player, his coord, money, lifes, and methods to rule it.

| Modifier and Type | Name | Description |
| ----------------- | ---- | ----------- |
| private int       | lifes| Countof lifes. From start =3 |
| private int       | bombsAround |Getting bombs counting around player. Max - 4, Min 0. |
| private int       | money | |
| private Coordinates | privCord | Saving previous coordinates |
| private int       | x, y | Position of player "|
| public enum       | Move | { Right, Left, Up, Down }| 
| public int        |getX()| Return x |
| public int        |getY()| Return y |
| public            | Player(int x_, int y_) | Constructor |
| public            | Player() | Create Player with coord(0,0)
| public int        | getLifes() | Return lifes count |
| public int        | giveMeYourMoney() | Return money |
| public void       | setLifes(int l) return lifes = l |
| public void       |setMoney(int m) | Put new copybook: money = m |
| public void       | movePlayer(ref Cell[,] map,int whereTo) | Move player to another place. Thinking about servers.|
| private const int | ZERO_CODE = 48 | Zero in ASCII | |
| public char       | getBombsAroundPlayer(Cell[,] map) | get bombs around house |
| private bool      | isInBound(int nX, int nY, Cell[,] map) | Return true if this coordinates is in bound of map |

<br>
<br>

#### <a name="cui"></a>  ConsoleUI
Drawing map and running game in the loop, while it is not over.

| Modifier and Type | Name | Description |
| ----------------- | ---- | ----------- |
| long              | TimeStart | Time in seconds, when you start game |
| private Map       | map  | Exemplar of Map class |
| public            | ConsoleUI(String[] mapStart) | Constructor, that create map from String|
| public void       | Run() | Simple GamePlay method that run in console, until game is over|
| private void      | drawMap() | Drawing map in console |
 
<br>
<br>

#### <a name="gui"></a>  GraphicalUI
Same, as Console as

| Modifier and Type | Name | Description |
| ----------------- | ---- | ----------- |
| long              | TimeStart | Time in seconds, when you start game |
| public long       | getTimeStart() |Return TimeStart |
| private Map       | map  | New map |
| public            | GraphicalUI() | Constructor |
| protected override bool | ProcessCmdKey(ref Message msg, Keys keyData) | Obtain click on key and call apropriate method. Check for game ending. |
| public static     | class Prompt | Class that creates dialog message for showing message, that saves your name. |
| protected override void | OnPaint(PaintEventArgs e) | Drawing map on screen. |
| private void      |createBtn_Click(object sender, EventArgs e) | Left mouse click on CreateBtn |
| private void      | saveBtn_Click(object sender, EventArgs e) |Left click on save button |
| private void      | loadBtn_Click(object sender, EventArgs e) | Click on load button |
| private void      | ratingBtn_Click(object sender, EventArgs e) | Click on rating button |
| private void      | GraphicalUI_Load(object sender, EventArgs e) | Calls, when window is loading |

<br>
<br>

#### <a name="coord"></a>  Coordinates
Class to save coordinates and get vX and vY to needed side.

| Modifier and Type | Name | Description |
| ----------------- | ---- | ----------- |
| private int       | x, y | Coordinates of point |
| public            |Coordinates() | Create point with coordinates (0,0) |
| public int        | getX() |  Return x |
| public int        | getY() | Return y |
| public static Coordinates | getCoordinatesTo(int whereTo) | Return Coordinates of vX and vY of direction from whereTo |

<br>
<br>

#### <a name="rating"></a>  Rating
Class for saving and loading rating from file.

| Modifier and Type | Name | Description |
| ----------------- | ---- | ----------- |
| private const String | SAVE_FILE | File where we are going to save file: "rating.txt" |
| public void          | save(String u,int s) | Save rating to file |
| public String[][]    | load() | Load rating |
| public void          | print() | Load and print to Console rating |
<br>
<br>
<br>

## <a name="UserInterface"></a>  Console User Interface - CUI
In this CUI exists simple constructor to build every program:
````
%ProgramName%  --%command% %arguments%
````
You can anytime get help. If you want to know what ProgramName exits there just print `help`, if you want to get help for special program, just print `%ProgramName% --help`. Also you can save a bunch of commands in file, just use program `file`. For first lab use `dorm` and for second `list`.

#### <a name="general"></a>  **General help**
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
     
#### <a name="file"></a>  **File help**
```
-c    --create    create new file enter name of the file plus .txt as parametr
      --delete    delete file with this name
"-r   --run       run this file or you can just simply type name of this file without .txt
-h    --help      get help
```
#### <a name="listHelp"></a>  **List help**
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
#### <a name="dormHelp"></a>  **Dorm help**
```
-f    --find       print room number, where lives this student
      --free       print all free rooms
-o    --occupancy  print occupancy of all rooms in percent
-p    --print      print all rooms
-h    --help       get help
```
#### <a name="gameHelp"></a>  **Game help**
```
-n    --new       create and load new game
-r    --rating    print rating
-g    --graphic   run windows form application with graphi UI
-h    --help      get help
```

> author @dmitryblackwell
