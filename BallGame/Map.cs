using System;
using System.Text;

namespace OOP_Concepts.BallGame
{
    // структура с кординатами x y
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x_, int y_) { X = x_; Y = y_; }
    }
    partial class Map
    {
        private Cell[,] map; // двухмерный массив 
        private Shield shield; // кординаты щита
        private Ball ball; // кординаты мяча
        private Teleport teleport = new Teleport();
        private Random R = new Random();
        private bool settlementShield = false; // нужно ли устанавливать щит
        private bool alive = true;
        private char[,] mapPriv;
        private const int randWidth = 20;
        private const int randHeight = 7;
        

        public void draw() // рисум карту
        {
            int CursotTop = Console.CursorTop;
            for (int i = 0; i < map.GetLength(0); ++i)
                for (int j = 0; j < map.GetLength(1); ++j)
                    map[i, j].draw();
                
            Console.SetCursorPosition(0, CursotTop);
        }

        public bool isGameOn() // проверка собрали мы мячи или нет
        {
            for (int i = 0; i < map.GetLength(0); ++i)
                for (int j = 0; j < map.GetLength(1); ++j)
                    if (map[i, j].GetType() == typeof(Energy))
                        return true;
            return false;
        }

        public bool isAlive() { return alive; }

        // движение щита в разные стороны
        public void moveLeft() { move(-1, 0); }
        public void moveRight() { move(1, 0); }
        public void moveUp() { move(0, -1); }
        public void moveDown() { move(0, 1); }

        // движение щита, вызывается методами выше
        private void move(int vX, int vY)
        {
            if (map[shield.Y + vY, shield.X + vX].GetType() == typeof(Empty))
            {
                map[shield.Y + vY, shield.X + vX] = shield;
                if (!settlementShield) // если щит не надо устанавливать
                    map[shield.Y, shield.X] = new Empty(shield.X, shield.Y);
                shield.X += vX;
                shield.Y += vY;
                settlementShield = false;
            }
        }
        public void setShieldNotAlloweded()
        {
            Point p = new Point();
            do
            {
                p = new Point(
                 R.Next(map.GetLength(1) - 3) + 2,
                 R.Next(map.GetLength(0) - 3) + 2);
            } while ((p.X == ball.X && p.Y == ball.Y) || (p.X == shield.X && p.Y == shield.Y));
            map[p.Y, p.X] = new ShieldNotAllowed(p.X, p.Y);
        }
        // движение мячика
        public void BallStep()
        {
            try
            {
                Cell nextCell = map[ball.Y + ball.vY, ball.X + ball.vX];
                if (nextCell.GetType() == typeof(Energy))
                {
                    Energy.plusBallsDown();
                    moveBall();
                }
                if (nextCell.GetType() == typeof(Empty) || nextCell.GetType() == typeof(DestoyAble))
                {
                    moveBall();
                }
                if (nextCell.GetType() == typeof(Wall) || nextCell.GetType() == typeof(ShieldNotAllowed))
                {
                    ball.vY *= -1;
                    ball.vX *= -1;
                }
                if (nextCell.GetType() == typeof(Shield))
                {
                    swapVelocity();
                    if (!shield.isReverse())
                    {
                        ball.vX *= -1;
                        ball.vY *= -1;
                    }
                    ball.moveInside();
                }
                if (nextCell.GetType() == typeof(Teleport))
                {
                    // отладка дает предаставление о вечности
                    Point coords = teleport.getSecond(ball.X + ball.vX, ball.Y + ball.vY);
                    map[ball.Y, ball.X] = new Empty(ball.X, ball.Y);
                    ball.X = coords.X;
                    ball.Y = coords.Y;
                    moveBall();
                }
                if(nextCell.GetType() == typeof(Trap))
                {
                    ball.vX = 0;
                    ball.vY = 0;
                    alive = false;
                }
                if(nextCell.GetType() == typeof(Direction))
                {
                    swapVelocity();
                    ball.vX = ((Direction)nextCell).vX;
                    ball.vY = ((Direction)nextCell).vY;
                    ball.moveInside();
                }
                if(nextCell.GetType() == typeof(RandomDirection))
                {
                    swapVelocity();
                    Point rp = ((RandomDirection)nextCell).getRandomDirectionPoint();
                    ball.vX = rp.X;
                    ball.vY = rp.Y;
                    ball.moveInside();
                }
            }
            catch (IndexOutOfRangeException e) { }
                //case '\\':
                    // -1  0 ==>  0 -1
                    //  1  0 ==>  0  1
                    //  0  1 ==>  1  0
                    //  0 -1 ==> -1  0
                //case '/':
                    //  1  0 ==>  0 -1
                    // -1  0 ==>  0  1
                    //  0  1 ==> -1  0
                    //  0 -1 ==>  0  1
        }

        // меняем переменны направления мяча
        private void swapVelocity()
        {
            map[ball.Y, ball.X] = new Empty(ball.X, ball.Y); ;
            ball.moveInside();
            ball.swapCoords();
        }
        // передвигаем мячик
        private void moveBall()
        {
            map[ball.Y + ball.vY, ball.X + ball.vX] = ball;
            map[ball.Y, ball.X] = new Empty(ball.X, ball.Y);
            ball.moveInside();
        }
        
        // меняем щиты
        public void swapShields()
        {
            shield.swap();
        }
        // устанавливаем щит
        public void settleShield()
        {
            map[shield.Y, shield.X] = new Shield(shield.X, shield.Y, shield.getShieldChar());
            settlementShield = true;
        }

        public int getShieldsOnMap()
        {
            int shieldsCount = 0;
            for (int i = 0; i < map.GetLength(0); ++i)
                for (int j = 0; j < map.GetLength(1); ++j)
                    if (map[i, j].GetType() == typeof(Shield))
                        shieldsCount++;
            return shieldsCount;
        }
    }
}

// The Veer Union - Another World Away
// Blackbriar - Preserved Roses
// Art of Chaos - Obsession (Surrender Me)
// Into the Fire - Spit You Out
// Shatterproof - Cookie cutter Life
// D.R.U.G.S - If You Think This Song Is About You, It Probably Is
// For Every Day - Great Unknown
// Lowborn - Crazy
// The Night Of - Set Me Free
// Ashe - Used to it
// Porcelain Black And The Tramps - Gaspline
// Envoi - Ghost
// Loser - The First Time
// Onlap - Whispers In My Head
// MaNga - We Could Be The Same
// Battle Beast - King for a Day