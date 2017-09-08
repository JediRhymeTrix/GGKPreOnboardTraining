using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingTwoNumbers
{
    class Adder
    {
        public string Add(string term1, string term2)
        {
            StringBuilder sum = new StringBuilder();
            int carry = 0;
            int len1 = term1.Length;
            int len2 = term2.Length;
            int len = (len1 > len2) ? len1 : len2;

            if (len1 > len2)
            {
                term2 = term2.PadLeft(len1, '0');
            }
            else
            {
                term1 = term1.PadLeft(len2, '0');
            }

            for (int i = len - 1; i >= 0; i--)
            {
                int digitSum = (carry + (int)Char.GetNumericValue(term1[i]) + (int)Char.GetNumericValue(term2[i])) % 10;

                sum.Append(digitSum);

                carry = (carry + (int)Char.GetNumericValue(term1[i]) + (int)Char.GetNumericValue(term2[i])) / 10;
            }

            char[] temp = sum.ToString().ToCharArray();
            Array.Reverse(temp);

            return (new string(temp));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the numbers to be added, separated by a newline: ");
            string sum = new Adder().Add(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine("The sum is: " + sum);
            Console.ReadKey();
        }
    }
}
