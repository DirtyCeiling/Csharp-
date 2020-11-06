using BabyStroller.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.lib2
{
    class Tiger : IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("WuHu!");
            }
        }
    }
}
