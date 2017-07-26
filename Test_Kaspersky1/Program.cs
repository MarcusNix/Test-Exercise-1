using System;
using System.Collections.Generic;
using System.Threading;

namespace Test_Kaspersky1
{
    class Program
    {
        static Queue<int> objQueue = new Queue<int>();
        static object locker = new object();
        static Random r = new Random();
        static void mythread1()
        {
            if (objQueue.Count == 0)
            {
                Push();
            }
            else
            {
                Pop();
            }
        }
        static void mythread2()
        {
            if (objQueue.Count != 0)
            {
                Pop();
            }
            else
            {
                Push();
            }
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(mythread1);
            Thread thread2 = new Thread(mythread2);
            thread1.Start();
            //thread1.Join();
            thread2.Start();
            Console.ReadLine();
        }
        static void Pop()
        {
                int item = 0;
                lock (locker)
                    item = objQueue.Dequeue();
                    Console.WriteLine("Вынули элемент {0}", item);
                    Console.WriteLine("Количество элементов {0}", objQueue.Count);
        }
        static void Push()
        {          
                int item = r.Next(0, 101);
                lock (locker)
                    objQueue.Enqueue(item);
                    Console.WriteLine("Вставили элемент {0}", item);
                    Console.WriteLine("Количество элементов {0}", objQueue.Count);           
        }
    }
}
