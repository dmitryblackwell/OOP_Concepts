using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace OOP_Concepts.MinedOut
{
    partial class Map
    {
        private Player player;
        private Cell[,] map;
        private int lengthX, lengthY;
        public bool getPlayersAlive() { return player.getLifes() > 0; }

        private void movePlayer(int whereTo) { player.movePlayer(ref map, whereTo); }
        public void movePlayerLeft() { movePlayer((int)Player.Move.Left); }
        public void movePlayerRight() { movePlayer((int)Player.Move.Right); }
        public void movePlayerUp() { movePlayer((int)Player.Move.Up); }
        public void movePlayerDown() { movePlayer((int)Player.Move.Down); }
        
        private void MapInit(String[] MapStart)
        {
            lengthX = MapStart[0].Length;
            lengthY = MapStart.Length;
            map = new Cell[lengthY,lengthX];
            player = new Player();

            for (int i = 0; i < lengthY; ++i)
                for (int j = 0; j < lengthX; ++j)
                {
                    map[i, j] = new Cell(MapStart[i][j]);
                    if (map[i, j].isThisPlayer())
                        player = new Player(j, i);
                }
        }

        public Map(String[] map) {
            MapInit(map);
            fillRandom();
        }
        private void fillRandom()
        {
            Random r = new Random();
            for (int i =0; i<lengthY-2; ++i)
                for (int j = 1; j<lengthX-1; ++j)
                {
                    if (r.Next(5) == 0)
                        map[i, j] = new Cell(Cell.Field.BOMB);
                    else if (r.Next(20) == 0)
                        map[i, j] = new Cell(Cell.Field.MONEY);
                    else if (r.Next(30) == 0)
                        map[i, j] = new Cell(Cell.Field.MONEY);
                }
        }

        public bool isGameFinish()
        {
            if (player.getLifes() <= 0)
            {
                Console.WriteLine("Game Over!");
                return true;
            }
            if (player.getY() == 0)
            {
                Console.WriteLine("You win!");
                return true;
            }
            return false;
        }

        public void drawMap()
        {
            // TODO SetCursorPosition 
            for (int i = 0; i < lengthY; ++i)
            {
                for (int j = 0; j < lengthX; ++j)
                {
                    if (map[i, j].isThisPlayer())
                        Console.Write(player.getBombsAroundPlayer(map));
                    else
                        map[i, j].print();
                }
                Console.Write("\n");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Lifes: " + player.getLifes());
            Console.WriteLine("Money: " + player.giveMeYourMoney());
        }
    }
}