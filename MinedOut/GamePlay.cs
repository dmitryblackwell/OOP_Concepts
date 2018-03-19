using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.MinedOut
{
    class GamePlay
    {
        Map map = new Map(CustomMaps.startMap);
        
        public GamePlay()
        {
            bool isPlaying = true;
            while (map.getPlayersAlive() && isPlaying)
            {
                map.drawMap();
                ConsoleKeyInfo cki= Console.ReadKey();
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
                        if(cki.Modifiers == ConsoleModifiers.Control)
                            map.load();
                        break;
                }
                Console.Clear();
            }
            Console.WriteLine("Game Over!");
        }
    }
}
