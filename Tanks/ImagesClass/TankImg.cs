using System.Drawing;
using Tanks.Properties;


namespace Tanks
{
    public class TankImg
    {
        public  Image[] getImage(DirectionEnum direction)
        {
            if (direction == DirectionEnum.Up)
                return Up;
            else if(direction == DirectionEnum.Down)
                return Down;
            else if (direction == DirectionEnum.Left)
                return Left;
            else 
                return Right;
        }



        readonly public Image[] Up = { Resources.TankImgU_1,
                                      Resources.TankImgU_2 ,
                                      Resources.TankImgU_3,
                                      Resources.TankImgU_4,
                                      Resources.TankImgU_5 };


        readonly public Image[] Down = { Resources.TankImgD_1,
                                       Resources.TankImgD_2 ,
                                       Resources.TankImgD_3,
                                       Resources.TankImgD_4,
                                       Resources.TankImgD_5 };

        readonly public Image[] Left = { Resources.TankImgL_1,
                                       Resources.TankImgL_2 ,
                                       Resources.TankImgL_3,
                                       Resources.TankImgL_4,
                                       Resources.TankImgL_5 };

        readonly public Image[] Right = { Resources.TankImgR_1,
                                       Resources.TankImgR_2 ,
                                       Resources.TankImgR_3,
                                       Resources.TankImgR_4,
                                       Resources.TankImgR_5 };

    }
}
