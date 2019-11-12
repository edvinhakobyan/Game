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
            DrowTank(e);
            Thread.Sleep(model.GameSpeed);
            Invalidate();
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
                    e.Graphics.DrawImage(model.Wall._img, new Point(x, y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Drow(e);
        }

    }
}
