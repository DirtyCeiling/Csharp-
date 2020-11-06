using System;
using System.Collections.Generic;

namespace 索引器
{
    class Program
    {
        static void Main(string[] args)
        {
            Student LiHao = new Student();
            LiHao["Math"] = 90;
            Console.WriteLine(LiHao["Math"]);
        }

        class Student
        {
            private int age;
            private Dictionary<string, int> scoreDictionary=new Dictionary<string, int>();

            public int? this[string subject]
            {
                get
                {
                    if (this.scoreDictionary.ContainsKey(subject))
                        return scoreDictionary[subject];
                    else
                        return null;
                }
                set
                {
                    if (value.HasValue == false)
                        throw new Exception("不能设置空值为成绩");
                    if (this.scoreDictionary.ContainsKey(subject))
                        this.scoreDictionary[subject] = value.Value;
                    else
                        this.scoreDictionary.Add(subject, value.Value);
                }
            }

            public int Age
            {
                get { return age; }
                set {
                    if (value >= 0 && value <= 120)
                        this.age = value;
                    else
                        throw new Exception("岁数输入是否有错误");
                }
            }

        }

        
    }
}
