using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOP_Concepts.MinedOut
{
    public partial class GraphicalUI : Form
    {

        private Map map = new Map(CustomMaps.advanceMapFree);
        public GraphicalUI()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //handle your keys here
            switch (keyData)
            {
                case Keys.Up:
                    map.movePlayerUp();
                    break;
                case Keys.Down:
                    map.movePlayerDown();
                    break;
                case Keys.Right:
                    map.movePlayerRight();
                    break;
                case Keys.Left:
                    map.movePlayerLeft();
                    break;
            }
            if (!map.isGameFinish())
                 Invalidate();
            else
            {
                this.Close();   
            }
            return true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Font myFont = new Font("MapFont", 10, FontStyle.Regular);
            

            for (int i = 0; i < map.GetLengthY(); ++i)
            {
                for (int j = 0; j < map.GetLengthX(); ++j)
                {
                    string symbol = map.getSymbolFor(i, j).ToString();
                    e.Graphics.DrawString(symbol, myFont, Brushes.Black, j*10, i * 10);
                }
            }

            e.Graphics.DrawString("Lifes: "+map.GetPlayer().getLifes().ToString(), myFont, Brushes.Black, map.GetLengthX() , map.GetLengthY() * 13);
            e.Graphics.DrawString("Money: "+map.GetPlayer().giveMeYourMoney().ToString(), myFont, Brushes.Black, map.GetLengthX(), map.GetLengthY()*14);
            /*
            Console.WriteLine("\n");
            Console.WriteLine("Lifes: " + ;
            Console.WriteLine("Money: " + map.GetPlayer().giveMeYourMoney());*/
        }
    }
}
