using System;

namespace 接口隔离原则
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver Huang = new Driver(new HeaveTank());
            Huang.Drive();
            Console.ReadKey();
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


    interface IVecle:IVehicle,Weapon
    {
    }

    class LightTank : IVecle
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

    class MediumTank : IVecle
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
    class HeaveTank : IVecle
    {
        public void Fire()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("HeaveTank");
        }
    }
}
