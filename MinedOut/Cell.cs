using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.MinedOut
{
    class Cell
    {
        public enum Field { FREE_SPACE, WALL, BOMB, PLAYER, DOT, MONEY };
        private char symbol;
        private int key;
        /* 
        * 0   - free space
        * 1 # - wall
        * 2 B - bomb
        * 3 P - player
        * 4 . - dot
        * 5 $ - money
        * */
        public Cell(int k)
        {
            symbol = getSymbol(k);
            key = k;
        }
        public Cell(char s)
        {
            symbol = s;
            key = getKey(s);
        }
        public Cell(Field f)
        {
            symbol = getSymbol((int)f);
            key = getKey(symbol);
        }
        public void print()
        {
           /* if (key == (int)Field.BOMB)
                Console.Write(getSymbol((int)Field.FREE_SPACE));
            else*/
                Console.Write(symbol);
        }
        public bool isThisBomb()
        {
            return key == (int) Field.BOMB;
        }
        public bool isThisPlayer()
        {
            return key == (int) Field.PLAYER;
        }
        /* Унарный опертор
        public static Cell operator ++(Cell c)
        {
            c.key++;
            if (c.key > getFieldLength())
                c.key = 0;
            return c;
        }
        public static Cell operator --(Cell c)
        {
            c.key--;
            if (c.key < 0)
                c.key = getFieldLength();
            return c;
        }
        private static int getFieldLength()
        {
            return Enum.GetNames(typeof(Field)).Length;
        }
        */
        private char getSymbol(int key)
        {
            char ch;
            switch (key)
            {
                default:
                case (int)Field.FREE_SPACE:
                    ch = ' ';
                    break;
                case (int)Field.WALL:
                    ch = '#';
                    break;
                case (int)Field.BOMB:
                    ch = 'B';
                    break;
                case (int)Field.PLAYER:
                    ch = 'P';
                    break;
                case (int)Field.DOT:
                    ch = '.';
                    break;
                case (int)Field.MONEY:
                    ch = '$';
                    break;
            }
            return ch;
        }
        private int getKey(char ch)
        {
            int elementCode;
            switch (ch)
            {
                default:
                case ' ':
                    elementCode = (int)Field.FREE_SPACE;
                    break;
                case '#':
                    elementCode = (int)Field.WALL;
                    break;
                case 'B':
                    elementCode = (int)Field.BOMB;
                    break;
                case 'P':
                    elementCode = (int)Field.PLAYER;
                    break;
                case '.':
                    elementCode = (int)Field.DOT;
                    break;
                case '$':
                    elementCode = (int)Field.MONEY;
                    break;
            }
            return elementCode;
        }
    }
}
