using System;

namespace OOP_Concepts.BallGame
{
    // структура с кординатами x y
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x_, int y_) { X = x_; Y = y_; }
    }
    class Map
    {
        private char[,] map; // двухмерный массив чаров
        private Point shield; // кординаты щита
        private Point ball; // кординаты мяча
        private int vX = -1; // направление движения по Х, может быть -1, 0, 1
        private int vY = 0; // тоже самое для y
        private int totalBalls = 0; // всего мячей
        private int ballsDown = 0; // мячей сбили
        private bool settlementShield = false; // нужно ли устанавливать щит

        public Map(String[] MapStr)
        {
            // инициализируем карту
            map = new char[MapStr.Length, MapStr[0].Length];
            for (int i = 0; i < map.GetLength(0); ++i)
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    map[i, j] = MapStr[i][j]; // копируем туда символ из строки
                    if (map[i, j] == '/' || map[i, j] == '\\')
                        shield = new Point(j, i);
                    if (map[i, j] == '.')
                        ball = new Point(j, i);
                    if (map[i, j] == '@')
                        totalBalls++;
                }
        }


        public void draw() // рисум карту
        {
            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
                    Console.Write(map[i, j]);
                Console.Write("\n");
            }
        }

        public bool isGameOn() // проверка собрали мы мячи или нет
        {
            return ballsDown < totalBalls;
        }

        // движение щита в разные стороны
        public void moveLeft() { move(-1, 0); }
        public void moveRight() { move(1, 0); }
        public void moveUp() { move(0, -1); }
        public void moveDown() { move(0, 1); }

        // движение щита, вызывается методами выше
        private void move(int vX, int vY)
        {
            if (map[shield.Y + vY, shield.X + vX] == ' ')
            {
                map[shield.Y + vY, shield.X + vX] = map[shield.Y, shield.X];
                if (!settlementShield) // если щит не надо устанавливать
                    map[shield.Y, shield.X] = ' ';
                shield.X += vX;
                shield.Y += vY;
                settlementShield = false;
            }

        }

        // движение мячика
        public void BallStep()
        {
            switch (map[ball.Y + vY, ball.X + vX])
            {
                case '@':
                    ballsDown++;
                    moveBall();
                    break;
                case ' ':
                    moveBall();
                    break;
                case '#':
                    vY *= -1;
                    vX *= -1;
                    break;
                case '\\':
                    swapVelocity();
                    changeBallCoords();
                    // -1  0 ==>  0 -1
                    //  1  0 ==>  0  1
                    //  0  1 ==>  1  0
                    //  0 -1 ==> -1  0
                    break;
                case '/':
                    swapVelocity();
                    vX *= -1;
                    vY *= -1;
                    changeBallCoords();

                    //  1  0 ==>  0 -1
                    // -1  0 ==>  0  1
                    //  0  1 ==> -1  0
                    //  0 -1 ==>  0  1
                    break;
            }
        }

        // меняем переменны направления мяча
        private void swapVelocity()
        {
            map[ball.Y, ball.X] = ' ';
            changeBallCoords();
            int tmp = vX;
            vX = vY;
            vY = tmp;
        }
        // передвигаем мячик
        private void moveBall()
        {
            map[ball.Y + vY, ball.X + vX] = '.';
            map[ball.Y, ball.X] = ' ';
            changeBallCoords();
        }
        // двигаем мячик
        private void changeBallCoords()
        {
            ball.X += vX;
            ball.Y += vY;
        }
        // меняем щиты
        public void swapShields()
        {
            map[shield.Y, shield.X] = (map[shield.Y, shield.X] == '/') ? '\\' : '/';
        }
        // устанавливаем щит
        public void settleShield()
        {
            settlementShield = true;
        }

    }
}



// The Veer Union - Another World Away
// Blackbriar - Preserved Roses
// Art of Chaos - Obsession (Surrender Me)
// Into the Fire - Spit You Out