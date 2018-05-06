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
    class Map
    {
        private Cell[,] map; // двухмерный массив 
        private Shield shield; // кординаты щита
        private Ball ball; // кординаты мяча
        private bool settlementShield = false; // нужно ли устанавливать щит
        private char[,] mapPriv;
        // Индексатор для матрицы: для получения экземпляра конкретного элемента поля
        public Cell this[int x, int y]
        {
            set { map[y,x] = value; }
            get { return map[y,x]; }
        }
        private const int randWidth = 20;
        private const int randHeight = 7;
        public Map()
        {
            char[][] gen = new char[randHeight][];
            Random R = new Random();
            for (int i = 0; i < randHeight; ++i)
            {
                gen[i] = new char[randWidth];
                for (int j = 0; j < randWidth; ++j)
                {

                    if (i == 0 || i == randHeight-1 || j == 0 || j == randWidth-1)
                        gen[i][j] = '#';
                    else
                        switch (R.Next(20))
                        {
                            case 0:
                            case 1: gen[i][j] = '#'; break;
                            case 2: gen[i][j] = '@'; break;
                            default: gen[i][j] = ' '; break;
                        }
                }
            }
            gen[R.Next(randHeight)][R.Next(randWidth)] = '/';
            gen[R.Next(randHeight)][R.Next(randWidth)] = '.';

            String[] res = new String[randHeight];
            for (int i = 0; i < randHeight; ++i)
                res[i] = new String(gen[i]);
            mapInit(res);
        }
        private void replaceRandom(String[] mapStr, char ch)
        {
            Random R = new Random();
            int line = R.Next(randHeight);
            int collumn;
            StringBuilder sb = new StringBuilder(mapStr[line]);
            do
            {
                collumn = R.Next(randWidth);
            } while (sb[collumn] == '/');
            sb[collumn] = ch;
            mapStr[line] = sb.ToString();
        }
        public Map(String[] MapStr)     {   mapInit(MapStr);   }
        private void mapInit(String[] MapStr)
        {
            // инициализируем карту
            map = new Cell[MapStr.Length, MapStr[0].Length];
            mapPriv = new char[MapStr.Length, MapStr[0].Length];

            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    switch (MapStr[i][j])
                    {
                        case '\\':
                        case '/':
                            shield = new Shield(j, i);
                            map[i, j] = shield;
                            break;
                        case '.':
                            ball = new Ball(j, i);
                            map[i, j] = ball;
                            break;
                        case '@':
                            map[i, j] = new Energy(j, i);
                            Energy.plusTotalBall();
                            break;
                        case '#':
                            map[i, j] = new Wall(j, i);
                            break;
                        case ' ':
                            map[i, j] = new Empty(j, i);
                            break;
                    }
                    mapPriv[i, j] = map[i, j].getSymbol();
                }
                Console.WriteLine();
            }
        }

        public void draw() // рисум карту
        {
            int CursotTop = Console.CursorTop;
            for (int i = 0; i < map.GetLength(0); ++i)
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    if(map[i, j].GetType() == typeof(Ball))
                        Console.ForegroundColor = ConsoleColor.Red;
                    map[i, j].draw();
                }
            Console.SetCursorPosition(0, CursotTop);
            
        }

        public bool isGameOn() // проверка собрали мы мячи или нет
        {
            return Energy.isDownLess();
        }

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
                if (!shield.isReverse()) {
                    ball.vX *= -1;
                    ball.vY *= -1;
                }
                ball.moveInside();
            }
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