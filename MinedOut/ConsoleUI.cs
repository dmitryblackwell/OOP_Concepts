using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.MinedOut
{
    class ConsoleUI
    {
        Map map;
        public ConsoleUI(String[] mapStart)
        {
            map = new Map(mapStart);
        }

        public void Run()
        {
            bool isPlaying = true;
            while (map.getPlayersAlive() && isPlaying)
            {
                Console.Clear();
                drawMap();
                isPlaying = !map.isGameFinish();
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        map.movePlayerRight();
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        map.movePlayerLeft();
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        map.movePlayerUp();
                        break;
                    case ConsoleKey.S:
                        if (cki.Modifiers == ConsoleModifiers.Control)
                            map.save();
                        else
                            map.movePlayerDown();
                        break;
                    case ConsoleKey.DownArrow:
                        map.movePlayerDown();
                        break;
                    case ConsoleKey.E:
                        isPlaying = false;
                        break;
                    case ConsoleKey.L:
                        if (cki.Modifiers == ConsoleModifiers.Control)
                            map.load();
                        break;
                }
            }
            Rating r = new Rating();
            r.print();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private void drawMap()
        {
            // TODO SetCursorPosition 
            for (int i = 0; i < map.GetLengthY(); ++i)
            {
                for (int j = 0; j < map.GetLengthX(); ++j)
                {
                    Console.Write(map.getSymbolFor(i, j));
                }
                Console.Write("\n");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Lifes: " + map.GetPlayer().getLifes());
            Console.WriteLine("Money: " + map.GetPlayer().giveMeYourMoney());
        }
    }
}
