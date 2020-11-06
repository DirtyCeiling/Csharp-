using System;

namespace 餐厅交互_事件
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("HuangMeng");
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            Console.ReadLine();
        }
    }

    public class OrderEventArgs:EventArgs
    {
        public string DishName;
        public int Size;
    }

    public class Customer
    {
        private string Name ;
        public Customer(string name) { Name = name; }

        public int Bill;

        public event EventHandler Order;

        public void OnOrder(string dishName,int size)
        {
            if (Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
                Order?.Invoke(this, e);
            }
            Console.WriteLine("I will pay {0}",this.Bill);
        }

        public void Action()
        {
            this.OnOrder("Chicken",1);
        }
    }

    public class Waiter
    {
        internal void Action(object sender, EventArgs e)
        {
            Customer customer = sender as Customer;
            OrderEventArgs orderEventArgs = e as OrderEventArgs;
            Console.WriteLine("I will server you {0}",orderEventArgs.DishName);
            customer.Bill = 10;
        }
    }

}
