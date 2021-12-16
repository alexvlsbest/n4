using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTables
{

    class WinTable
    {
        byte ItemsCount;
        int MaxItemLength = 0;

        List<string> Items;

        public WinTable(string[] args)
        {
            Items = new List<string>(args);
            ItemsCount = (byte)args.Length;
            Items.ForEach(x => MaxItemLength = x.Length > MaxItemLength ? x.Length : MaxItemLength);
        }

        public void Show()
        {
            WriteLine("\nVictory Table:\n");
            SetCursorPosition(GetCursorPosition().Left + MaxItemLength + 1, GetCursorPosition().Top);
            System.ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Items.ForEach(n => Write(n.PadLeft(MaxItemLength) + " ")); ;
            WriteLine();
            Items.ForEach(y =>
            {
                int i = Items.IndexOf(y);
                Console.ForegroundColor = ConsoleColor.Red;
                Write(Items[i].PadRight(MaxItemLength) + " ");
                Console.ForegroundColor = defaultColor;
                Items.ForEach(x =>
                {
                    int j = Items.IndexOf(x);
                    if (j == i)
                        Write("-".PadLeft(MaxItemLength) + " ");
                    else
                        if (Math.Abs(i - j) < ItemsCount / 2.0)
                        Write(Items[Math.Max(i, j)].PadLeft(MaxItemLength) + " ");
                    else
                        Write(Items[Math.Min(i, j)].PadLeft(MaxItemLength) + " ");
                });
                WriteLine();
            });
        }
    }


}
