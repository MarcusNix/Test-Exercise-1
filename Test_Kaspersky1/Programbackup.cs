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
            int item = r.Next(0, 101);
            lock (locker)
                objQueue.Enqueue(item);
                Console.WriteLine("Вставили {0}", item);
                Console.WriteLine("Количество элементов {0}", objQueue.Count);
        }

        static void mythread2()
        {
            int item = 0;
            lock (locker)
                item = objQueue.Dequeue();
            Console.WriteLine("Вынули {0}", item);
            Console.WriteLine("Количество элементов {0}", objQueue.Count);
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(mythread1);
            Thread thread2 = new Thread(mythread2);
            //thread1.Priority = ThreadPriority.Highest;
            //thread2.Priority = ThreadPriority.AboveNormal;
            thread1.Start();
            thread1.Join();
            thread2.Start();
            Console.ReadLine();
        }
        static void Pop()
        {
           
        }
        static void Push()
        {
            while (true)
            {
                int item = r.Next(0, 101);
                lock (locker)
                {
                    objQueue.Enqueue(item);
                }
                Thread.Sleep(50);
                Console.WriteLine("Item {0} enqueued!", item);
            }
        }
    }
}
