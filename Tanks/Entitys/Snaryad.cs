using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Snaryad: IPicture, IRun
    {
        protected SnaryadImg _snaryadImg;
        public Image Img
        {
            get { return _snaryadImg.getImage(Dir); }
            private set { }
        }

        public int X;
        public int Y;
        public DirectionEnum Dir;
        public int V;




        public Snaryad(int x, int y, DirectionEnum dir, int v = 3)
        {
            _snaryadImg = new SnaryadImg();

            X = x + (20 - Img.Width) / 2;
            Y = y + (20 - Img.Height) / 2;
            Dir = dir;
            V = v;
        }

        public void Run()
        {
            if (Dir == DirectionEnum.Up) Y-=V;
            else if (Dir == DirectionEnum.Right) X+=V;
            else if (Dir == DirectionEnum.Down) Y+=V;
            else X-=V;

        }
    }
}
