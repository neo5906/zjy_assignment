using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("输入第一个数字：");
            String s1 = Console.ReadLine();
            double num1 = double.Parse(s1);
            Console.Write("输入第二个数字：");
            String s2 = Console.ReadLine();
            double num2 = double.Parse(s2);
            Console.Write("输入运算符：");
            String s3 = Console.ReadLine();
            switch (s3)
            {
                case "+":
                    Console.WriteLine(num1+num2);
                    break;
                case "-":
                    Console.WriteLine(num1 - num2);
                    break;
                case "*":
                    Console.WriteLine(num1 * num2);
                    break;
                case "/":
                    if (num2 != 0) Console.WriteLine(num1 / num2);
                    else Console.WriteLine("输入错误");
                    break;
                default:
                    Console.WriteLine("输入错误");
                    break;
            }
            Console.Read();
        }
    }
}
