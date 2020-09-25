using System;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;

namespace Проект2._Ход_конем
{
    class Program
    {
        static bool IsAllowedLetters(char[] stepsym)
        {
            char[] alf = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            bool symbol0 = false, symbol1 = false, symbol3 = false, symbol4 = false;
            for (int i = 0; i < alf.Length; i++)
            {
                if (alf[i] == stepsym[0])
                { symbol0 = true; }
                if (alf[i] == stepsym[3])
                { symbol3 = true; }
            }
            symbol1 = int.TryParse(stepsym[1].ToString(), out int digit1);
            symbol4 = int.TryParse(stepsym[4].ToString(), out int digit2);
            return (symbol0 && symbol1 && symbol3 && symbol4);
        }
        static bool IsStepCorrect(char[] stepsym)
        {
            char[] alf = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            int ColumnStart = 0;
            int ColumnEnd = 0;
            for (int i = 0; i < alf.Length; i++)
            {
                if (alf[i] == stepsym[0])
                { ColumnStart = i; }
                if (alf[i] == stepsym[3])
                { ColumnEnd = i; }
            }
            int LineStart = int.Parse(stepsym[1].ToString());
            int LineEnd = int.Parse(stepsym[4].ToString());
            return ((Math.Abs(ColumnEnd - ColumnStart) == 2 && Math.Abs(LineEnd - LineStart) == 1) ||
                (Math.Abs(ColumnEnd - ColumnStart) == 2 && Math.Abs(LineEnd - LineStart) == 1));

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите ход коня, например (C1-D3)");
                string step = Console.ReadLine();
                char[] stepsym = step.ToArray();
                bool allow = IsAllowedLetters(stepsym);
                if (!allow)
                {
                    Console.WriteLine("Вы допустили ошибку, введите данные по новой");
                    Console.ReadLine();
                    continue;
                }
                if (!IsStepCorrect(stepsym))
                {
                    Console.WriteLine("Ход конем не верен. попробуйте еще раз");
                    Console.ReadLine();
                    continue;
                }
                else
                {
                    Console.WriteLine("Ход верен, играем дальше");
                    Console.ReadLine();
                    continue;
                }

            }
        }
    }    
}
