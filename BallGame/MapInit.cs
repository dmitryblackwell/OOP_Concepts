using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.BallGame
{
    partial class Map
    {
        // Индексатор для матрицы: для получения экземпляра конкретного элемента поля
        public Cell this[int x, int y]
        {
            set { map[y, x] = value; }
            get { return map[y, x]; }
        }
        public Map()
        {
            char[][] gen = new char[randHeight][];
            Random R = new Random();
            for (int i = 0; i < randHeight; ++i)
            {
                gen[i] = new char[randWidth];
                for (int j = 0; j < randWidth; ++j)
                {
                    if (i == 0 || i == randHeight - 1 || j == 0 || j == randWidth - 1)
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

            Point p1 = getRandomPoint(R);
            Point p2 = new Point();
            do
            {
                p2 = getRandomPoint(R);
            } while (p2.X == p1.X && p2.Y == p1.Y);
            gen[p2.Y][p2.X] = '/';
            //Console.WriteLine(p2.X+":"+p2.Y + "\n" + p1.X+":"+p2.Y);
            gen[p1.Y][p1.X] = '.';

            String[] res = new String[randHeight];
            for (int i = 0; i < randHeight; ++i)
                res[i] = new String(gen[i]);
            mapInit(res);
        }
        private bool isMapOk()
        {
            bool isThereBall = false;
            bool isThereEnergy = false;
            bool isThereShield = false;
            for(int i=0; i<map.GetLength(0); ++i)
                for(int j=0; j<map.GetLength(1); ++j)
                {
                    if (map[i, j].GetType() == typeof(Ball))
                        isThereBall = true;
                    if (map[i, j].GetType() == typeof(Energy))
                        isThereEnergy = true;
                    if (map[i, j].GetType() == typeof(Shield))
                        isThereShield = true;
                }
            return isThereShield && isThereEnergy && isThereBall;
                
        }
        private Point getRandomPoint(Random R)
        {
            return new Point(
                R.Next(randWidth - 3) + 2,
                R.Next(randHeight - 3) + 2);
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
        public Map(String[] MapStr) { mapInit(MapStr); }
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
                        default:
                        case '#':
                            map[i, j] = new Wall(j, i);
                            break;
                        case ' ':
                            map[i, j] = new Empty(j, i);
                            break;
                        case '0':
                            map[i, j] = teleport;
                            teleport.set(j, i);
                            break;
                        case '!':
                            map[i, j] = new Trap(j, i);
                            break;
                        case '|':
                            map[i, j] = new Direction(j, i, 3);
                            break;
                        case '>':
                            map[i, j] = new Direction(j, i, 0);
                            break;
                        case '<':
                            map[i, j] = new Direction(j, i, 2);
                            break;
                        case '^':
                            map[i, j] = new Direction(j, i, 1);
                            break;
                        case '?':
                            map[i, j] = new RandomDirection(j, i);
                            break;
                        case '~':
                            map[i, j] = new DestoyAble(j, i);
                            break;
                        case ':':
                            map[i, j] = new ShieldNotAllowed(j, i);
                            break;
                    }
                    mapPriv[i, j] = map[i, j].getSymbol();
                }
                Console.WriteLine();
            }
        }
    }
}
