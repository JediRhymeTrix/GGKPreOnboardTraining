using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutivePrimeSum
{
    class Program
    {
        private HashSet<int> _primes = new HashSet<int>();

        public int FindNumberOfPrimes(int start, int end)
        {
            SetPrimes(end);

            int primeCount = 0;
            int[] localPrimes = _primes.ToArray();
            int length = localPrimes.Length;
                        
            for(int window = 1; window <= length; window++)
            {
                int sum = 0;

                for(int index = 0; index < window; index++)
                {
                    sum += localPrimes[index];

                    if(sum > end)
                    {
                        return primeCount;
                    }
                }

                if (IsPrime(sum))
                {
                    primeCount++;
                }
            }

            return primeCount;
        }

        private void SetPrimes(int max)
        {
            _primes.Add(2);

            for (int i = 3; i <= max; i++)
            {
                if(IsPrime(i))
                {
                    _primes.Add(i);
                }
            }
        }

        private bool IsPrime(int num)
        {
            if(num % 2 == 0)
            {
                return false;
            }

            if(_primes.Contains(num))
            {
                return true;
            }

            foreach(int prime in _primes)
            {
                if(num % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the upper limit of the range: ");
            int limit = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Number of valid primes found: " + new Program().FindNumberOfPrimes(3, limit));
            Console.ReadKey();
        }

        
    }
}
