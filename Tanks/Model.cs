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
        private readonly int fieldSize;
        private readonly int amountTanks;
        private readonly int amountsApples;
        public readonly int gameSpeed;

        public Tank Tank;
        public GameStatus GameStatus;

        public Model(int fieldSize, int amountTanks, int amountsApples, int gameSpeed)
        {
            this.fieldSize = fieldSize;
            this.amountTanks = amountTanks;
            this.amountsApples = amountsApples;
            this.gameSpeed = gameSpeed;

            Tank = new Tank();
            GameStatus = GameStatus.Stop;
        }

        public void Play()
        {
            while(true)
            {
                Tank.Run();
                Thread.Sleep(gameSpeed);
            }
        }

    }
}
