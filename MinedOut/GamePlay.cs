using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOP_Concepts.MinedOut
{
    class GamePlay
    {
        Map map = new Map(CustomMaps.startMap);
        ConsoleUI cui = new ConsoleUI(CustomMaps.startMap);

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
                try
                {
                    Application.SetCompatibleTextRenderingDefault(false);
                } catch(System.InvalidOperationException e)
                {

                }
                Application.Run(new GraphicalUI());
            }


        }
    }
}
