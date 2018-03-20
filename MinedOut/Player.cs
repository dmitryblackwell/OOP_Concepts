using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.MinedOut
{
    class Player
    {
        private int lifes = 3;
        private int bombsAround;
        private int money = 0;
        private Coordinates privCord;
        private int x, y;

        public enum Move { Right, Left, Up, Down };
        public int getX() { return x; }
        public int getY() { return y; }
        public Player(int x_, int y_)
        {
            x = x_;
            y = y_;
            privCord = new Coordinates(x, y);
        }
        public Player() : this(0, 0) { }
        public int getLifes() { return lifes; }
        public int giveMeYourMoney() { return money; }
        public void setLifes(int l) { lifes = l; }
        public void setMoney(int m) { money = m; }
        public void movePlayer(ref Cell[,] map,int whereTo)
        {
            Coordinates nextCord = Coordinates.getCoordinatesTo(whereTo);
            int nX = x + nextCord.getX();
            int nY = y + nextCord.getY();

            if ( isInBound(nX, nY, map) && map[nY,nX].getKey() != (int) Cell.Field.WALL)
            {
                switch (map[nY, nX].getKey())
                {
                    case (int) Cell.Field.BOMB:
                        lifes--;
                        break;
                    case (int) Cell.Field.MONEY:
                        money++;
                        break;
                    case (int) Cell.Field.LIFE:
                        lifes++;
                        break;
                }
                map[y, x] = new Cell(Cell.Field.DOT);
                map[nY, nX] = new Cell(Cell.Field.PLAYER);

                x = nX;
                y = nY;
            }
        }


        private const int ZERO_CODE = 48;
        public char getBombsAroundPlayer(Cell[,] map)
        {
            int bombsCount = ZERO_CODE;
            for (int i = 0; i < 4; ++i)
            {
                Coordinates cord = Coordinates.getCoordinatesTo(i);
                int nX = x + cord.getX();
                int nY = y + cord.getY();

                if (isInBound(nX, nY, map) &&
                    map[nY, nX].getKey() == (int) Cell.Field.BOMB)
                        bombsCount++;
            }
            return Convert.ToChar(bombsCount);
        }
        private bool isInBound(int nX, int nY, Cell[,] map)
        {
            return (nX < map.GetLength(1) && nX >= 0 &&
                    nY < map.GetLength(0) && nY >= 0);
        }
    }
}
