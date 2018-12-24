using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace E2
{
    public class Q3BloomFilter
    {
        BitArray Filter;
        Func<string, long>[] HashFunctions;

        //long[] BigPrimeNumbers = new long[] { 232368, 4234612, 98245671, 3961230 };
        //long[] ChosenXs = new long[] { 612143, 14575, 23498, 99876 };

        public Q3BloomFilter(int filterSize, int hashFnCount)
        {
            
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, long>[hashFnCount];
            Random rnd = new Random(0);
            List<int> randomList = new List<int>();
            for (int i = 0; i < hashFnCount; i++)
            {
                randomList.Add(rnd.Next());
            }
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                int x = randomList[i];
                Func<string, long> func = str => MyHashFunction(str, x, filterSize);
                HashFunctions[i] = func;
            }
        }

        public static long NewHash(string str, long num1, long num2, long filterSize)
        {
            long result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int asciiCode = str.ElementAt(i);
                result += (long) Math.Pow((asciiCode * num1), num2);
                if (result < 0)
                {
                    result = -result;
                }
            }
            return result % filterSize ;
        }

        public static long ToThePowerOf(long number, long power, long p)
        {
            long result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
                result %= p;
            }
            return result;
        }

        public static long PolyHash(
            string str, long m, long p, long x)
        {
            long hash = 0;
            for (int i = 0; i < str.Length; i++)
            {
                hash += str[i] * ToThePowerOf(x, i, p) % p;
                hash %= p;
            }
            return hash % m;
        }

        public int MyHashFunction(string str, int num, int filterSize)
        {
            int result = 0;
            long BigPrimeNumber = 1000000007;
            long ChosenX = num;

                long hash = 0;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    hash = (hash * ChosenX + (int)(str[i])) % BigPrimeNumber;
                }
                result = (int)(hash % filterSize);
           
            return result;
        }

        public void Add(string str)
        {
            
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                int index = (int) HashFunctions[i](str);
                Filter[index] = true;
            }
        }

        public bool Test(string str)
        {
            
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                int hashResult = (int)HashFunctions[i](str);
                if (!Filter[hashResult])
                {
                    return false;
                }
            }
            return true;
        }
    }
}