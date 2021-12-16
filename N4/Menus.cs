using System;
using static System.Console;
using System.Collections.Generic;

namespace Menus
{
    class Menu
    {
        List<string> Items;

        public Menu(string[] args)
        {
            Items = new List<string>(args);
        }

        public void Show()
        {
            WriteLine();
            Items.ForEach(n => WriteLine((Items.IndexOf(n) + 1) + ": " + n));
            WriteLine("?: Help");
            WriteLine("0: Exit");
        }

        public string UserTurn()
        {
            string a;
            byte r;
            while (true)
            {
                Show();
                Write("\nYour turn: ");
                a = ReadLine();

                if ((a == "?") || (a == "0"))
                    return a;
                try
                {
                    r = Convert.ToByte(a);
                }
                catch
                {
                    WriteLine("Invalid input");
                    continue;
                }
                if ((r > 0) && (r <= Items.Count))
                    return a;
                else
                {
                    WriteLine("Invalid item number");
                    continue;
                }
            }
        }
    }

}
