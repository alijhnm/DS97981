using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static void PrintList(List<long> l)
        {
            long sum = 0;
            foreach(long i in l)
            {
                Console.WriteLine(i);
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
        public static string Process(string inStr, Func<long, long, long> longProcessor)
        {
            string[] splittedStr = inStr.Split();
            long firstArg = long.Parse(splittedStr[0]);
            long secondArg = long.Parse(splittedStr[1]);
            return longProcessor(firstArg, secondArg).ToString();
        }
        public static string Process(string inStr, Func<long, long> longProcessor)
        {
            long n = long.Parse(inStr);
            return longProcessor(n).ToString();
        }
        public static long Fibonacci(long n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                long firstNumber = 0;
                long secondNumber = 1;
                long result = 1;
                long counter = 2;
                while (counter < n)
                {
                    firstNumber = secondNumber;
                    secondNumber = result;
                    result = firstNumber + secondNumber;
                    counter++;
                }
                return result;
            }
        }
        public static string ProcessFibonacci(string inStr) =>
            Process(inStr, Fibonacci);
        public static long LastDigit(long n)
        {
            if (n > 10)
            {
                return n % 10;
            }
            else
            {
                return n;
            }
        }
        public static long Fibonacci_LastDigit(long n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                long firstNumber = 0;
                long secondNumber = 1;
                long result = 1;
                long counter = 2;
                while (counter < n)
                {
                    firstNumber = secondNumber;
                    secondNumber = result;
                    result = firstNumber + secondNumber;
                    counter++;
                    firstNumber = LastDigit(firstNumber);
                    secondNumber = LastDigit(secondNumber);
                    result = LastDigit(result);
                }
                return result;
            }
        }
        public static string ProcessFibonacci_LastDigit(string inStr) =>
            Process(inStr, Fibonacci_LastDigit);
        public static long GCD(long firstNumber, long secondNumber)
        {
            if (firstNumber == 0)
                return secondNumber;

            return GCD(secondNumber % firstNumber, firstNumber);
        }
        public static string ProcessGCD(string inStr) =>
            Process(inStr, GCD);
        public static long LCM(long firstNumber, long secondNumber)
        {
            long gcd = GCD(firstNumber, secondNumber);
            return firstNumber * secondNumber / gcd;
        }
        public static string ProcessLCM(string inStr) =>
            Process(inStr, LCM);
        public static long Fibonacci_Mod(long n, long m)
        {
            long length = 3;
            List<long> remainders = new List<long>() { 0 };
            long firstNumber = 0;
            long secondNumber = 1;
            long temp = 1;
            for (int i = 2; i < int.MaxValue; i++)
            {
                temp = secondNumber % m;
                secondNumber = (firstNumber % m + temp) % m;
                firstNumber = temp;
                if (firstNumber == 0 && secondNumber == 1)
                {
                    length = i - 1;
                    break;
                }
                else
                {
                    remainders.Add(firstNumber);
                }
            }
      
            return remainders[(int)(n % length)];
        }
        public static string ProcessFibonacci_Mod(string inStr) =>
            Process(inStr, Fibonacci_Mod);
        public static long Fibonacci_Sum(long n)
        {
            List<long> remainders = new List<long>() { 0 };
            long firstNumber = 0;
            long secondNumber = 1;
            long temp = 1;
            for (int i = 2; i < 10000; i++)
            {
                temp = secondNumber % 10;
                secondNumber = (firstNumber % 10 + temp) % 10;
                firstNumber = temp;
                if (firstNumber == 0 && secondNumber == 1)
                {
                    break;
                }
                else
                {
                    remainders.Add(firstNumber);
                }
            }
            remainders.RemoveAt(0);
            long listSum = remainders.Sum() % 10;
            Console.WriteLine(remainders.Count);
            Console.WriteLine(listSum);
            long R = n % (remainders.Count + 1);
            Console.WriteLine(R);
            long numberOfPeriods = n / 10;
            return (numberOfPeriods * listSum + remainders.Take((int) R).Sum()) % 10;
        }
        public static string ProcessFibonacci_Sum(string inStr) =>
            Process(inStr, Fibonacci_Sum);
        public static long Fibonacci_Partial_Sum(long n, long m)
        {
            long Big, Small;

            if (n >= m)
            {
                Big = n;
                Small = m;
            }
            else
            {
                Big = m;
                Small = n;
            }            
            long result = Fibonacci_Sum(Big) - Fibonacci_Sum(Small - 1);
            result = result < 0 ? 10 + result : result;
            return result%10;
        }
        public static string ProcessFibonacci_Partial_Sum(string inStr) =>
            Process(inStr, Fibonacci_Partial_Sum);
        public static long Fibonacci_Sum_Squares(long n)
        {
            long fibN = Fibonacci_Mod(n, 10);
            long fibN_1 = Fibonacci_Mod(n - 1, 10);
            return ((fibN + fibN_1) * fibN) % 10;
        }
        public static string ProcessFibonacci_Sum_Squares(string inStr) =>
            Process(inStr, Fibonacci_Sum_Squares);
    }
}
