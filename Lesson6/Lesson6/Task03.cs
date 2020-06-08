using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lesson6
{
    [Serializable]
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public string Department { get; set; }
        public int Group { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public Student(string firstName, string lastName, string university, string faculty, string department, 
            int age, int course, int group, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            University = university;
            Faculty = faculty;
            Department = department;
            Age = age;
            Course = course;
            Group = group;
            City = city;
        }
        public Student() { }

        public static int Counter(List<Student> students, Predicate<Student> predicate)
        {
            int count = 0;
            foreach(Student student in students)
                if (predicate(student)) count++;
            return count;
        }
    }
    class Task03
    {
        static int CompareName(Student st1, Student st2)
        {
            return string.Compare(st1.FirstName, st2.FirstName);
        }
        static int CompareAge(Student st1, Student st2)
        {
            return st1.Age - st2.Age;
        }
        static int CompareCourseAge(Student st1, Student st2)
        {
            int res = st1.Course - st2.Course;
            if (res == 0) return (st1.Age - st2.Age);
            return res;
        }
        static bool IsBachelor(Student student)
        {
            return student.Course < 5;
        }

        static void Save(List<Student> list, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fs, list);
            fs.Close();
        }
        static List<Student> Load(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            List<Student> list = new List<Student>();
            list = (List<Student>)xmlSerializer.Deserialize(fs);
            fs.Close();
            return list;
        }

        public static void Task3()
        {
            int bachelor = 0;
            int magistr = 0;
            int fifth = 0;
            int sixth = 0;
            int[] arrCourse = new int[6];
            List<Student> list = new List<Student>();

            StreamReader sr = new StreamReader("student.csv", System.Text.Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] arrStr = sr.ReadLine().Split(';');
                    Student s = new Student(arrStr[0], arrStr[1], arrStr[2], arrStr[3], arrStr[4],
                        int.Parse(arrStr[5]), int.Parse(arrStr[6]), int.Parse(arrStr[7]), arrStr[8]);
                    list.Add(s);
                    if (s.Course > 4)
                    {
                        magistr++;
                        if (s.Course == 5) fifth++; else sixth++;
                    }
                    if (s.Age > 17 && s.Age < 21) arrCourse[s.Course - 1]++;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            Save(list, "student.xml");
            list = Load("student.xml");
            bachelor = Student.Counter(list, IsBachelor);
            Console.WriteLine("Всего студентов: " + list.Count);
            Console.WriteLine("Всего бакалавров: " + bachelor);
            Console.WriteLine("Всего магистров: " + magistr);
            Console.WriteLine("Количество студентов в возрасте от 18 до 20 лет:");
            for(int i = 0; i < arrCourse.Length; i++)
            {
                Console.WriteLine($"Курс: {i + 1} Количество студентов: {arrCourse[i]}");
            }
            Comparison<Student> comparison = CompareName;
            list.Sort(comparison);
            foreach (Student student in list)
                Console.WriteLine($"Имя: {student.FirstName}");
            list.Sort(CompareAge);
            foreach (Student student in list)
                Console.WriteLine($"Имя: {student.FirstName} Возраст: {student.Age}");
            list.Sort(CompareCourseAge);
            foreach (Student student in list)
                Console.WriteLine($"Имя: {student.FirstName} Курс: {student.Course} Возраст: {student.Age}");
            Console.ReadLine();
        }
    }
}
