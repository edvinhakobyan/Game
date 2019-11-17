using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tanks
{
    public partial class View : UserControl
    {
        Model model;

        public View(Model model)
        {
            this.model = model;
            InitializeComponent();
        }

        public void Drow(PaintEventArgs e)
        {
            DrowWall(e);
            DrowApples(e);
            DrowTank(e);
            DrowPackman(e);
            Thread.Sleep(model.GameSpeed);
            Invalidate();
        }

        private void DrowPackman(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.packman.Img, new Point(model.packman.X, model.packman.Y));
        }

        private void DrowApples(PaintEventArgs e)
        {
            for (int i = 0; i < model.AmountsApples; i++)
                e.Graphics.DrawImage(model.Apples[i].Img, new Point(model.Apples[i].X, model.Apples[i].Y));
        }

        private void DrowTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.AmountTanks; i++)
                e.Graphics.DrawImage(model.Tanks[i].Img, new Point(model.Tanks[i].X, model.Tanks[i].Y));
        }

        private void DrowWall(PaintEventArgs e)
        {
            for (int x = 20; x < 500; x += 40)
                for (int y = 20; y < 500; y += 40)
                    e.Graphics.DrawImage(model.Wall.Img, new Point(x, y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Drow(e);
        }

        private void View_KeyPress(object sender, KeyPressEventArgs e)
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
