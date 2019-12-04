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
        PackmanImg _packmanImg;
        Image[] imgArray;
        public Image Img { get; private set; }
        private bool IsShuth;
        public Snaryad snaryad;
        private int snaryadV;
        public int SnaryadV
        {
            get
            {
                if (snaryadV < 4)
                    return 3;
                else if (snaryadV >= 4 && snaryadV < 8)
                    return 5;
                else if (snaryadV >= 8 && snaryadV < 12)
                    return 7;
                else if (snaryadV >= 12 && snaryadV < 16)
                    return 9;
                else if (snaryadV >= 16 && snaryadV < 20)
                    return 11;
                else
                    return 15;
            }
            set { snaryadV = value; }
        }


        public Packman(int x, int y, DirectionEnum dir)
        {
            _packmanImg = new PackmanImg();
            imgArray = _packmanImg.getImage(dir);
            PutCurrentImage();
            X = x;
            Y = y;
            currentDir = dir;
            nextDir = currentDir;
        }




        public DirectionEnum currentDir { get; set; }
        public DirectionEnum nextDir { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public void Run()
        {
            PutCurrentImage();


            if (currentDir == DirectionEnum.Up) Y--; 
            else if (currentDir == DirectionEnum.Down)  Y++; 
            else if (currentDir == DirectionEnum.Right) X++; 
            else  X--; 

            Turn();
            Transparent();
            imgArray = _packmanImg.getImage(currentDir);
        }

        public void SnaryadRun()
        {

            if (IsShuth)
            {
                if (snaryad == null)
                    snaryad = new Snaryad(X, Y, currentDir, SnaryadV);


                snaryad.Run();
                if (snaryad.X < 0 || snaryad.X > 500 || snaryad.Y < 0 || snaryad.Y > 500)
                {
                    IsShuth = false;
                    snaryad = null;
                }
            }
        }

        public void Shuth()
        {
            if (!IsShuth)
            {
                IsShuth = !IsShuth;
            }
        }

        int ImgIndex = 1;
        private void PutCurrentImage()
        {
            Img = imgArray[ImgIndex++];
            if (ImgIndex == imgArray.Length) ImgIndex = 0;
        }

        public void Turn()
        {
            if (X % 40 == 0 && Y % 40 == 0)
            {
                if ((currentDir == DirectionEnum.Up) ||
                   (currentDir == DirectionEnum.Down) ||
                   (currentDir == DirectionEnum.Right) ||
                   (currentDir == DirectionEnum.Left))
                {
                    currentDir = nextDir;
                }
            }
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
