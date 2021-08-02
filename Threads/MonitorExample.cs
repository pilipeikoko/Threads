using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class MonitorExample
    {
        object locker = new();

        public void PrintHello()
        {
            lock (locker)
            {
                Console.Write("Hello ");
                // Let PrintWorld run
                Monitor.Pulse(locker);
                // And waiting till its over
                Monitor.Wait(locker);
            }
        }

        public void PrintWorld()
        {
            lock (locker)
            {
                Console.WriteLine("World");
                Monitor.Pulse(locker);
                Monitor.Wait(locker);
            }
        }
    }

    class CustomThread
    {
        Thread thread;
        MonitorExample monitorExample;

        public CustomThread(string name, MonitorExample monitorExample)
        {
            this.monitorExample = monitorExample;
            thread = new Thread(this.Run);
            thread.Name = name;
            thread.Start();
        }

        void Run()
        {
            if (thread.Name == "hello")
            {
                for (int i = 0; i < 5; ++i)
                {
                    monitorExample.PrintHello();
                }
            }
            else if (thread.Name == "world")
            {
                for (int i = 0; i < 5; ++i)
                {
                    monitorExample.PrintWorld();
                }
            }
        }
    }

    class Run
    {
        public static void Main(string[] args)
        {
            MonitorExample monitorExample = new();
            CustomThread thread1 = new("hello", monitorExample);
            CustomThread thread2 = new("world", monitorExample);
        }
    }
}
