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
        public Image Img;

        public Wall()
        {
            Img = _wallImg.img;
        }
    }
}
