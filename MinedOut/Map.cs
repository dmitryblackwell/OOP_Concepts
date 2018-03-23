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
                    else if (r.Next(70) == 0)
                        map[i, j] = new Cell(Cell.Field.LIFE);
                }
        }
        public enum GameEnd { Continue, Dead, Finish };
        public int isGameFinish()// 0 - continue //1 -dead // 2- finish
        {
            if (player.getLifes() <= 0)
                return (int)GameEnd.Dead;
            if (player.getY() == 0)
                return (int)GameEnd.Finish;
            return (int)GameEnd.Continue;
        }
        public int GetLengthX() { return lengthX; }
        public int GetLengthY() { return lengthY; }
        public Cell GetCell(int line, int row) { return map[line, row]; }
        public Player GetPlayer() { return player; }

        public char getSymbolFor(int i,int j) {
            if(map[i, j].isThisPlayer())
                return player.getBombsAroundPlayer(map);
            else
                return map[i, j].GetPrintAbleSymbol();
        }
    }
}