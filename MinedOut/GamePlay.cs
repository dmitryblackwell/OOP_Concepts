using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.MinedOut
{
    class GamePlay
    {
        Map map = new Map();
        public GamePlay()
        {
            bool isAlive = true;
            while (isAlive)
            {
                map.drawMap();
                ConsoleKeyInfo cki= Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.RightArrow:
                        map.moveRight();
                        break;
                    case ConsoleKey.LeftArrow:
                        map.moveLeft();
                        break;
                    case ConsoleKey.UpArrow:
                        map.moveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        map.moveDown();
                        break;
                    case ConsoleKey.E:
                        isAlive = false;
                        break;
                }
                Console.Clear();
            }
        }
    }
}
