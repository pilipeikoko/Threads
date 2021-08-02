using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class Multiplier
    {
        int firstNumber;
        int secondNumber;
        int result;
        public int rankToMultiply;
        public int Result
        {
            get
            {
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
}
