using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Packman : IPicture, IRun, ITurn, ITransparent
    {

        Random rand;
        PackmanImg _packmanImg;
        Image[] imgArray;
        public Image Img { get; private set; }


        public Packman(int x, int y, DirectionEnum dir)
        {
            rand = new Random();
            _packmanImg = new PackmanImg();
            imgArray = _packmanImg.getImage(dir);
            PutCurrentImage();
            X = x;
            Y = y;
            Dir = dir;
        }


        public DirectionEnum Dir { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public void Run()
        {
            PutCurrentImage();

            if (Dir == DirectionEnum.Up) Y--;
            else if (Dir == DirectionEnum.Down) Y++;
            else if (Dir == DirectionEnum.Right) X++;
            else X--;
            Turn();
            Transparent();
        }

        int ImgIndex = 1;
        private void PutCurrentImage()
        {
            Img = imgArray[ImgIndex++];
            if (ImgIndex == imgArray.Length) ImgIndex = 0;
        }

        public void Turn()
        {
            imgArray = _packmanImg.getImage(Dir);
        }

        public void Transparent()
        {
            if (X > 24 * 20)
                X = 1;
            else if (X < 0)
                X = 24 * 20 - 1;
            else if (Y > 24 * 20)
                Y = 1;
            else if (Y < 0)
                Y = 24 * 20 - 1;
        }

        public void TurnArround()
        {

        }
    }
}
