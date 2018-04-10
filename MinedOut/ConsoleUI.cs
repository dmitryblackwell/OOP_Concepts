using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.MinedOut
{
    class ConsoleUI
    {
        long TimeStart = 0;
        Map map;
        public ConsoleUI(String[] mapStart)
        {
            map = new Map(mapStart);
        }

        public void Run()
        {
            TimeStart = DateTime.Now.Second;
            bool isPlaying = true;
            while (map.getPlayersAlive() && isPlaying)
            {
                Console.Clear();
                drawMap();
                if (map.isGameFinish() == (int) Map.GameEnd.Finish)
                {
                    long TimeEnd = DateTime.Now.Second;
                    Console.WriteLine("You win!\n Enter your name: ");
                    String username = Console.ReadLine();
                    Rating rate = new Rating();
                    rate.save(username, Convert.ToInt32(TimeEnd - TimeStart), map.GetPlayer().giveMeYourMoney(), map.GetPlayer().getLifes());
                    isPlaying = false;
                }
                else if (map.isGameFinish() == (int)Map.GameEnd.Dead)
                {
                    Console.WriteLine("You dead!");
                    isPlaying = false;
                }
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
                            map.save(TimeStart);
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
                            TimeStart = DateTime.Now.Second - map.load();
                        break;
                }
            }
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
