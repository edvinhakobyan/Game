using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Wall : IPicture
    {
        WallImg _wallImg = new WallImg();

        public Image Img { get; }

        public Wall()
        {
            Img = _wallImg.img;
        }


    }
}
