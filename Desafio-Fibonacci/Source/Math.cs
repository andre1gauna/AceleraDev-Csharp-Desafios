using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> fibonacci = new List<int>();
            int i = 1;
            fibonacci.Add(0);
            fibonacci.Add(1);


            while (fibonacci[i] <= 350)
            {
                i++;
                fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);

            }

            if (fibonacci[i] >= 350)
            {
                fibonacci.RemoveAt(i);
            }

            return fibonacci;
        }

        public bool IsFibonacci(int numberToTest)
        {

            if (Fibonacci().Contains(numberToTest))
            {
                return true;
            }

            else return false;
        }
    }
}
