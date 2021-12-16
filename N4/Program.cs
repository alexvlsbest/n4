using System;
using static System.Console;
using System.Collections.Generic;

using Menus;
using Kernels;
using Crypters;
using WinTables;


namespace N4
{
    class Program
    {
        static public bool ArgsIsCorrect(string[] args, int ItemsLimit)
        {
            if ((args.Length < 3) || (args.Length > ItemsLimit))
            {
                WriteLine("Odd 3..{0}(!) unique arguments needed, e.g. HelloApp a b c d e", ItemsLimit);
                return false;
            }
            if (args.Length % 2 == 0)
            {
                WriteLine("Odd(!) 3..{0} unique arguments needed, e.g. HelloApp a b c d e", ItemsLimit);
                return false;
            }
            HashSet<string> uniqueArgs = new HashSet<string>(args);
            if (uniqueArgs.Count < args.Length)
            {
                WriteLine("Odd 3+..{0} unique(!) arguments needed, e.g. HelloApp a b c d e", ItemsLimit);
                return false;
            }
            return true;
        }


        static void Main(string[] args)
        {
            const int KEY_SIZE = 32;
            const int ITEMS_LIMIT = 15;
            if (!ArgsIsCorrect(args, ITEMS_LIMIT))
                return;
            Menu menu = new Menu(args);
            Kernel kernel = new Kernel((byte)args.Length);
            Crypter crypter = new Crypter(KEY_SIZE);
            WinTable table = new WinTable(args);
            kernel.ComputerTurn();
            crypter.Encode(kernel.GetComputerChoice());
            WriteLine("\nCOMPUTER choice HMAC: {0:x}", crypter.GetEncodedValueAsNumber());
            string a;
            do
            {
                a = menu.UserTurn();
                if (a == "?")
                    table.Show();
            }
            while (a == "?");
            if (a == "0")
                return;
            byte r = Convert.ToByte(a);
            kernel.Play((byte)(r - 1));
            WriteLine("Winner : " + kernel.GetWinner().ToString());
            WriteLine("USER choice: " + (kernel.GetUserChoice() + 1) + "->" + args[kernel.GetUserChoice()]);
            WriteLine("COMPUTER choice: "
                + (kernel.GetComputerChoice() + 1) + "->" + args[kernel.GetComputerChoice()]);
            WriteLine("HMAC Key:  {0:x}", crypter.GetKeyAsNumber());
        }
    }
}
