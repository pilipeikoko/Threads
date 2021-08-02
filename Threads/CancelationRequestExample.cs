using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class CancelationRequestExample
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task = new Task(() =>
            {
                for (int i = 0; i < 20000; ++i)
                {
                    Console.WriteLine(i);
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                }
            });
            task.Start();

            //Press enter to cancel
            Console.ReadLine();
            cancelTokenSource.Cancel();
            Console.ReadLine();
        }
    }
}
