using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    internal class PackmanImg
    {
        public Image[] getImage(DirectionEnum direction)
        {
            if (direction == DirectionEnum.Up)
                return Up;
            else if (direction == DirectionEnum.Down)
                return Down;
            else if (direction == DirectionEnum.Left)
                return Left;
            else
                return Right;
        }



        readonly public Image[] Up = { Resources.PackmanImgU_1,
                                       Resources.PackmanImgU_2 ,
                                       Resources.PackmanImgU_3,
                                       Resources.PackmanImgU_4,
                                       Resources.PackmanImgU_5 };


        readonly public Image[] Down = { Resources.PackmanImgD_1,
                                         Resources.PackmanImgD_2,
                                         Resources.PackmanImgD_3,
                                         Resources.PackmanImgD_4,
                                         Resources.PackmanImgD_5 };

        readonly public Image[] Left = { Resources.PackmanImgL_1,
                                         Resources.PackmanImgL_2 ,
                                         Resources.PackmanImgL_3,
                                         Resources.PackmanImgL_4,
                                         Resources.PackmanImgL_5 };

        readonly public Image[] Right = { Resources.PackmanImgR_1,
                                          Resources.PackmanImgR_2 ,
                                          Resources.PackmanImgR_3,
                                          Resources.PackmanImgR_4,
                                          Resources.PackmanImgR_5 };

    }
}