﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public Hanter Hanter;


        public GameStatus GameStatus;
        public int AppleCount;

        public Model(int fieldSize, int amountTanks, int amountsApples, int gameSpeed)
        {
            FieldSize = fieldSize;
            AmountTanks = amountTanks;
            AmountsApples = amountsApples;
            GameSpeed = gameSpeed;
            rand = new Random();


            Wall = new Wall();

            packman = new Packman(7 * 40, 23 * 20, DirectionEnum.Up);

            Tanks = new List<Tank>();
            Hanter = new Hanter(rand.Next(13) * 40, rand.Next(13) * 40, (DirectionEnum)rand.Next(4), packman);
            Tanks.Add(Hanter);
            CrateTanksList(Tanks);

            Apples = new List<Apple>();
            CreateAppleList(Apples);

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
                {
                    Tank.Run();
                    if (Tank.snaryad == null)
                        Tank.CreateSnaryad(2);

                        Tank.snaryad.Run();
                }

                packman.Run();

                CheckCollision();

               

                PackmanEatApple();

                if (PackmanTanksCollision() || CheckSnaryadCollision())
                {
                    MessageBox.Show("--Game Over--");
                    break;
                }

                Thread.Sleep(20);
            }
        }

        private bool CheckSnaryadCollision()
        {
            foreach (var t in Tanks)
            {
                if (t.snaryad == null) return true;
                if(Math.Abs(t.snaryad.X - packman.X) < 10 && Math.Abs(t.snaryad.Y - packman.Y) < 10)
                {
                    return true;
                }
            }
            return false;
        }

        private bool PackmanTanksCollision()
        {
            for (int i = 0; i < Tanks.Count; i++)
            {
                if((Math.Abs(packman.X - Tanks[i].X) <= 20) && (Math.Abs(packman.Y - Tanks[i].Y) <= 20))
                {
                    return true;
                }
            }
            return false;
        }

        private void PackmanEatApple()
        {
            for (int i = 0; i < Apples.Count; i++)
            {
                if((Math.Abs(packman.X - Apples[i].X) < 20 && packman.Y == Apples[i].Y) ||
                   (Math.Abs(packman.Y - Apples[i].Y) < 20 && packman.X == Apples[i].X))
                {
                    while(true)
                    {
                        Apple apple = new Apple(rand.Next(24) * 20, rand.Next(24) * 20);

                        if (!(Apples.Contains(apple) || (apple.X + apple.Y) % 40 == 0) || (apple.X % 40 == 0 && apple.Y % 40 == 0) && !IsAppleOnTank(apple))
                        {
                            Apples[i] = apple; //TODO
                            break;
                        }
                    }
                    AppleCount++;
                    break;
                }
            }
        }

        private void CheckCollision()
        {
            for (int i = 0; i < AmountTanks - 1; i++)
            {
                for (int j = i + 1; j < AmountTanks; j++)
                {
                    if((Math.Abs(Tanks[i].X - Tanks[j].X) <= 20 && Tanks[i].Y == Tanks[j].Y) ||
                       (Math.Abs(Tanks[i].Y - Tanks[j].Y) <= 20 && Tanks[i].X == Tanks[j].X) ||
                       (Math.Abs(Tanks[i].X - Tanks[j].X) <= 20 && Math.Abs(Tanks[i].Y - Tanks[j].Y) <= 20))
                    {
                        Tanks[i].TurnArround();
                        Tanks[j].TurnArround();
                        Tanks[i].Run();
                        Tanks[j].Run();
                    }
                }
            }
        }
    }
}
