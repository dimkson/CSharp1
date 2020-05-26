using System;

namespace Lesson6
{
    public delegate double Fun(double a, double x);
    public class Task01
    {
        public static void Table(Fun F, double a, double x, double y)
        {
            Console.WriteLine("----- A ----- X ----- Y -----");
            while (x <= y)
            {
                Console.WriteLine("|{0,8:0.000}|{1,8:0.000}|{2,8:0.000}|", a, x, F(a, x));
                x++;
            }
            Console.WriteLine("-----------------------------");
        }
        public static double MyMethod1(double a, double x)
        {
            return a * x * x;
        }
        public static double MyMethod2(double a, double x)
        {
            return a * Math.Sin(x);
        }

    }
}
