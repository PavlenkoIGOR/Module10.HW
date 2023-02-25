using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MyNameSpace;


namespace MyNameSpace
{
    public class Calculate : ICalcSum, ILogger
    {
        public void Error(string mess)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{mess}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        double ICalcSum.Sum(double a, double b) //явная реализация
        {
            Console.WriteLine($"Результат сложения {a} и {b}: {a + b}");
            return a + b;
        }
    }

    internal class HW1
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();
            double a = default;
            double b = default;

            do
            {
                Console.Clear();
                calculate.Event("КАЛЬКУЛЯТОР ЗАПУЩЕН");

            link1:
                try
                {
                    Console.WriteLine("Введите первое слагаемое: ");
                    a = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    calculate.Error(ex.Message);
                    goto link1;
                }

            link2:
                try
                {
                    Console.WriteLine("Введите второе слагаемое: ");
                    b = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto link2;
                }

            ((ICalcSum)calculate).Sum(a, b);
                Console.WriteLine("Нажмите любую клавишу для продолжения или клавишу Esc для выхода");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
