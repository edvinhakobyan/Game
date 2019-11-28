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

        private void DrowRectangle(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 0, 0, 500, 500);
            label2.Text = model.AppleCount.ToString();
            label4.Text = model.AppleCount.ToString();
            label1.Refresh();
            label2.Refresh();
            label3.Refresh();
            label4.Refresh();
        }

        private void DrowPackman(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.packman.Img, new Point(model.packman.X, model.packman.Y));
        }

        private void DrowApples(PaintEventArgs e)
        {
            for (int i = 0; i < model.Apples.Count; i++)
                e.Graphics.DrawImage(model.Apples[i].Img, new Point(model.Apples[i].X, model.Apples[i].Y));
        }

        private void DrowTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.Tanks.Count; i++)
            {
                e.Graphics.DrawImage(model.Tanks[i].Img, new Point(model.Tanks[i].X, model.Tanks[i].Y));
            }
        }

        private void DrowWall(PaintEventArgs e)
        {
            for (int x = 20; x < 500; x += 40)
                for (int y = 20; y < 500; y += 40)
                    e.Graphics.DrawImage(model.Wall.Img, new Point(x, y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrowWall(e);
            DrowApples(e);
            DrowTank(e);
            DrowSnaryads(e);
            DrowPackman(e);

            DrowRectangle(e);
            Thread.Sleep(model.GameSpeed);
            Invalidate();
        }

        private void DrowSnaryads(PaintEventArgs e)
        {
            foreach (var snaryad  in model.Tanks.Select(t => t.snaryad))
            {
                if(snaryad != null)
                e.Graphics.DrawImage(snaryad.Img, new Point(snaryad.X, snaryad.Y));
            }

            if (model.packman.snaryad != null)
                e.Graphics.DrawImage(model.packman.snaryad.Img, new Point(model.packman.snaryad.X, model.packman.snaryad.Y));

        }
    }
}
