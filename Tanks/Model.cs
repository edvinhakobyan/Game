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

        public Wall Wall;
        public Packman packman;
        public List<Tank> Tanks;
        public List<Apple> Apples;

        public GameStatus GameStatus;

        public Model(int fieldSize, int amountTanks, int amountsApples, int gameSpeed)
        {
            FieldSize = fieldSize;
            AmountTanks = amountTanks;
            AmountsApples = amountsApples;
            GameSpeed = gameSpeed;
            rand = new Random();

            Wall = new Wall();

            Tanks = new List<Tank>();
            CrateTanksList(Tanks);

            Apples = new List<Apple>();
            CreateAppleList(Apples);

            packman = new Packman(7 * 40, 23 * 20, DirectionEnum.Up);

            GameStatus = GameStatus.Stop;
        }

        private void CreateAppleList(List<Apple> apples)
        {
            while (Apples.Count < AmountsApples)
            {
                Apple apple = new Apple(rand.Next(24) * 20, rand.Next(24) * 20);
                if (!(apples.Contains(apple) || (apple.X + apple.Y) % 40 == 0) || (apple.X % 40 == 0 && apple.Y % 40 == 0) && !IsAppleOnTank(apple))
                    apples.Add(apple);
            }
        }

        public bool IsAppleOnTank(Apple apple)
        {
            foreach (var t in Tanks)
            {
                if (t.X == apple.X && t.Y == apple.Y)
                    return true;
            }
            return false;
        }


        private void CrateTanksList(List<Tank> tanks)
        {
            while (Tanks.Count < AmountTanks)
            {
                Tank tank = new Tank(rand.Next(13) * 40, rand.Next(13) * 40, (DirectionEnum)rand.Next(4));
                if (!Tanks.Contains(tank))
                    Tanks.Add(tank);
            }
        }

        public void Play()
        {
            while(true)
            {

                foreach (var Tank in Tanks)
                    Tank.Run();

                packman.Run();

                CheckCollision();
                
                Thread.Sleep(GameSpeed);
            }
        }
        int tol = 20;
        private void CheckCollision()
        {
            for (int i = 0; i < AmountTanks - 1; i++)
            {
                for (int j = i + 1; j < AmountTanks; j++)
                {
                    //if ((((Tanks[i].Dir == TankDirection.Right && Tanks[j].Dir == TankDirection.Left) ||
                    //    (Tanks[i].Dir == TankDirection.Left && Tanks[j].Dir == TankDirection.Right)) && 
                    //    (Math.Abs(Tanks[i].X - Tanks[j].X) <= tol && Tanks[i].Y == Tanks[j].Y)))   
                    //{
                    //    Tanks[i].TurnArround();
                    //    Tanks[j].TurnArround();
                    //    Tanks[i].Run(); Tanks[j].Run();
                    //}
                    //else if (((Tanks[i].Dir == TankDirection.Up && Tanks[j].Dir == TankDirection.Down) ||
                    //    (Tanks[i].Dir == TankDirection.Down && Tanks[j].Dir == TankDirection.Up)) &&
                    //    (Math.Abs(Tanks[i].Y - Tanks[j].Y) <= tol && Tanks[i].X == Tanks[j].X))
                    //{
                    //    Tanks[i].TurnArround();
                    //    Tanks[j].TurnArround();
                    //    Tanks[i].Run(); Tanks[j].Run();
                    //}
                    //else if (((Tanks[i].Dir == TankDirection.Right && Tanks[j].Dir == TankDirection.Up) ||
                    //     (Tanks[i].Dir == TankDirection.Up && Tanks[j].Dir == TankDirection.Right)) &&
                    //     (Math.Abs(Tanks[i].Y - Tanks[j].Y) <= tol && Math.Abs(Tanks[i].X - Tanks[j].X) <= tol))
                    //{
                    //    Tanks[i].TurnArround();
                    //    Tanks[j].TurnArround();
                    //    Tanks[i].Run(); Tanks[j].Run();
                    //}
                    //else if (((Tanks[i].Dir == TankDirection.Right && Tanks[j].Dir == TankDirection.Down) ||
                    //     (Tanks[i].Dir == TankDirection.Down && Tanks[j].Dir == TankDirection.Right)) &&
                    //     (Math.Abs(Tanks[i].Y - Tanks[j].Y) <= tol && Math.Abs(Tanks[i].X - Tanks[j].X) <= tol))
                    //{
                    //    Tanks[i].TurnArround();
                    //    Tanks[j].TurnArround();
                    //    Tanks[i].Run(); Tanks[j].Run();
                    //}
                    //else if (((Tanks[i].Dir == TankDirection.Left && Tanks[j].Dir == TankDirection.Down) ||
                    //     (Tanks[i].Dir == TankDirection.Down && Tanks[j].Dir == TankDirection.Left)) &&
                    //     (Math.Abs(Tanks[i].Y - Tanks[j].Y) <= tol && Math.Abs(Tanks[i].X - Tanks[j].X) <= tol))
                    //{
                    //    Tanks[i].TurnArround();
                    //    Tanks[j].TurnArround();
                    //    Tanks[i].Run(); Tanks[j].Run();
                    //}
                    //else if (((Tanks[i].Dir == TankDirection.Left && Tanks[j].Dir == TankDirection.Up) ||
                    //     (Tanks[i].Dir == TankDirection.Up && Tanks[j].Dir == TankDirection.Left)) &&
                    //     (Math.Abs(Tanks[i].Y - Tanks[j].Y) <= tol && Math.Abs(Tanks[i].X - Tanks[j].X) <= tol))
                    //{
                    //    Tanks[i].TurnArround();
                    //    Tanks[j].TurnArround();
                    //    Tanks[i].Run(); Tanks[j].Run();
                    //}

                    if((Math.Abs(Tanks[i].X - Tanks[j].X) <= 20 && Tanks[i].Y == Tanks[j].Y) ||
                       (Math.Abs(Tanks[i].Y - Tanks[j].Y) <= 20 && Tanks[i].X == Tanks[j].X) ||
                       (Math.Abs(Tanks[i].X - Tanks[j].X) <= 20 && Math.Abs(Tanks[i].Y - Tanks[j].Y) <= 20))
                    {
                        Tanks[i].TurnArround();
                        Tanks[j].TurnArround();
                        Tanks[i].Run(); Tanks[j].Run();
                    }

                }
            }
        }
    }
}
