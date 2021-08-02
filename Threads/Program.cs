using System;
using System.Threading;
using Threads;

namespace Threads
{
    public class Program
    {
        private class Multiplier
        {
            int firstNumber;
            int secondNumber;
            public int rankToMultiply;
            public int result;
            public int Result {
                get { 
                    return result;
                }
            }


            private object locker = new object();

            public Multiplier(int firstNumber, int secondNumber)
            {
                this.firstNumber = firstNumber;
                this.secondNumber = secondNumber;
            }

            public void Multiply()
            {
                int firstNumber;
                int secondNumber;
                int currentRank;

                lock (locker)
                {
                    firstNumber = this.firstNumber;
                    secondNumber = this.secondNumber;
                    currentRank = this.rankToMultiply++;
                }


                int numToMultiply = (secondNumber / (int)Math.Pow(10, currentRank)) % 10;
                int tempResult = numToMultiply * firstNumber;
                Interlocked.Add(ref result, tempResult * (int)Math.Pow(10, currentRank));
            }
        }


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
