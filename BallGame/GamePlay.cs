using System;
using System.Threading;

namespace OOP_Concepts.BallGame
{
    class GamePlay
    {
        // карта в виде массива строк
        private String[] MapStr =
        {
            "##################",
            "#     0          #",
            "#   @            #",
            "#            @ ###",
            "#     /  0     . #",
            "#  @           ###",
            "#       @        #",
            "##################"
        };
        private const int UPDATE_TIME = 400; // время задержки между обновлениями
        private Map map; // наша карта
        //static void Main(string[] args) { new GamePlay(); } // создание этого класса
        public GamePlay()
        {


            map = new Map(MapStr); // инициализация карты
            Run();
        }
        private void Run()
        {
            bool isExit = false;
            // запуск нового потока, для получения нажатых клавишь
            Thread input = new Thread(() =>
            {
                while (map.isGameOn() && !isExit)
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
            while (map.isGameOn() && !isExit)
            {
                //Console.Clear(); // все стираем
                map.draw();// Выводим нашу карту

                map.BallStep(); // двигаем мячик
                Thread.Sleep(UPDATE_TIME); // ждем
            }
            if (!map.isGameOn()) // если победили
            {
                Console.WriteLine("\nYou win!\n Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
