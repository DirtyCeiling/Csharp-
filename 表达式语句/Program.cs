using System;

namespace 表达式语句
{
    class Program
    {
        public static object Parse { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入成绩");
            string a=Console.ReadLine();
            int b = int.Parse(a);
            Grade(b);
            MyScore a1=MyScore.excellent;
            switch (a1)
            {
                case MyScore.excellent:
                    Console.WriteLine("excellent");
                    break;
                case MyScore.good:
                    Console.WriteLine("good");
                    break;
                default:
                    break;
            }
           
        }

        public static void  Grade(int score)
        {
            if (score >= 0 && score <= 100)
            {
                if (score > 90)
                    Console.WriteLine("优秀");
                else if (score > 70)
                    Console.WriteLine("良");
                else if (score > 60)
                    Console.WriteLine("及格");
                else if(score<60)
                    Console.WriteLine("不及格");
            }
            else
            {
                Console.WriteLine("请重新输入");
            }
        }

        public enum MyScore
        {
           well,
            good,
            excellent
        }
    }


}
