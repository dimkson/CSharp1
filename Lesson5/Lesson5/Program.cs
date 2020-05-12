using MenuLib;
using System;
using System.Text;
using System.Text.RegularExpressions;
using FC = MenuLib.FastConsole;

namespace Lesson5
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
            //Проверка корректности ввода логина. (от 2х до 10ти символов, содержит только буквы и цифры, цифра не может быть первой.)
            string login;
            do
            {
                login = FC.Input("Введите логин или exit для выхода");
                Console.WriteLine(Login.IsCorrect(login) ? "Логин корректен" : "Логин некорректен");
                Console.WriteLine(Login.IsCorrectReg(login) ? "Логин корректен" : "Логин некорректен");
            } while (login != "exit");
        }
        static class Login
        {
            public static bool IsCorrect(string login)
            {
                if (login.Length >= 2 && login.Length <= 10 && !char.IsDigit(login[0]))
                {
                    foreach (char ch in login)
                        if (!char.IsLetterOrDigit(ch)) return false;
                    return true;
                }
                else
                    return false;
            }
            public static bool IsCorrectReg(string login)
            {
                Regex regex = new Regex(@"^\p{L}[\w]{1,9}$");
                return regex.IsMatch(login);
            }
        }
        #endregion
        #region Задание 2
        static void Task02()
        {
            MyString myString = new MyString(FC.Input("Введите строку"));
            Console.WriteLine("Слова не длиннее 5 букв");
            myString.Print(5);
            myString.Delete('а');
            myString.Max();
            FC.Pause();
        }
        class MyString
        {
            private string str;
            private string[] arrStr;
            public MyString(string str)
            {
                this.str = str;
                char[] arrCh = { ' ', '!', '.', ',', '?' };
                arrStr = str.Split(arrCh, StringSplitOptions.RemoveEmptyEntries);
            }

            public void Print(int n)
            {
                foreach(string str in arrStr)
                {
                    if (str.Length <= n)
                        Console.WriteLine(str);
                }
            }
            public void Delete(char ch)
            {
                StringBuilder sb = new StringBuilder(str);
                foreach(string str in arrStr)
                {
                    if (str[str.Length - 1] == ch)
                        sb.Replace(str, "");
                }
                Console.WriteLine(sb.ToString());
            }
            public void Max()
            {
                string max = arrStr[0];
                int count = 1;
                foreach(string str in arrStr)
                {
                    if (str.Length > max.Length)
                    {
                        max = str;
                        count = 1;
                    }
                    else if(str.Length == max.Length)
                        count++;
                }
                Console.WriteLine($"Максимальный элемент {max}, встречается {count} раз");
            }
        }
        #endregion
        #region Задание 3
        static void Task03()
        {
            //Определить является ли одна строка перестановкой другой строки
            string str1 = FC.Input("Введите первую строку").ToUpper();
            string str2 = FC.Input("Введите вторую строку").ToUpper();
            if (str1.Length == str2.Length)
            {
                StringBuilder sb = new StringBuilder(str2);
                foreach (char ch1 in str1)
                {
                    //str2.Remove(str2.IndexOf(ch1), 1);
                    for (int i = 0; i < sb.Length; i++)
                    {
                        if (ch1 == sb[i])
                        {
                            sb.Remove(i, 1);
                            break;
                        }
                    }
                }
                Console.WriteLine("Строки " + (sb.Length == 0 ? "" : "не ") + "являются перестановкой друг друга");
            }
            else
                Console.WriteLine("Строки имеют разную длину");
            FC.Pause();
        }
        #endregion
    }
}
