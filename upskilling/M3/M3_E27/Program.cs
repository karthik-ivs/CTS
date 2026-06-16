using System;
using System.Threading;

class Program
{
    static object lock1 = new object();
    static object lock2 = new object();

    static void Thread1()
    {
        lock (lock1)
        {
            Console.WriteLine("Thread1 acquired Lock1");

            Thread.Sleep(100);

            if (Monitor.TryEnter(lock2, 1000))
            {
                try
                {
                    Console.WriteLine("Thread1 acquired Lock2");
                }
                finally
                {
                    Monitor.Exit(lock2);
                }
            }
            else
            {
                Console.WriteLine("Thread1 avoided deadlock");
            }
        }
    }

    static void Thread2()
    {
        lock (lock2)
        {
            Console.WriteLine("Thread2 acquired Lock2");

            Thread.Sleep(100);

            if (Monitor.TryEnter(lock1, 1000))
            {
                try
                {
                    Console.WriteLine("Thread2 acquired Lock1");
                }
                finally
                {
                    Monitor.Exit(lock1);
                }
            }
            else
            {
                Console.WriteLine("Thread2 avoided deadlock");
            }
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(Thread1);
        Thread t2 = new Thread(Thread2);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}