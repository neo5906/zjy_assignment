using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_project4
{
    internal class Program
    {
        static bool Tplc(int[,] matrix,int m,int n)
        {
            for(int i=0; i<m-1; i++)
            {
                for (int j=1; j < n; j++)
                {
                    if (matrix[i, j - 1] != matrix[i + 1, j]) return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入矩阵行数：");
            string ms=Console.ReadLine();
            Console.WriteLine("请输入矩阵列数：");
            string ns = Console.ReadLine();
            int m = int.Parse(ms);
            int n= int.Parse(ns);
            int[,] matrix = new int[m, n];
            Console.WriteLine("请输入矩阵内容：");
            for (int i = 0; i < m ; i++)
            {
                string s = Console.ReadLine();
                int[] arr = s.Split(' ').Select(int.Parse).ToArray();
                for (int k = 0; k < n; k++)
                {
                    matrix[i, k] = arr[k];
                }
                
            }
            if (Tplc(matrix, m, n)) Console.WriteLine("True");
        }
    }
}
