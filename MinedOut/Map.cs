using System;
using System.Collections.Generic;
using System.Linq;
using System    .Text;

namespace OOP_Concepts.MinedOut
{
    class Map
    {
        private String[] MapStart=
        {
            "#               B  #",
            "#               B  #",
            "#        B  B      #",
            "#          B  B    #",
            "#     P    B  B    #",
            "#          B  B    #",
            "#  B               #",
            "#         B    B   #",
            "# B  B     B B     #",
            "####################",
        };

        /* 0   - free space
         * 1 # - wall
         * 2 B - bomb
         * 3 P - player
         * 4 . - dot
         * 5 $ - money
         * */
        private int[,] map;
        private int lengthX, lengthY;
        enum Field { FREE_SPACE, WALL, BOMB, PLAYER, DOT, MONEY };
        enum Move { Right, Left, Up, Down};

        private void MapInit()
        {

            lengthX = MapStart[0].Length;
            lengthY = MapStart.Length;
            map = new int[lengthY,lengthX];

            for (int i = 0; i<lengthY; ++i)
                for(int j = 0; j<lengthX; ++j)
                    map[i, j] = getElementCode(MapStart[i].ToCharArray()[j]);

        }
        public Map() { MapInit(); }
        private int getElementCode(char ch)
        {
            int elementCode;
            switch (ch)
            {
                default:
                case ' ':
                    elementCode = (int) Field.FREE_SPACE ;
                    break;
                case '#':
                    elementCode = (int) Field.WALL;
                    break;
                case 'B':
                    elementCode = (int) Field.BOMB;
                    break;
                case 'P':
                    elementCode = (int) Field.PLAYER;
                    break;
                case '.':
                    elementCode = (int) Field.DOT;
                    break;
                case '$':
                    elementCode = (int) Field.MONEY;
                    break;
            }
            return elementCode;
        }
        private bool isInBound(int x, int y)
        {
            return (x < lengthX && x >= 0 && y < lengthY && y >= 0);
        }
        private char getDrawChar(int x, int y)
        {
            char ch;
            switch (map[x,y])
            {
                default:
                case (int) Field.BOMB:
                case (int) Field.FREE_SPACE:
                    ch = ' ';
                    break;
                case (int) Field.WALL:
                    ch = '#';
                    break;
                case (int) Field.PLAYER:
                    int bombsCount = 48;
                    for (int i = 0; i < 4; ++i)
                    {
                        Coordinates cord = getCoordinatesTo(i);
                        if (isInBound(x + cord.x, y + cord.y) && map[y + cord.y, x + cord.x] == (int)Field.BOMB)
                            bombsCount++;
                    }
                    ch = Convert.ToChar( bombsCount );
                    break;
                case (int)Field.DOT:
                    ch = '.';
                    break;
                case (int)Field.MONEY:
                    ch = '$';
                    break;
            }
            return ch;
        }
        struct Coordinates {
            public int x,y;
            public Coordinates(int x_,int y_)
            {
                x = x_;
                y = y_;
            }
        }
        private Coordinates getCoordinatesTo(int whereTo)
        {
            int x, y;
            switch (whereTo)
            {
                default:
                case (int) Move.Right: // right
                    x = +1;
                    y = 0;
                    break;
                case (int) Move.Left: //left
                    x = -1;
                    y = 0;
                    break;
                case (int) Move.Up: //Up
                    x = 0;
                    y = -1;
                    break;
                case (int) Move.Down: //Down
                    x = 0;
                    y = +1;
                    break;
            }
            return new Coordinates(x, y);
        }

        private void movePlayer(int whereTo)
        {
             for (int i = 0; i < lengthY; ++i)
                for(int j = 0; j < lengthX; ++j)
                    if (map[i,j] == (int)Field.PLAYER)
                    {
                        Coordinates cord = getCoordinatesTo(whereTo);
                        if(isInBound(j+ cord.x, i+cord.y))
                        {
                            map[i, j] = (int)Field.DOT;
                            map[i + cord.y, j + cord.x] = (int)Field.PLAYER;
                        }
                        //break from two loops
                        i = lengthY;
                        j = lengthX;
                    }
        }

        public void moveLeft() { movePlayer((int) Move.Left); }
        public void moveRight() { movePlayer((int) Move.Right); }
        public void moveUp() { movePlayer((int) Move.Up); }
        public void moveDown() { movePlayer((int) Move.Down); }

        public void drawMap()
        {
            for (int i = 0; i < lengthY; ++i)
            {
                for (int j = 0; j < lengthX; ++j)
                    Console.Write(getDrawChar(i,j));
                Console.Write("\n");
            }
        }
    }
}
