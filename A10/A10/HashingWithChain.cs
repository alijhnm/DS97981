using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class HashingWithChain : Processor
    {
        public HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        protected List<List<string>> hashTable;

        public string[] Solve(long bucketCount, string[] commands)
        {
            hashTable = new List<List<string>>((int)bucketCount);
            for (int i = 0; i < hashTable.Capacity; i++)
            {
                hashTable.Add(new List<string>());
            }
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];
                
                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start , int count, long m = BigPrimeNumber, long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = start; i < start + count; i++)
            {
                hash += str[i] * ToThePowerOf(x, (i - start)) % p;
                hash %= p;
            }
            return hash % m;
        }

        public static long ToThePowerOf(long number, long power, long p = BigPrimeNumber)
        {
            long result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
                result %= p;
            }
            return result;
        }

        public void Add(string str)
        {
            int index = (int)PolyHash(str, 0, str.Length, hashTable.Capacity);
            for (int i = 0; i < hashTable[index].Count; i++)
            {
                if (hashTable[index][i] == str)
                    return;
            }
            hashTable[index].Add(str);
        }

        public string Find(string str)
        {
            int index = (int) PolyHash(str, 0, str.Length, hashTable.Capacity);
            for (int i = 0; i < hashTable[index].Count; i++)
            {
                if (hashTable[index][i] == str)
                    return "yes";
            }
            return "no";
        }

        public void Delete(string str)
        {
            int index = (int) PolyHash(str, 0, str.Length, hashTable.Capacity);

            for (int i = 0; i < hashTable[index].Count; i++)
            {
                if (hashTable[index][i] == str)
                {
                    hashTable[index].RemoveAt(i);
                }
            }
        }

        public string Check(int i)
        {
            List<string> tempHastTable = hashTable[i];
            tempHastTable.Reverse();
            if (tempHastTable.Count == 0)
            {
                return "-";
            }
            else
            {
                return string.Join(" ", tempHastTable);
            }
        }
    }
}
