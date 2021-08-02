using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class ThreadPoolExample
    {
        public static void Main(string[] args)
        {
            int nWorkerThreads;
            int nCompletionThreads = 2;

            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionThreads);


            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(Print);
            }

            Thread.Sleep(3000);

            Console.ReadLine();

        }

        static void Print(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Cycle {i}, thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }
    }
}
