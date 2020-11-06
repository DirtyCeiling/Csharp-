using BabyStroller.SDK;
using System;

namespace Animals.lib2
{
    public class Dog : IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Wang!");
            }
        }
    }
}
