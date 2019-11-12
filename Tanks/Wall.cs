using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Wall
    {
        WallImg _wallImg = new WallImg();
        public Image _img;

        public int X { get; set; }
        public int Y { get; set; }

        public Wall()
        {
            _img = _wallImg.img;
        }
    }
}
