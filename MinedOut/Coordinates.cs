using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.MinedOut
{
    class Coordinates
    {
        private int x, y;
        public Coordinates(int x_, int y_)
        {
            x = x_;
            y = y_;
        }
        public Coordinates() : this(0, 0) { }
        public int getX() { return x; }
        public int getY() { return y; }
        public static Coordinates getCoordinatesTo(int whereTo)
        {
            int x, y;
            switch (whereTo)
            {
                default:
                case (int) Player.Move.Right: // right
                    x = +1;
                    y = 0;
                    break;
                case (int)Player.Move.Left: //left
                    x = -1;
                    y = 0;
                    break;
                case (int)Player.Move.Up: //Up
                    x = 0;
                    y = -1;
                    break;
                case (int)Player.Move.Down: //Down
                    x = 0;
                    y = +1;
                    break;
            }
            return new Coordinates(x, y);
        }
    }
}
