﻿using System;
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
        public List<Apple> Apples;
        public Wall Wall;
        public GameStatus GameStatus;

        public Model(int fieldSize, int amountTanks, int amountsApples, int gameSpeed)
        {
            FieldSize = fieldSize;
            AmountTanks = amountTanks;
            AmountsApples = amountsApples;
            GameSpeed = gameSpeed;
            rand = new Random();

            Tanks = new List<Tank>();
            CrateTanksList(Tanks);

            Apples = new List<Apple>();
            CreateAppleList(Apples);


            Wall = new Wall();
            GameStatus = GameStatus.Stop;
        }

        private void CreateAppleList(List<Apple> apples)
        {
            while (Apples.Count < AmountsApples)
            {
                Apple apple = new Apple(rand.Next(24) * 20, rand.Next(24) * 20);
                if (!(apples.Contains(apple) && (apple.X + apple.Y) % 40 == 0 ))
                    apples.Add(apple);
            }
        }

        private void CrateTanksList(List<Tank> tanks)
        {
            while (Tanks.Count < AmountTanks)
            {
                Tank tank = new Tank(rand.Next(13) * 40, rand.Next(13) * 40, (TankDirection)rand.Next(4));
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

                CheckCollision();
                
                Thread.Sleep(GameSpeed);
            }
        }

        private void CheckCollision()
        {
            for (int i = 0; i < AmountTanks - 1; i++)
            {
                for (int j = i + 1; j < AmountTanks; j++)
                {
                    if (((Tanks[i].Dir == TankDirection.Right && Tanks[j].Dir == TankDirection.Left) ||
                        (Tanks[i].Dir == TankDirection.Left && Tanks[j].Dir == TankDirection.Right)) &&
                        (Math.Abs(Tanks[i].X - Tanks[j].X) <= 20 && Tanks[i].Y == Tanks[j].Y) ||
                        ((Tanks[i].Dir == TankDirection.Up && Tanks[j].Dir == TankDirection.Down) ||
                        (Tanks[i].Dir == TankDirection.Down && Tanks[j].Dir == TankDirection.Up)) &&
                        (Math.Abs(Tanks[i].Y - Tanks[j].Y) <= 20 && Tanks[i].X == Tanks[j].X))
                    {
                        Tanks[i].TurnArround();
                        Tanks[j].TurnArround();
                    }

                  //((Math.Abs(Tanks[i].Y - Tanks[j].Y) <= 20 && Math.Abs(Tanks[i].X - Tanks[j].X) <= 20)
                }
            }
        }
    }
}
