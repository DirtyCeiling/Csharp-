using System;
using System.Runtime.InteropServices;


//传值参数为引用类型时，实际上用不用ref的效果是一样的，但是机理不一样
//
namespace 函数参数
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int a = 10;
            //Change(a);
            //Console.WriteLine("HashCode{0},Value{1}", a.GetHashCode(), a);

            Student stu = new Student() { Name = "Tim" };
            //Console.WriteLine("{0},{1}", stu.GetHashCode(), stu.Name);
            SomeMethod( stu);
            Console.WriteLine(getMemory(stu));
            Console.WriteLine("{0},{1}", stu.GetHashCode(), stu.Name);

        }

        static void Change(int a)
        {
            a = 20;
            Console.WriteLine("HashCode{0},Value{1}", a.GetHashCode(), a);
        }

        static void SomeMethod( Student stu)
        {
            //stu = new Student() { Name = "Tom" };
            stu.Name = "Tom";
            int a = 1;
            Console.WriteLine(getMemory(a));
            Console.WriteLine("{0},{1}", stu.GetHashCode(), stu.Name);
        }

        static void UpdateObject(Student stu)
        {

        }

        public static string getMemory(object o) // 获取引用类型的内存地址方法
        {
            GCHandle h = GCHandle.Alloc(o, GCHandleType.Pinned);
            IntPtr addr = h.AddrOfPinnedObject();
            return addr.ToString("X");
        }
    }



    class Student
    {
        public string Name { get; set; }
    }
}
