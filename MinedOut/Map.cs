using System;
using System.Collections.Generic;
using System.Linq;
using System    .Text;

namespace OOP_Concepts.MinedOut
{
    class Map
    {
        private Player player;
        private Cell[,] map;
        private int lengthX, lengthY;
        
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

        public Map() {
            MapInit(new String[] {
            "#               B  #",
            "#B              B  #",
            "#        B  B      #",
            "#   P      B  B    #",
            "#          B  B    #",
            "#          B  B    #",
            "#  B               #",
            "#         B    B   #",
            "# B  B     B B     #",
            "####################"});
        }
        
        public void drawMap()
        {
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
        }
    }
}
