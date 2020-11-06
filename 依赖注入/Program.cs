using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace 依赖注入
{
    class Program
    {
        static void Main(string[] args)
        {
            var sc = new ServiceCollection();
            sc.AddScoped(typeof(ITank), typeof(HeaveTank));//好处 可以在此处改接口的实现类
            sc.AddScoped(typeof(IVehicle), typeof(Car));
            sc.AddScoped<Driver>();
            var sp = sc.BuildServiceProvider();
            //============华丽的分割线=========
            ITank tank = sp.GetService<ITank>();
            tank.Fire();
            tank.Run();
            var driver = sp.GetService<Driver>();
            driver.Drive();
        }
    }
    class Driver
    {
        private IVehicle _tank;
        public Driver(IVehicle tank)
        {
            _tank = tank;
        }
        public void Drive()
        {
            _tank.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck");
        }
    }

    interface Weapon
    {
        void Fire();
    }


    interface ITank : IVehicle, Weapon
    {
    }

    class LightTank : ITank
    {
        public void Fire()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("LightTank");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("MidiumTank");
        }
    }
    class HeaveTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Fire");
        }

        public void Run()
        {
            Console.WriteLine("HeaveTank");
        }
    }
}
