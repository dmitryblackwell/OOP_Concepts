using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts.MinedOut
{
    class Map
    {
        private String[] map =
        {
            "#               B  #",
            "#               B  #",
            "#           B      #",
            "#          B  B    #",
            "#     PB   B  B    #",
            "#          B  B    #",
            "#  B               #",
            "#         B    B   #",
            "# B  B     B B     #",
            "####################",
        };
        public void movePlayerRight()
        {
            for (int i = 0; i < map.Length; ++i)
            {
                StringBuilder sb = new StringBuilder(map[i]);
                for(int j = 0; j < sb.Length; ++j)
                {
                    if (sb[j] == 'P') {
                        sb[j] = ' ';
                        sb[++j] = 'P';
                        break;
                     }
                }
                map[i] = sb.ToString();
            }
        }
        public void drawMap()
        {
            for (int i = 0; i < map.Length; ++i)
            {
                for (int j = 0; j < map[i].Length; ++j)
                {
                    String SymbolToDraw;
                    switch (map[i][j])
                    {
                        case 'B':
                            SymbolToDraw = " ";
                            break;
                        case 'P': // TODO rewright realization for Player
                            int bombCount = 0;
                            if (map[i][j + 1] == 'B')
                                bombCount++;
                            if (map[i][j - 1] == 'B')
                                bombCount++;
                            if (map[i + 1][j] == 'B')
                                bombCount++;
                            if (map[i - 1][j] == 'B')
                                bombCount++;
                            SymbolToDraw = bombCount.ToString();
                            break;
                        default:
                            SymbolToDraw = map[i][j].ToString(); ;
                            break;
                    }
                    Console.Write(SymbolToDraw);
                }
                Console.Write("\n");
            }

        }
    }
}
