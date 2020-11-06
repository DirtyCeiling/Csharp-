using System;
using System.Threading;

namespace 顾客与消费者_事件
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayTheBill();
        }
    }

    public class OrderEventArgs:EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer
    {
        public event OrderEventHandler Order;


        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0} ",this.Bill); 
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant");
        }
        public void Sitdown()
        {
            Console.WriteLine("Sit down");
        }

        public void Think()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think...");
                Thread.Sleep(1000);
            }
            this.OnOrder("Kongpao Chichen", "large");
        }

        protected void OnOrder(string dishName,string size)
        {
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
                this.Order.Invoke(this, e);
            }
        }

        public void Action()
        {
            Console.ReadLine();
            this.WalkIn();
            this.Sitdown();
            this.Think();
        }
    }

    public class Waiter
    {
        public  void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will serve you the dish -{0}",e.DishName);
            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
}
