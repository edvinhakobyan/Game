using System;
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
        private const int amountTanks = 10;
        private const int amountsApples = 20;
        private const int gameSpeed = 20;

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
            model = new Model( fieldSize,  amountTanks,  amountsApples,  gameSpeed);
            view = new View(model);
            this.Controls.Add(view);
        }

        private  void button1_Click(object sender, EventArgs e)
        {
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

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            myMathod(e);
        }

        private void Controller_KeyPress(object sender, KeyPressEventArgs e)
        {
            myMathod(e);
        }


        void myMathod(KeyPressEventArgs e)
        {
            if (model.packman.X % 40 == 0 && model.packman.Y % 40 == 0)
            {
                switch (e.KeyChar.ToString().ToLower())
                {
                    case "a": model.packman.Dir = DirectionEnum.Left; break;
                    case "d": model.packman.Dir = DirectionEnum.Right; break;
                    case "w": model.packman.Dir = DirectionEnum.Up; break;
                    case "s": model.packman.Dir = DirectionEnum.Down; break;
                    default: break;
                }
            }
        }
    }
}
