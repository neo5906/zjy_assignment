using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_project2
{
    internal class Program
    {
        static int MyMax(int[] arr)
        {
            int max = arr[0];
            foreach (int i in arr)
            {
                if (i > max) max = i;
            }
            return max;
        }
        static int MyMin(int[] arr)
        {
            int min = arr[0];
            foreach (int i in arr)
            {
                if (i < min) min = i;
            }
            return min;
        }
        static int Mysum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
        static double Myavg(int[] arr)
        {
            double n = arr.Length;
            double answer = Mysum(arr) ;
            return answer/n;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组：");
            string s=Console.ReadLine();
            int[] arr=s.Split(' ').Select(int.Parse).ToArray();
            int n = arr.Length;
            if (n == 0) Console.WriteLine("数组不能为空");
            else
            {
                Console.WriteLine("最大值：" + MyMax(arr));
                Console.WriteLine("最小值："+MyMin(arr));
                Console.WriteLine("平均值："+Myavg(arr));
                Console.WriteLine("和："+Mysum(arr));
            }
            Console.ReadLine();
        }
    }
}
