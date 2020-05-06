using System;
using System.IO;
using System.Net.WebSockets;
using MenuLib;
using FC = MenuLib.FastConsole;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.delMenu[] delMenus = new Menu.delMenu[] { Task01, Task02, Task03 };
            Menu menu = new Menu(delMenus);
            menu.ChooseMenu();
        }
        #region Задание 1
        static void Task01()
        {
            //Найти количество пар эл-ов, в которых хотя бы одно из чисел делится на 3.
            Random rnd = new Random();
            int[] arr = new int[20];
            for(int i = 0; i < 20; i++)
                arr[i] = rnd.Next(-10000, 10000);
            Console.WriteLine("Исходные данные:");
            foreach(int i in arr)
                Console.Write(i + " ");
            Console.WriteLine("\n");
            int count = 0;
            for (int i = 0; i < 19; i++)
            {
                if(arr[i]%3==0 || arr[i + 1] % 3 == 0)
                {
                    count++;
                    Console.WriteLine("Пара эл-ов: " + arr[i] + " " + arr[i + 1]);
                }
            }
            Console.WriteLine("\nКоличество пар: " + count);
            FC.Pause();
        }
        #endregion
        #region Задание 2
        static void Task02()
        {
            //Реализовать класс для работы с массивом, реализовать методы и св-ва для работы с массивом.
            MyArray myArray = new MyArray(10, 2, 3);
            Console.WriteLine(myArray);
            Console.WriteLine(myArray.Sum);
            myArray.Inverse();
            Console.WriteLine(myArray);
            myArray.Multi(2);
            Console.WriteLine(myArray);
            MyArray myArrayText = new MyArray("test.txt");
            Console.WriteLine(myArrayText);
            Console.WriteLine(myArrayText.Max);
            Console.WriteLine(myArrayText.MaxCount);
            myArray.Output("test2.txt");
            FC.Pause();
        }
        class MyArray
        {
            private int[] arr;

            public MyArray(int size)
            {
                arr = new int[size];
            }
            public MyArray(int size, int n, int step)
            {
                arr = new int[size];
                for(int i = 0; i < size; i++)
                {
                    arr[i] = n;
                    n += step;
                }
            }
            public MyArray(string path)
            {
                try
                {
                    StreamReader sr = new StreamReader(path);
                    int size = int.Parse(sr.ReadLine());
                    arr = new int[size];
                    for (int i = 0; i < arr.Length; i++)
                        arr[i] = int.Parse(sr.ReadLine());
                    sr.Close();
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }

            public int this[int i]
            {
                get { return arr[i]; }
                set { arr[i] = value; }
            }

            public int Sum
            {
                get
                {
                    int sum = 0;
                    foreach (int i in arr)
                        sum += i;
                    return sum;
                }
            }
            public void Inverse()
            {
                for(int i = 0; i < arr.Length; i++)
                    arr[i] = -arr[i];
            }
            public void Multi(int n)
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] *= n;
            }
            public int Max
            {
                get
                {
                    int max = arr[0];
                    for (int i = 1; i < arr.Length; i++)
                        if (arr[i] > max) max = arr[i];
                    return max;
                }
            }
            public int MaxCount
            {
                get
                {
                    int count = 0, max;
                    max = this.Max;
                    for (int i = 0; i < arr.Length; i++)
                        if (arr[i] == max) count++;
                    return count;
                }
            }
            public void Output(string path)
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(arr.Length);
                for (int i = 0; i < arr.Length; i++)
                    sw.WriteLine(arr[i]);
                sw.Close();
            }
            public override string ToString()
            {
                string str = "";
                foreach(int i in arr)
                    str += i + " ";
                return str;
            }
        }
        #endregion
        #region Задание 3
        static void Task03()
        {
            //Логин пароль
            int x = 0;
            do
            {
                string login = FC.Input("Введите логин");
                string password = FC.Input("Введите пароль");
                if (IsValid(login, password))
                {
                    Console.WriteLine("Успех!");
                    FC.Pause();
                    return;
                }
                Console.WriteLine("Неверный логин или пароль");
                x++;
            } while (x != 3);
            Console.WriteLine("Access Denied");
            FC.Pause();
        }
        static bool IsValid(string login, string password)
        {
            StreamReader sr = new StreamReader("access.txt");
            while (!sr.EndOfStream)
            {
                if (sr.ReadLine() == login & sr.ReadLine() == password)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
