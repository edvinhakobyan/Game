using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tanks
{
    public class Model 
    {
        public int FieldSize { get; }
        public int AmountTanks { get; }
        public int AmountsApples { get; }
        public int GameSpeed { get; }
        private Random rand;


        public List<Tank> Tanks;
        public Wall Wall;
        public GameStatusEnum GameStatus;

        public Model(int fieldSize, int amountTanks, int amountsApples, int gameSpeed)
        {
            FieldSize = fieldSize;
            AmountTanks = amountTanks;
            AmountsApples = amountsApples;
            GameSpeed = gameSpeed;
            rand = new Random();

            Tanks = new List<Tank>();

            while(Tanks.Count < amountTanks)
            {
                Tank tank = new Tank(rand.Next(13) * 40, rand.Next(13) * 40, (DirectionEnum)rand.Next(5));
                if (!Tanks.Contains(tank))
                    Tanks.Add(tank);
            }
            Wall = new Wall();
            GameStatus = GameStatusEnum.Stop;
        }

        public void Play()
        {
            while(true)
            {
                foreach (var Tank in Tanks)
                    Tank.Run();

                CheckCollision();
                
                Thread.Sleep(GameSpeed);
            }
        }

        private void CheckCollision()
        {
            for (int i = 0; i < AmountTanks; i++)
            {
                for (int j = i + 1; j < AmountTanks; j++)
                {
                    if (Tanks[i].Dir == DirectionEnum.Right && Tanks[j].Dir == DirectionEnum.Left ||
                        Tanks[j].Dir == DirectionEnum.Right && Tanks[i].Dir == DirectionEnum.Left)
                    {
                        if (Math.Abs(Tanks[i].X - Tanks[j].X) == 20)
                        {
                            Tanks[i].TurnArround();
                            Tanks[j].TurnArround();
                        }
                    }
                    if (Tanks[i].Dir == DirectionEnum.Down && Tanks[j].Dir == DirectionEnum.Up ||
                        Tanks[j].Dir == DirectionEnum.Down && Tanks[i].Dir == DirectionEnum.Up)
                    {
                        if (Math.Abs(Tanks[i].Y - Tanks[j].Y) == 20)
                        {
                            Tanks[i].TurnArround();
                            Tanks[j].TurnArround();
                        }
                    }
                }
            }
        }
    }
}
