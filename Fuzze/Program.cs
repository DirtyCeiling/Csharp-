using System;

namespace Fuzze
{
    class Program
    {

        //我想写一个交互界面，但不是图形的交互方式

        //桌子是线程总数，
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.eventHandler += waiter.Serve;
            customer.Order("HuangGua");
        }

        public class DishEventArgs : EventArgs {
            public string DishName;
            public DishEventArgs(string dishName)
            {
                DishName = dishName;
            }
        }


        public class Customer
        {
            public event EventHandler eventHandler;

            public void Order(string dishName)
            {
                DishEventArgs e = new DishEventArgs(dishName);
                eventHandler?.Invoke(this,e);
            }
        }

        public class Waiter
        {
            internal void Serve(object sender, EventArgs e)
            {
                DishEventArgs a = e as DishEventArgs;
                Console.WriteLine(a.DishName);
            }
        }
    }
}
