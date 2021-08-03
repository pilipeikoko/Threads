using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class AsyncExample
    {
        public static void Main(string[] args)
        {
            Task<int> b = PrintAsync();
          
            for(int i = 100; i < 200; ++i)
            {
                Console.WriteLine(1);
                if (i == 150)
                {
                    Console.WriteLine(b.Result);
                }
            }

            Console.ReadLine();
        }

        public static async Task<int> PrintAsync()
        {
            
            return await Task.Run(PrintSomething);
            
        }

        public static int PrintSomething() { 
            for(int i = 0; i < 100; ++i)
            {
                Console.WriteLine("A");
            }
            return 20;
        }

    }
}
