using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Hanter : Tank
    {
        Packman Packman;

        public Hanter(int x, int y, DirectionEnum dir, Packman packman) : base(x, y, dir)
        {
            Packman = packman;
        }

        public override void Turn()
        {
            int zar = rand.Next(1000);

            if (X <= Packman.X && Y <= Packman.Y)
                if (zar < 500)
                {
                    if(Dir != DirectionEnum.Up)
                    Dir = DirectionEnum.Down;
                }
                else
                {
                    if (Dir != DirectionEnum.Left)
                        Dir = DirectionEnum.Right;
                }
            else if(X >= Packman.X && Y <= Packman.Y)
                if (zar < 500)
                {
                    if (Dir != DirectionEnum.Up)
                        Dir = DirectionEnum.Down;
                }
                else
                {
                    if (Dir != DirectionEnum.Right)
                        Dir = DirectionEnum.Left;
                }
            else if(X >= Packman.X && Y >= Packman.Y)
            {
                if (zar < 500)
                {
                    if (Dir != DirectionEnum.Down)
                        Dir = DirectionEnum.Up;
                }
                else
                {
                    if (Dir != DirectionEnum.Right)
                        Dir = DirectionEnum.Left;
                }
            }
            else
            {
                if (zar < 500)
                {
                    Dir = DirectionEnum.Up;
                }
                else
                {
                    Dir = DirectionEnum.Right;
                }
            }

            imgArray = _tankImg.getImage(Dir);
        }

    }

}
