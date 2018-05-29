using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOP_Concepts.BallGame
{
    abstract class Cell
    {
        protected char symbol;
        protected PictureBox texture = new PictureBox();
        private int x, y;
        protected int privX, privY;
        private const int SHIFT = 30;
    
        public Cell(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            privX = 0;
            privY = 0;
            this.symbol = symbol;
            texture.Top = y * SHIFT;
            texture.Left = x * SHIFT;
        }

        public PictureBox getTexture() { return texture; }
        public int X
        {
            get { return x; }
            set { x = value; texture.Left = x * SHIFT; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; texture.Top = y * SHIFT; }
        }
        public virtual void draw() {
            if (privX != x || privY != y)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);
                Console.Write(symbol);
                privX = x;
                privY = y;
            }
            Console.ForegroundColor = ConsoleColor.White;
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
        public override void draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.draw();
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
        public override void draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            base.draw();
        }
    }
    class Teleport : Cell
    {
        private int x1, y1;
        public Teleport(int x, int y, int x_, int y_) : base(x, y, '0')
        {
            this.x1 = x_;
            this.y1 = y_;
        }
        public Teleport() : base(-1, -1, '0') { }

        public void set(int x_,int y_)
        {
            if (X == -1 && Y == -1) { X = x_; Y = y_; }
            else { x1 = x_; y1 = y_; }
        }
        public bool isSet() { return X != -1 && Y != -1; }
        public Point getSecond(int x_, int y_)
        {
            return new Point(
                x_ == x1 ? X : x1,
                y_ == y1 ? Y : y1);
        }
        public override void draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x1, y1);
            Console.Write("*");
            base.draw();
            privX = -1;
            privY = -1;
        }
    }

    class Trap : Cell
    {
        public Trap(int x, int y) : base(x,y,'!') { }
    }
    class Direction : Cell {
        private int vx, vy;
        public Direction(int x, int y, int directionTo) : base(x, y,
            Convert.ToChar(
            directionTo == 0 ? '>' : directionTo == 1 ? '^' :
            directionTo == 2 ? '<' : '|')) {
            switch (directionTo)
            {
                case 0: //right
                    vx = 1;
                    vy = 0;
                    break;
                case 1: // up
                    vx = 0;
                    vy = -1;
                    break;
                case 2: // left
                    vx = -1;
                    vy = 0;
                    break;
                case 3:
                    vx = 0;
                    vy = 1;
                    break;   
            }
        }

        public int vY { get { return vy; } set { vy = value; } }
        public int vX { get { return vx; } set { vx = value; } }
    }
    class RandomDirection : Cell
    {
        private Random R;
        public RandomDirection(int x, int y) : base(x,y, '?') { R = new Random(); }
        public Point getRandomDirectionPoint()
        {
            Direction dir = new Direction(X, Y, R.Next(4));
            return new Point(dir.vX, dir.vY);
        }
    }
    class DestoyAble : Cell
    {
        public DestoyAble(int x, int y) : base(x, y, '~') { }
    }
    class ShieldNotAllowed : Cell
    {
        public ShieldNotAllowed(int x, int y) : base(x,y,':') { }
    }
}