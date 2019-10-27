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
            e.Graphics.DrawImage(model.Tank.Image, new Point(model.Tank.X, model.Tank.Y));

            Thread.Sleep(model.gameSpeed);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Drow(e);
        }

    }
}
