using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    public class SnaryadImg
    {
        //public Image getImage(DirectionEnum direction)
        //{
        //    if (direction == DirectionEnum.Up)
        //        return Resources.ProjectileU;
        //    else if (direction == DirectionEnum.Down)
        //        return Resources.ProjectileD;
        //    else if (direction == DirectionEnum.Left)
        //        return Resources.ProjectileL;
        //    else
        //        return Resources.ProjectileR;
        //}
        public Image getImage(DirectionEnum direction)
        {
            return Resources.Snaryad;
        }
    }
}
