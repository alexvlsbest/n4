using System;

namespace Kernels
{
    enum Players
    {
        COMPUTER,
        USER,
        NOBODY
    }

    class Kernel
    {
        byte ItemsCount;
        byte ComputerChoice, UserChoice;
        Players Winner;

        public Kernel(byte itemsCount)
        {
            this.ItemsCount = itemsCount;
        }

        public byte GetComputerChoice() => ComputerChoice;

        public byte GetUserChoice() => UserChoice;

        public Players GetWinner() => Winner;

        public void ComputerTurn()
        {
            var rand = new Random();
            ComputerChoice = (byte)rand.Next(ItemsCount);
        }

        public void Play(byte userChoice)
        {
            this.UserChoice = userChoice;
            int i = this.UserChoice,
                j = ComputerChoice;
            if (j == i)
                Winner = Players.NOBODY;
            else
                 if ((Math.Max(i, j) == i) && (Math.Abs(i - j) < ItemsCount / 2.0)
                   || (Math.Max(i, j) == j) && (Math.Abs(i - j) > ItemsCount / 2.0))
                Winner = Players.USER;
            else
                Winner = Players.COMPUTER;
        }
    }

}
