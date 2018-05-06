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
                    }
                    mapPriv[i, j] = map[i, j].getSymbol();
                }
                Console.WriteLine();
            }
        }
    }
}
