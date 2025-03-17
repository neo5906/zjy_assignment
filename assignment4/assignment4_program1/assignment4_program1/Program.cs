﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4_program1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T data)
        {
            Next = null;
            Data = data;
        }
    }

    // 泛型链表类  
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

 
        public void ForEach(Action<T> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {  
            GenericList<int> list = new GenericList<int>();
            string s = Console.ReadLine();
            int[] arr = s.Split(' ').Select(int.Parse).ToArray();
            foreach (int d in arr)
            {
                list.Add(d);
            }

            Console.WriteLine("列表:");
            list.ForEach(item => Console.WriteLine(item));
  
            int max = int.MinValue;
            list.ForEach(item =>
            {
                if (item > max)
                    max = item;
            });
            Console.WriteLine($"最大值: {max}");
  
            int min = int.MaxValue;
            list.ForEach(item =>
            {
                if (item < min)
                    min = item;
            });
            Console.WriteLine($"最小值: {min}");

            int sum = 0;
            list.ForEach(item => sum += item);
            Console.WriteLine($"总和: {sum}");

            Console.ReadLine();
        }
    }
}
