using System;
using System.IO;
using MenuLib;
using FC = MenuLib.FastConsole;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.delMenu[] delMenus = new Menu.delMenu[] { Task01, Task02, Task03, Task04 };
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
                Multi(-1);
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
                x++;
                Console.WriteLine($"Неверный логин или пароль, попыток осталось: {3-x}");
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
        #region Задание 4
        static void Task04()
        {
            MyDoubleArray myArr = new MyDoubleArray(3, 3);
            Console.WriteLine(myArr);
            Console.WriteLine("Sum: " + myArr.Sum());
            Console.WriteLine("Sum(>): " + myArr.SumX(20));
            Console.WriteLine("Min: " + myArr.Min);
            Console.WriteLine("Max: " + myArr.Max);
            myArr.MaxIndex(out int x, out int y);
            Console.WriteLine($"Индекс максимального элемента: {x},{y}");
            MyDoubleArray myArrayText = new MyDoubleArray("test3.txt");
            Console.WriteLine(myArrayText);
            myArrayText.OutPut("test4.txt");
            FC.Pause();
        }
        class MyDoubleArray
        {
            int[,] arr;

            public MyDoubleArray(int strSize, int stbSize)
            {
                arr = new int[strSize, stbSize];
                Random rnd = new Random();
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for(int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = rnd.Next(0, 100);
                    }
                }
            }
            public MyDoubleArray(string path)
            {
                StreamReader sr = new StreamReader(path);
                int x = int.Parse(sr.ReadLine());
                int y = int.Parse(sr.ReadLine());
                arr = new int[x, y];
                for(int i = 0; i < arr.GetLength(0); i++)
                {
                    string str = sr.ReadLine();
                    string[] strArr = str.Split(' ');

                    for(int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = int.Parse(strArr[j]);
                    }
                }
                sr.Close();
            }

            public int Sum()
            {
                int sum = 0;
                for(int i = 0; i < arr.GetLength(0); i++)
                {
                    for(int j = 0; j < arr.GetLength(1); j++)
                    {
                        sum += arr[i, j];
                    }
                }
                return sum;
            }
            public int SumX(int x)
            {
                int sum = 0;
                for(int i = 0; i < arr.GetLength(0); i++)
                {
                    for(int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] > x) sum += arr[i, j];
                    }
                }
                return sum;
            }
            public void MaxIndex(out int strIndex, out int stbIndex)
            {
                strIndex = 0;
                stbIndex = 0;
                int max = arr[strIndex, stbIndex];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] > max)
                        {
                            max = arr[i, j];
                            strIndex = i;
                            stbIndex = j;
                        }
                    }
                }
            }
            public void OutPut(string path)
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(arr.GetLength(0));
                sw.WriteLine(arr.GetLength(1));
                for(int i = 0; i < arr.GetLength(0); i++)
                {
                    for(int j = 0; j < arr.GetLength(1); j++)
                    {
                        sw.Write(arr[i, j]);
                        if (j != arr.GetLength(1) - 1) sw.Write(" ");
                    }
                    sw.Write("\r\n");
                }
                sw.Close();
            }
            public int Min
            {
                get
                {
                    int min = arr[0, 0];
                    for(int i = 0; i < arr.GetLength(0); i++)
                    {
                        for(int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (arr[i, j] < min) min = arr[i, j];
                        }
                    }
                    return min;
                }
            }
            public int Max
            {
                get
                {
                    int max = arr[0, 0];
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (arr[i, j] > max) max = arr[i, j];
                        }
                    }
                    return max;
                }
            }
            public override string ToString()
            {
                string str = "";
                for(int i = 0; i < arr.GetLength(0); i++)
                {
                    for(int j = 0; j < arr.GetLength(1); j++)
                    {
                        str += arr[i, j] + " ";
                    }
                    str += "\n";
                }
                return str;
            }
        }
        #endregion
    }
}
