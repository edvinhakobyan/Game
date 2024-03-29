﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Controller : Form
    {
        private const int fieldSize = 500;
        private const int amountTanks = 4;
        private const int amountsApples = 40;
        private const int gameSpeed = 30;

        public Controller() : this(fieldSize) { }

        public Controller(int fieldSize) : this(fieldSize, amountTanks) { }

        public Controller(int fieldSize, int amountTanks) : this(fieldSize, amountTanks, amountsApples) { }

        public Controller(int fieldSize, int amountTanks, int amountsApples) : this(fieldSize, amountTanks, amountsApples, gameSpeed) { }

        Model model;
        View view;
        Thread thread;
        public Controller(int fieldSize, int amountTanks, int amountsApples, int gameSpeed)
        {
            InitializeComponent();
            model = new Model(fieldSize, amountTanks, amountsApples, gameSpeed);
            view = new View(model);
            this.Controls.Add(view);

        }

        private  void button1_Click(object sender, EventArgs e)
        {
            this.Focus();
            if (model.GameStatus == GameStatus.Play)
            {
                thread.Abort();
                model.GameStatus = GameStatus.Stop;
            }
            else
            {
                model.GameStatus = GameStatus.Play;
                thread = new Thread(() => model.Play())
                {
                    IsBackground = true
                };
                thread.Start();
                view.Invalidate();
            }
        }

        private void Controller_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(thread != null)
            thread.Abort();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keys)
        {
            switch (keys)
            {
                case Keys.Left:  { model.packman.nextDir = DirectionEnum.Left; } break;
                case Keys.Right: { model.packman.nextDir = DirectionEnum.Right; } break;
                case Keys.Up:    { model.packman.nextDir = DirectionEnum.Up; } break;
                case Keys.Down: { model.packman.nextDir = DirectionEnum.Down; } break;
                case Keys.Space: model.packman.Shuth(); break;
                default: break;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.NewGame();
        }
    }
}
