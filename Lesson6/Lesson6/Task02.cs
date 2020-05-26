using System;
using System.IO;

namespace Lesson6
{
    class Task02
    {
        public delegate double delFun(double x);

        public static void SaveFun(string fileName, delFun fun, double a, double b, double h)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fileStream);
            while (a <= b)
            {
                bw.Write(fun(a));
                a += h;
            }
            bw.Close();
            fileStream.Close();
        }
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            double[] arr = new double[fs.Length / sizeof(double)];
            min = double.MaxValue;
            double d;
            for(int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = br.ReadDouble();
                arr[i] = d;
                if (d < min) min = d;
            }
            br.Close();
            fs.Close();
            return arr;
        }
        public static delFun ChooseMenu(delFun[] delFuns)
        {
            int num;
            num = 1;
            Console.WriteLine($"Для выбора функции введите номер функции от 1 до {delFuns.Length}");
            foreach (delFun del in delFuns)
                Console.WriteLine(num++ + " - " + del.Method.Name);
            Int32.TryParse(Console.ReadLine(), out num);
                return delFuns[num - 1];
        }
        public static double MyMethod(double x)
        {
            return x * x;
        }
    }
}
