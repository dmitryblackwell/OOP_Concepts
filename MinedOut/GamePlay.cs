using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOP_Concepts.MinedOut
{
    class GamePlay
    {
        Map map = new Map(CustomMaps.advanceMapFree);
        ConsoleUI cui = new ConsoleUI(CustomMaps.advanceMapFree);

        public GamePlay(bool isConsole)
        {
            if (isConsole)
            {
                cui.Run();
                Console.Clear();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GraphicalUI());
            }


        }
    }
}
