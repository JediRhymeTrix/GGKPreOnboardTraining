using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiAvgPrimes
{
    class Program
    {
        private HashSet<int> _primes = new HashSet<int>();

        string ProcessString(string input)
        {
            StringBuilder result = new StringBuilder();
            var length = input.Length;

            for (int i = 0; i < (length - 1); i++)
            {
                var average = FindAverage(input[i], input[i + 1]);

                if (IsPrime(average))
                {
                    result.Append((char)(average + 1));
                }
                else
                {
                    result.Append((char)average);
                }
            }

            return result.ToString();
        }

        private int FindAverage(int term1, int term2)
        {
            return ((term1 + term2) / 2);
        }

        private bool IsPrime(int number)
        {
            if(number % 2 == 0)
            {
                return false;
            }

            if(_primes.Contains(number))
            {
                return true;
            }

            var sqrt = Math.Sqrt(number);
            for (int i = 2; i < sqrt; i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }

            _primes.Add(number);

            return true;
        }

        static void Main(string[] args)
        {
            Program obj = new Program();

            Console.WriteLine("Enter the string to be processed");
            string input = Console.ReadLine();
            
            string output = obj.ProcessString(input);

            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
