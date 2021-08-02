using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class TaskExample
    {
        public static void Main(string[] args)
        {
            //Simple task example, diffirent types of runs
            Task task = new Task(() => Console.WriteLine("ok"));
            task.Start();
            Task task1 = new Task(PrintMessage);
            task1.Start();
            Task task2 = Task.Run(PrintMessage);


            //So Main waits till task2 is over
            task2.Wait();


            //Task may return a value
            Task<int> intTask = new Task<int>(ReturnOne);
            intTask.Start();
            //.Result awaits till task is done
            Console.WriteLine(intTask.Result);


            //Continue task example
            Task<int> mathTask = new Task<int>(() => (int)Math.Pow(3, 6));
            Task afterMathTask = mathTask.ContinueWith(num => PrintMessage(num.ToString()));

        }

        public static int ReturnOne()
        {
            return 1;
        }

        public static void PrintMessage()
        {
            Console.WriteLine("Message");
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
