using System;

namespace 拓展方法
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student() { Name = "James" };
            Student b = new Student() { Name = "Tames" };
            Estimate(a,b);
            Console.ReadKey();

            double x = 3.14259;
            double y = x.Round(4);
            Console.WriteLine(y);

        }

        static void Estimate(params Student[] a)

        {
            foreach(var i in a)
            {
                if (i.Name == "James")
                    Console.WriteLine(i.Name);
            }
        }
        

    }

    static class DoubleExtension
    {
        public static double Round(this double input, int digits)
        {
            Double result = Math.Round(input, digits);
            return result;
        }
    }

    class Student
    {
        public string Name { get; set; }
    }
}
