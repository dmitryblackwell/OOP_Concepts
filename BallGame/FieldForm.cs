﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOP_Concepts.BallGame
{
    public partial class FieldForm : Form
    {
        private Map map;
        private PictureBox[][] field;
        private const int SHIFT = 30;
        private const string ENERGY_IMG = "img/green-energy.png";
        private const string BALL_IMG = "img/ultra-ball.png";
        private const string WALL_IMG = "img/brick-wall.png";
        private const string SHIELD1_IMG = "img/shield1.png";
        private const string SHIELD2_IMG = "img/shield2.png";
        private const string SPIDER_WEB_IMG = "img/spider-web.png";
        public FieldForm()
        {
            InitializeComponent();

            map = new Map(new String[]
                {   "##################",
                    "# @@  #### @@@   #",
                    "#  /  !!!!       #",
                    "#     !!@@       #",
                    "#!    !!!!       #",
                    "#!  @           .#",
                    "#!   @           #",
                    "##################"    });
            field = new PictureBox[map.getHeight()][];
            for (int i = 0; i < map.getHeight(); ++i)
            {
                field[i] = new PictureBox[map.getWidth()];
                for (int j = 0; j < map.getWidth(); ++j)
                {
                    field[i][j] = new PictureBox();
                    field[i][j].Top = i * SHIFT;
                    field[i][j].Left = j * SHIFT;
                    

                    field[i][j].Font = new Font("Arial", 16);
                    field[i][j].Width = SHIFT;
                    field[i][j].Height = SHIFT;
                    Controls.Add(field[i][j]);
                }
            }

            BackColor = Color.FromArgb(34, 112, 129);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(Run);
            timer.Interval = 400;
            timer.Start();

        }

      
        private void Run(object sender, EventArgs e)
        {
            map.BallStep();
            for (int i = 0; i < map.getHeight(); ++i)
                for (int j = 0; j < map.getWidth(); ++j)
                {
                    switch (map.getCellChar(i, j))
                    {
                        case '#': field[i][j].ImageLocation = WALL_IMG; break;
                        default:
                        case ' ': field[i][j].ImageLocation = null; break;
                        case '.': field[i][j].ImageLocation = BALL_IMG; break;
                        case '/': field[i][j].ImageLocation = SHIELD2_IMG; break;
                        case '\\': field[i][j].ImageLocation = SHIELD1_IMG; break;
                        case '@': field[i][j].ImageLocation = ENERGY_IMG; break;
                        case '!': field[i][j].ImageLocation = SPIDER_WEB_IMG; break;
                    }
                }
            Refresh();
            
        }

        private void MainForm_Press(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 'A' || e.KeyChar == 'a')
                map.moveLeft();

            if (e.KeyChar == 'D' || e.KeyChar == 'd')
                map.moveRight();

            if (e.KeyChar == 'W' || e.KeyChar == 'w')
                map.moveUp();

            if (e.KeyChar == 'S' || e.KeyChar == 's')
                map.moveDown();

            if (e.KeyChar == ' ')
                map.swapShields();
        }
    }
}
