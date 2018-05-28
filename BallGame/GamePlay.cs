using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Concepts.BallGame
{
    class GamePlay
    {
        // карта в виде массива строк
        private String[][] maps = new String[][]
             {
                new String[]
                {   "##################",
                    "#     0    ~     #",
                    "#   @       !    #",
                    "#    |       @ ###",
                    "#     /    ^:  . #",
                    "#  @0          ###",
                    "#       @   ?    #",
                    "##################"    },
                new String[]
                {   "##################",
                    "#                #",
                    "#    !!!!!!!!    #",
                    "#  0     #   @   #",
                    "#     /  #     . #",
                    "#  @     # @@    #",
                    "#    @@@@#    0  #",
                    "##################"    },
                new String[]
                {   "##################",
                    "# @@  #### @@@   #",
                    "#  /  !!!!       #",
                    "#     !!@@     0 #",
                    "#!    !!!!       #",
                    "#!  @           .#",
                    "#!   @         0 #",
                    "##################"    }
           };
        //public static void Main(String[] args) { new GamePlay(); }
        private int UpdateTime = 500; // время задержки между обновлениями
        private Map map; // наша карта
        //static void Main(string[] args) { new GamePlay(); } // создание этого класса
        public GamePlay()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FieldForm());
            map = new Map(maps[0]);

            /*Console.WriteLine("Enter your choice: ");
            String line = Console.ReadLine();
            switch (line.Split(new char[0])[0]) {
                default:
                case "--new":
                    map = new Map(maps[0]);
                    break;
                case "--rand":
                    map = new Map();
                    break;
                case "--lvl":
                    map = new Map(maps[ Convert.ToInt32(
                                line.Split(new char[0]) [1])]);
                    break;
                case "--editor":
                    map = new Map(readMap());
                    break;
                case "--time":
                    map = new Map(maps[0]);
                    UpdateTime = 1000/Convert.ToInt32(line.Split(new char[0])[1]);
                    break;
            }*/
          
            //Run();
        }
        private String[] readMap()
        {
            Console.WriteLine("Enter lines number: ");
            int lines = Convert.ToInt32(Console.ReadLine());
            String[] mapStr = new String[lines];
            Console.WriteLine("Enter your map line by line.\n"+
                                "@ - Energy\n"+
                                "# - Wall\n"+
                                ". - Ball\n"+
                                "/ - Shield\n"+
                                "Lines length must be same\n\n");
            for (int i = 0; i < lines; ++i)
                mapStr[i] = Console.ReadLine();
            Console.Clear();
            return mapStr;
        }
        private void Run()
        {
            bool isExit = false;
            map.draw();
            // запуск нового потока, для получения нажатых клавишь
            Thread input = new Thread(() =>
            {
                while (map.isGameOn() && !isExit && map.isAlive())
                {
                    Thread.CurrentThread.IsBackground = true;
                    ConsoleKeyInfo cki = Console.ReadKey();
                    switch (cki.Key)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            map.moveLeft();
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            map.moveRight();
                            break;
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            map.moveUp();
                            break;
                        case ConsoleKey.S:
                            if (cki.Modifiers == ConsoleModifiers.Control)
                                map.save();
                            else
                                map.moveDown();
                            break;
                        case ConsoleKey.L:
                            if (cki.Modifiers == ConsoleModifiers.Control)
                                map.load();
                            break;
                        case ConsoleKey.DownArrow:
                            map.moveDown();
                            break;
                        case ConsoleKey.Q:
                        case ConsoleKey.E:
                            isExit = true;
                            break;
                        case ConsoleKey.F:
                            map.swapShields();
                            break;
                        case ConsoleKey.Spacebar:
                            map.settleShield();
                            break;
                    }
                }
            });
            input.Start();// его запуск

            int time = 0;
            Thread timeThread = new Thread(() =>
            {
                Thread.Sleep(100);
                int drawLine = Console.CursorTop+1;
                while (map.isGameOn() && !isExit && map.isAlive())
                {
                    int cursorLine = Console.CursorTop;
                    Console.SetCursorPosition(0, drawLine);
                    Console.Write( time/60 +":"+ (time % 60 < 10 ? "0" : "") + time %60);
                    time++;
                    Console.SetCursorPosition(0, cursorLine);
                    Thread.Sleep(1000);
                    if (time % 10 == 0)
                        map.setShieldNotAlloweded();
                }
            });
            timeThread.Start();

            while (map.isGameOn() && !isExit && map.isAlive())
            {
                //Console.Clear(); // все стираем
                map.draw();// Выводим нашу карту

                map.BallStep(); // двигаем мячик
                Thread.Sleep(UpdateTime); // ждем
            }
            if (!map.isGameOn()) // если победили
            {
                int score = (60 / time) + map.getShieldsOnMap();
                Console.WriteLine("\nYou win!\n Your score:" + score + " Press any key to continue.");
                Console.ReadKey();
            }
            if (!map.isAlive())
            {
                Console.WriteLine("\nYou loose!\n Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
