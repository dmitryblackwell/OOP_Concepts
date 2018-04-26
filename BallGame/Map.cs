using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OOP_Concepts.BallGame
{
    class Map
    {
        private char[,] map;
        private Point shield;
        private Point ball;
        private int vX = -1;
        private int vY = 0;
        public Map(String[] MapStr)
        {
            map = new char[MapStr.Length,MapStr[0].Length];
            for (int i = 0; i < map.GetLength(0); ++i)
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    map[i, j] = MapStr[i][j];
                    if (map[i, j] == '/' || map[i,j] == '\\')
                        shield = new Point(j, i);
                    if (map[i, j] == '.')
                        ball = new Point(j, i);
                }
        }


        public void draw()
        {
            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
                    Console.Write(map[i, j]);
                Console.Write("\n");
            }
        }

        public bool isGameOn()
        {
            return true; // TODO game ending
        }

        public void moveLeft() { move(-1, 0); }
        public void moveRight() { move(1, 0); }
        public void moveUp() { move(0, -1); }
        public void moveDown() { move(0, 1); }

        private void move(int vX, int vY)
        {
            if (map[shield.Y + vY, shield.X + vX] == ' ')
            {
                map[shield.Y + vY, shield.X + vX] = map[shield.Y, shield.X];
                map[shield.Y, shield.X] = ' ';
                shield.X += vX;
                shield.Y += vY;
            }

        }

        public void BallStep()
        {
            switch(map[ball.Y + vY, ball.X + vX])
            {
                case '@':
                case ' ':
                    moveBall();
                    break;
                case '#':
                    vY *= -1;
                    vX *= -1;
                    break;
                case '\\':
                    swapVelocity();
                    moveBall();
                    // -1  0 ==>  0 -1
                    //  1  0 ==>  0  1
                    //  0  1 ==>  1  0
                    //  0 -1 ==> -1  0
                    break;
                case '/':
                    swapVelocity();
                    vX *= -1;
                    vY *= -1;
                    moveBall();
                    //  1  0 ==>  0 -1
                    // -1  0 ==>  0  1
                    //  0  1 ==> -1  0
                    //  0 -1 ==>  0  1
                    break;
            }
        }

        private void swapVelocity()
        {
            int tmp = vX;
            vX = vY;
            vY = tmp;
        }
        private void moveBall()
        {
            map[ball.Y + vY, ball.X + vX] = '.';
            map[ball.Y, ball.X] = ' ';
            changeBallCoords();
        }
        private void changeBallCoords()
        {
            ball.X += vX;
            ball.Y += vY;
        }


    }
}



// The Veer Union - Another World Away
// Blackbriar - Preserved Roses