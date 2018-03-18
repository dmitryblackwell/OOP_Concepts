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
                String keyInfo = Console.ReadKey().ToString();
                ConsoleKeyInfo cki= Console.ReadKey();
                if (cki.Key == ConsoleKey.RightArrow)
                    map.movePlayerRight();
                
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
}
