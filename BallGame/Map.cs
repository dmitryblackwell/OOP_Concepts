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
                if (nextCell.GetType() == typeof(Empty))
                {
                    moveBall();
                }
                if (nextCell.GetType() == typeof(Wall))
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