using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class Tank
    {
        public Image Image = Properties.Resources.TankImg01;

        public int X;
        public int Y;

        public void Run()
        {
            X = ++Y;
        }


    }
}
