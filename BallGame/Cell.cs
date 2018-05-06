using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.BallGame
{
    abstract class Cell
    {
        protected char symbol;
        private int x, y;
        protected int privX, privY;
        public Cell(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            privX = 0;
            privY = 0;
            this.symbol = symbol;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public void draw() {
            if (privX != x || privY != y)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);
                Console.Write(symbol);
                privX = x;
                privY = y;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public char getSymbol() { return symbol; }
    }
    class Empty : Cell
    {
        public Empty(int x, int y) : base(x, y, ' ') { }
    }
    class Ball : Cell
    {
        public Ball(int x, int y) : base(x, y, '.') { }
        private int VX = -1;
        private int VY = 0;
        public int vY { get { return VY; } set { VY = value; } }
        public int vX { get { return VX; } set { VX = value; } }
        public void swapCoords()
        {
            int tmp = vX;
            vX = vY;
            vY = tmp;
        }
        public void moveInside()
        {
            X += vX;
            Y += vY;
        }
        public void draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    class Shield : Cell
    {
        public Shield(int x, int y) : base(x, y, '/') { }
        public Shield(int x, int y, char s) : base(x, y, s) { }
        public void swap() { symbol = symbol == '/' ? '\\' : '/'; privX = 0; }
        public bool isReverse() { return symbol == '\\'; }
        public char getShieldChar() { return symbol; }
    }

    class Wall : Cell
    {
        public Wall(int x, int y) : base(x,y,'#') { }
    }

    class Energy : Cell
    {
        public Energy(int x,int y) : base(x,y,'@') { }
        private static int totalBalls = 0; // всего мячей
        private static int ballsDown = 0; // мячей сбили

        public static void plusTotalBall() { totalBalls++; }
        public static void plusBallsDown() { ballsDown++; }
        public static bool isDownLess() { return ballsDown < totalBalls; }
    }
}
