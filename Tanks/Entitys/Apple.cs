using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Apple : IPicture
    {
        AppleImg _wallImg = new AppleImg();
        public Image Img { get; }

        public int X { get; set; }
        public int Y { get; set; }

        public Apple(int x, int y)
        {
            Img = _wallImg.img;
            X = x;
            Y = y;
        }

        public bool Equals(Tank other)
        {
            if (this.X == other.X && this.Y == other.Y)
                return true;
            return false;
        }
    }
}
