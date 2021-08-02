using System;
using System.Threading;
using Threads;

namespace Threads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            Multiplier multiplier = new Multiplier(firstNumber,secondNumber);
            Thread firstThread = new Thread(multiplier.Multiply);
            Thread secondThread = new Thread(multiplier.Multiply);
            Thread thirdThread = new Thread(multiplier.Multiply);
            Thread fourthThread = new Thread(multiplier.Multiply);
            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();
            fourthThread.Start();
            firstThread.Join();
            secondThread.Join();
            thirdThread.Join();
            fourthThread.Join();
            Console.WriteLine(multiplier.Result);

        }






    }
}
