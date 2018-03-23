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
                case Keys.W:
                case Keys.Up:
                    map.movePlayerUp();
                    break;
                case Keys.S:
                case Keys.Down:
                    map.movePlayerDown();
                    break;
                case Keys.D:
                case Keys.Right:
                    map.movePlayerRight();
                    break;
                case Keys.A:
                case Keys.Left:
                    map.movePlayerLeft();
                    break;
            }
            if (map.isGameFinish() == (int)Map.GameEnd.Dead)
            {
                MessageBox.Show("You dead!");
                this.Close();
            }
            else if (map.isGameFinish() == (int)Map.GameEnd.Finish)
            {
                String promptValue = Prompt.ShowDialog();
                Rating r = new Rating();
                r.save(promptValue, map.GetPlayer().giveMeYourMoney());
                this.Close();
            }
            else if (map.isGameFinish() == (int)Map.GameEnd.Continue)
            {
                Invalidate();
            }
                return true;
        }
        public static class Prompt
        {
            public static String ShowDialog()
            {
                Form prompt = new Form();
                prompt.Width = 300;
                prompt.Height = 200;
                prompt.Text = "Game finish";
                Label textLabel = new Label() { Left = 50, Top = 20, Text = "Enter yout name: " };
                TextBox tb = new TextBox() { Left = 50, Top = 50, Width = 200 };
                Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 100 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(tb);
                prompt.ShowDialog();
                return tb.Text;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Font myFont = new Font("MapFont", 10, FontStyle.Bold);
            const int SIZE = 15;

            Image heart = Image.FromFile("img/like.png");
            Image block = Image.FromFile("img/check-box-empty.png");
            Image coin = Image.FromFile("img/coin.png");

            for (int i = 0; i < map.GetLengthY(); ++i)
            {
                for (int j = 0; j < map.GetLengthX(); ++j)
                {
                    string symbol = map.getSymbolFor(i, j).ToString();
                    switch (symbol)
                    {
                        case "#":
                            e.Graphics.DrawImage(block, SIZE * j, SIZE * i, SIZE, SIZE);
                            break;
                        case "$":
                            e.Graphics.DrawImage(coin, SIZE * j, SIZE * i, SIZE, SIZE);
                            break;
                        case "@":
                            e.Graphics.DrawImage(heart, SIZE * j, SIZE * i, SIZE, SIZE);
                            break;
                        default:
                            e.Graphics.DrawString(symbol, myFont, Brushes.Black, j * SIZE, i * SIZE);
                            break;
                    }
                }
            }

            e.Graphics.DrawString("Lifes: "+map.GetPlayer().getLifes().ToString(), myFont, Brushes.Black, map.GetLengthX() , map.GetLengthY() * 15);
            e.Graphics.DrawString("Money: "+map.GetPlayer().giveMeYourMoney().ToString(), myFont, Brushes.Black, map.GetLengthX(),  map.GetLengthY()*16);
         }
        
        private void createBtn_Click(object sender, EventArgs e)
        {
            // create your own map
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            map.save();
        }
        private void loadBtn_Click(object sender, EventArgs e)
        {
            map.load();
            Invalidate();
        }

        private void ratingBtn_Click(object sender, EventArgs e)
        {
            Rating r = new Rating();
            String[][] rate = r.load();
            String oneRate = "";
            for (int i = 0; i < rate.Length; ++i)
            {
                for (int j = 0; j < rate[0].Length; ++j)
                {
                    oneRate += rate[i][j] + " ";
                }
                oneRate += "\n";
            }
            MessageBox.Show(oneRate);
        }

        

        private void GraphicalUI_Load(object sender, EventArgs e)
        {
            // window is load
        }
    }
}
