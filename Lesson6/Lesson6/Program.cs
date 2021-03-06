﻿using MenuLib;
using System;
using FC = MenuLib.FastConsole;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.delMenu[] delMenu = new Menu.delMenu[] { Task1, Task2, Task3 };
            Menu menu = new Menu(delMenu);
            menu.ChooseMenu();
        }
        #region Задание 1
        static void Task1()
        {
            //Создать метод, который будет выводить значения ф-ий от a до b. Для передачи разных ф-ий использовать делегаты.
            Console.WriteLine("Таблица функции A*x^2");
            Task01.Table(Task01.MyMethod1, 10, -2, 2);
            Console.WriteLine("Таблица функции A*sin(x)");
            Task01.Table(Task01.MyMethod2, 10, -2, 2);
            FC.Pause();
        }
        #endregion
        #region Задание 2
        static void Task2()
        {
            /*  Модифицировать программу нахождения минимума функции так, чтобы можно было
                передавать функцию в виде делегата.
                а) Сделать меню с различными функциями и представить пользователю выбор, для какой
                функции и на каком отрезке находить минимум.
                б) Использовать массив (или список) делегатов в котором хранятся различные функции.
                в) *Переделать функцию Load, чтобы она возвращала массив считанных значений, а минимум возвращала через параметр.*/
            Task02.delFun[] delFuns = new Task02.delFun[] { Math.Sin, Math.Cos, Math.Tan, Math.Atan, Task02.MyMethod };
            Task02.delFun fun = Task02.ChooseMenu(delFuns);

            Console.WriteLine("Введите A:");
            Int32.TryParse(Console.ReadLine(), out int a);
            Console.WriteLine("Введите B:");
            Int32.TryParse(Console.ReadLine(), out int b);

            Task02.SaveFun("data.bin", fun , a, b, 2);
            double[] arr = Task02.Load("data.bin", out double min);
            foreach(double db in arr)
            {
                Console.Write(db + " ");
            }
            FC.Pause();
        }
        #endregion
        #region Задание 3
        static void Task3()
        {
            /* Создать класс описывающий студента
             * считать данные из файла
             * подсчитать кол-во бакалавров и магистров, количество человек на 5 и 6 курсах 
             * создать частотный массив студентов по курсам в возрасте от 18 до 20 лет 
             * реализовать сортировки по различным параметрам 
             * разработать единый метод подсчета количества студентов по различным параметрам выбора с помощью делегата и методов предикатов.*/
            Task03.Task3();
        }
        #endregion

    }
}
