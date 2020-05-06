using System;
using MenuLib;
using FC = MenuLib.FastConsole;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.delMenu[] delMenu = new Menu.delMenu[] { Task01, Task02, Task03 };
            Menu menu = new Menu(delMenu);
            menu.ChooseMenu();
        }
        #region Задание1
        static void Task01()
        {
            //Сложение, вычитание и умножение комплексных чисел на примере структуры Complex
            Complex complex1;
            complex1.im = 1;
            complex1.re = 1;
            Complex complex2;
            complex2.im = 2;
            complex2.re = 2;
            Complex result = complex1.Plus(complex2);
            Console.WriteLine("Структура Complex");
            Console.WriteLine("Сложение: " + result.ToString());
            result = complex1.Multi(complex2);
            Console.WriteLine("Умножение: " + result.ToString());
            result = complex2.Minus(complex1);
            Console.WriteLine("Вычитание: " + result.ToString());
            //Сложение, вычитание и умножение комплексных чисел на примере класса ComplexClass
            ComplexClass complexClass1 = new ComplexClass(1, 1);
            ComplexClass complexClass2 = new ComplexClass(2, 2);
            complexClass1.Im = 3;
            complexClass1.Re = 3;
            ComplexClass resultClass;
            resultClass = complexClass1.Plus(complexClass2);
            Console.WriteLine("Класс ComplexClass");
            Console.WriteLine("Сложение: " + resultClass.ToString());
            resultClass = complexClass1.Multi(complexClass2);
            Console.WriteLine("Умножение: " + resultClass.ToString());
            complexClass1.Im = 1;
            complexClass1.Re = 1;
            resultClass = complexClass2.Minus(complexClass1);
            Console.WriteLine("Вычитание: " + resultClass.ToString());
            FC.Pause();
        }
        struct Complex
        {
            public double im;
            public double re;

            public Complex Plus(Complex x)
            {
                Complex y;
                y.im = im + x.im;
                y.re = re + x.re;
                return y;
            }
            public Complex Minus(Complex x)
            {
                Complex y;
                y.im = im - x.im;
                y.re = re - x.re;
                return y;
            }
            public Complex Multi(Complex x)
            {
                Complex y;
                y.im = im * x.im + re * x.im;
                y.re = re * x.im + im * x.re;
                return y;
            }
            public override string ToString()
            {
                return re + "+" + im + "i";
            }
        }
        class ComplexClass
        {
            private double im;
            private double re;

            public ComplexClass()
            {
                im = 0;
                re = 0;
            }
            public ComplexClass(double im, double re)
            {
                this.im = im;
                this.re = re;
            }

            public double Im
            {
                get { return im; }
                set { if (value > 0) im = value; }
            }
            public double Re
            {
                get { return re; }
                set { if (value > 0) re = value; }
            }

            public ComplexClass Plus(ComplexClass x)
            {
                ComplexClass y = new ComplexClass();
                y.im = im + x.im;
                y.re = re + x.re;
                return y;
            }
            public ComplexClass Minus(ComplexClass x)
            {
                ComplexClass y = new ComplexClass();
                y.im = im - x.im;
                y.re = re - x.re;
                return y;
            }
            public ComplexClass Multi(ComplexClass x)
            {
                ComplexClass y = new ComplexClass();
                y.im = im * x.im + re * x.im;
                y.re = re * x.im + im * x.re;
                return y;
            }
            public override string ToString()
            {
                return re + "+" + im + "i";
            }
        }
        #endregion
        #region Задание2
        static void Task02()
        {
            //Подсчитать сумму нечетных положительных чисел
            int sum = 0;
            string str = string.Empty;
            FC.Input("Введите число", out int x);
            str += x;
            if (x % 2 == 1) sum += x;
            do
            {
                FC.Input("Введите число", out x);
                str += ", " + x;
                if (x % 2 == 1) sum += x;
            } while (x != 0);
            Console.WriteLine("Введенные числа: " + str);
            Console.WriteLine("Сумма нечетных положительных чисел равна: " + sum);
            FC.Pause();
        }
        #endregion
        #region Задание3
        static void Task03()
        {
            Fraction f1 = new Fraction(3, 5);
            Fraction f2 = new Fraction(4, 3);
            Fraction f3 = new Fraction(5, 3);
            Console.WriteLine("Первая дробь f1: " + f1);
            Console.WriteLine("Вторая дробь f2: " + f2);
            Console.WriteLine("Третья дробь f3: " + f3);
            Fraction result = f1 + f2;
            Console.WriteLine("result = f1 + f2 = " + result);
            Console.WriteLine("result = result - f3 = " + (result - f3));
            result = f1 * f2;
            Console.WriteLine("f1 * f2 = " + result);
            Console.WriteLine("f3 / f2 = " + (f3 / f2));
            FC.Pause();
        }
        class Fraction
        {
            private int znam;
            int Chisl { get; set; }
            int Znam
            {
                get { return znam; }
                set
                {
                    if (value != 0) znam = value;
                    else
                        throw new Exception("Знаменатель не может равняться 0!");
                }
            }
            public Fraction(int chisl, int znam)
            {
                Chisl = chisl;
                Znam = znam;
            }
            public static Fraction operator + (Fraction f1, Fraction f2)
            {
                if (f1.Znam == f2.Znam)
                    return new Fraction(f1.Chisl + f2.Chisl, f1.Znam);
                else
                    return new Fraction(f1.Chisl * f2.Znam + f2.Chisl * f1.Znam, f1.Znam * f2.Znam);
            }
            public static Fraction operator - (Fraction f1, Fraction f2)
            {
                if (f1.Znam == f2.Znam)
                    return new Fraction(f1.Chisl - f2.Chisl, f1.Znam);
                else
                    return new Fraction(f1.Chisl * f2.Znam - f2.Chisl * f1.Znam, f1.Znam * f2.Znam);
            }
            public static Fraction operator * (Fraction f1, Fraction f2)
            {
                return new Fraction(f1.Chisl * f2.Chisl, f1.Znam * f2.Znam);
            }
            public static Fraction operator / (Fraction f1, Fraction f2)
            {
                return new Fraction(f1.Chisl * f2.Znam, f1.Znam * f2.Chisl);
            }
            public void Simplify()
            {
                int x = Znam;
                while (Chisl % x != 0 || Znam % x != 0) x--;
                Chisl /= x;
                Znam /= x;
            }
            public override string ToString()
            {
                this.Simplify();
                return Chisl + "/" + Znam;
            }
        }
        #endregion
    }
}
