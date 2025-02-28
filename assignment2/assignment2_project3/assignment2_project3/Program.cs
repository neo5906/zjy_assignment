using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] arr=new bool [101];
            for(int i=0; i<arr.Length; i++)
            {
                arr[i] = true;
            }
            arr[0] = arr[1] = false ;
            int n = 2;
            while (n * n < arr.Length - 1)
            {
                for (int i = 2; i < arr.Length; i++)
                {
                    if (i!=n&&i % n == 0)
                    {
                        arr[i] = false;
                    }
                }
                for(int j=n+1;j<arr.Length; j++)
                {
                    if (arr[j]==true)
                    {
                        n = j;
                        break;
                    }
                }
            }
            for(int i = 2; i < arr.Length; i++)
            {
                if (arr[i]==true)
                {
                    Console.WriteLine(i);
                }
            }
            Console.Read();
         }
    }
}
