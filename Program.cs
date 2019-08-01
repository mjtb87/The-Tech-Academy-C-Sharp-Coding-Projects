using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseString("TheTestString");
            Console.WriteLine(RemoveDuplicates("iuiuiuigggbbmgg"));
            FizzBuzz();

            int[] numbersOne = new int[10];
            numbersOne[0] = 12;
            numbersOne[1] = 9;
            numbersOne[2] = 1;
            numbersOne[3] = 2;
            numbersOne[4] = 552;
            numbersOne[5] = 67;
            numbersOne[6] = 33;
            numbersOne[7] = 11;
            numbersOne[8] = 8;
            numbersOne[9] = 56;

            int resultOne = 0;

            foreach (int i in numbersOne)
            {
                if (i % 2 == 0)
                {
                    resultOne += i;
                }
            }

            Console.WriteLine("Sum of even numbers in the first list: " + resultOne);

            Console.WriteLine(" ");
            ulong[] numbersTwo = new ulong[10];
            numbersTwo[0] = 645634;
            numbersTwo[1] = 567776;
            numbersTwo[2] = 645646;
            numbersTwo[3] = 456456;
            numbersTwo[4] = 6456;
            numbersTwo[5] = 434566;
            numbersTwo[6] = 356436;
            numbersTwo[7] = 54756716;
            numbersTwo[8] = 76456786;
            numbersTwo[9] = 4567676;

            ulong resultTwo = 0;
            foreach (ulong i in numbersTwo)
            {
                if (i % 2 == 0)
                {
                    resultTwo += i;
                }
            }

            Console.WriteLine("Sum of even numbers in the second list: " + resultTwo);

            Console.ReadKey();
        }

        static void ReverseString(string input)
        {
            String result = "";
            foreach (char c in input)
            {
                result = result.Insert(0, c.ToString());
            }
            Console.WriteLine(result);
        }

        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }

        static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                String output = "";

                if (i % 3 == 0) { output += "Fizz"; }
                if (i % 5 == 0) { output += "Buzz"; }
                if (output == "") { output += i; }
                Console.WriteLine(output);
            }
        }
    }
}
