using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String s=Console.ReadLine();
            int num = int.Parse(s);
            if(num<2)
            {
                Console.WriteLine("无素数因子");
            }
            else
            {
                Console.WriteLine("素数因子有：");
                int ans = 2;
                int n = num;
                int former = 1;
                while (ans <= n)
                {
                    
                    if(n % ans == 0)
                    {
                        n = n / ans;
                        if (ans != former)
                        {
                            Console.WriteLine(ans + " ");
                            former = ans;
                        }
                    }
                    else if(n%ans!=0) 
                    {
                        ans++;
                    }
            
                }
            }
            Console.Read();
        }
    }
}
