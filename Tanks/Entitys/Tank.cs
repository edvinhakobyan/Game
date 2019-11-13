﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class Tank : IRun, ITurn, ITransparent, ICollision, IEquatable<Tank>
    {
        Random rand;
        TankImg _tankImg = new TankImg();
        Image[] imgArray;
        public Image Img { get; private set; }


        public Tank(int x, int y, TankDirection dir)
        {
            imgArray = _tankImg.getImage(dir);
            PutCurrentImage();
            rand = new Random();
            X = x;
            Y = y;
            Dir = dir;
        }

        public TankDirection Dir { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public void Run()
        {
            PutCurrentImage();

            if (Dir == TankDirection.Up) Y--;
            else if (Dir == TankDirection.Down) Y++;
            else if (Dir == TankDirection.Right) X++;
            else X--;

            if (X % 40 == 0 && Y % 40 == 0)
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
            int zar = rand.Next(10000);
            if (Dir == TankDirection.Up || Dir == TankDirection.Down)
            {
                if (zar > 7500)
                    Dir = TankDirection.Left;
                else if (zar < 2500)
                    Dir = TankDirection.Right;
            }
            else
            {
                if (zar > 7500)
                    Dir = TankDirection.Up;
                else if (zar < 2500)
                    Dir = TankDirection.Down;
            }
            imgArray = _tankImg.getImage(Dir);
        }

        public void Transparent()
        {
            if (X  > 24 * 20)
                X = 1;
            else if(X < 0)
                X = 24 * 20 - 1;
            else if(Y > 24*20)
                Y = 1;
            else if(Y < 0)
                Y = 24 * 20 - 1;
        }

        public void TurnArround()
        {
            if (Dir == TankDirection.Up)
                Dir = TankDirection.Down;
            else if (Dir == TankDirection.Down)
                Dir = TankDirection.Up;
            else if (Dir == TankDirection.Left)
                Dir = TankDirection.Right;
            else
                Dir = TankDirection.Left;

            imgArray = _tankImg.getImage(Dir);
        }

        public bool Equals(Tank other)
        {
            if (this.X == other.X && this.Y == other.Y)
                return true;
            return false;
        }
    }
}