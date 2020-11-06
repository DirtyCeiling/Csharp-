using System;

namespace 操作符详解
{
    class Program
    {
        static void Main(string[] args)
        {
            Student LiHao = new Student();
            try
            {

                LiHao.Age = 102;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Student
    {
        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value <= 100) age = value; else { throw new Exception("dada "); }
            }
        }

    }
}
