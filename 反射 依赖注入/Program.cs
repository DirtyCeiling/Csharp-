using System;
using System.Reflection;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {
            ITank tank = new HeaveTank();
            //======华丽的分割线=========
            var t = tank.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo fireMi = t.GetMethod("Fire");
            MethodInfo runMi = t.GetMethod("Run");
            fireMi.Invoke(o, null);
            runMi.Invoke(0, null);
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
