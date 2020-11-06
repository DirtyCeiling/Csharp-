using BabyStroller.SDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace BabyStroller项目
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            var files = Directory.GetFiles(folder);
            var animalTypes = new List<Type>();
            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    //if (t.GetMethod("Voice") != null)
                    //    animalTypes.Add(t);
                    if (t.GetInterfaces().Contains(typeof(IAnimal)))
                    {
                        //var isUnfinished = t.GetCustomAttributes().Any(a => a.GetType() == typeof(UnfinishedAttribute));
                        //bool v = t.GetCustomAttributes().Any()
                        //便于理解的写法如下
                        System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);
                        bool isUnfinished = false;
                        foreach (var attr in attrs)
                        {
                            if (attr.GetType() == typeof(UnfinishedAttribute))
                                isUnfinished = true;
                        }

                        if (isUnfinished) continue;
                        animalTypes.Add(t);
                    }
                }
            }

            while (true)
            {
                for (int i = 0; i < animalTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1},{animalTypes[i].Name}");
                }
                Console.WriteLine("======================");
                Console.WriteLine("Please choose animal");
                int index = int.Parse(Console.ReadLine());
                if (index > animalTypes.Count || index < 1)
                {
                    Console.WriteLine("No Such an animal.Try again");
                    continue;
                }
                Console.WriteLine("Please input times");
                int times = int.Parse(Console.ReadLine());
                var t = animalTypes[index - 1];
                var m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);
                //m.Invoke(o, new object[] { times });

                var a = o as IAnimal;
                a.Voice(times);
            }
        }
    }
}
