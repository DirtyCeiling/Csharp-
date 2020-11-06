using System;

/// <summary>
/// 委托到底是什么东西
/// 委托是用来做什么的
/// 委托是什么时候来使用
/// 使用委托的好处
/// </summary

//Lambda表达式

//委托的实例化方式


namespace 委托
{

    delegate int SumDe(int a, int b);
    class Program
    {

        static void Main(string[] args)
        {
            SumDe sumde=new SumDe(Sum);
            Action say1 = new Action(cw);
            //ACtion的lambda表达式
            Action say2 = () => { Console.WriteLine("dad"); };
            say1 += cw2;
            say1.Invoke();



            Caculator caculatorSum = new Caculator();
            caculatorSum.sum += Sum;
            Console.WriteLine(sumde(1,2));

            SumDe sum1 = new SumDe(Sum);
            //这种委托有什么作用

        }
        public static int  Sum(int a,int b)
        {
            return a + b;
        }

        public static void cw()
        {
            Console.WriteLine("Hello world !");
        }

        public static void cw2()
        {
            Console.WriteLine("I love the world");
        }
    }

    class Caculator {
        public  SumDe sum;
    }



}
