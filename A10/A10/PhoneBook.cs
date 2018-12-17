using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Contact
    {
        public string Name;
        public long Number;

        public Contact(string name, long number)
        {
            Name = name;
            Number = number;
        }
    }

    public class PhoneBook : Processor
    {
        public PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        protected List<List<Contact>> hashTable;

        public long CARDINALITY = 1000;

        public string[] Solve(string [] commands)
        {
            hashTable = new List<List<Contact>>((int) CARDINALITY);
            for (int i = 0; i < hashTable.Capacity; i++)
            {
                hashTable.Add(new List<Contact>());
            }
            List<string> result = new List<string>();
            foreach(var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(Find(number));
                        break;
                }
            }
            return result.ToArray();
        }

        public long HashFunction(long n)
        {
            int a = 34, b = 3, bigPrimeNumber = 10000019;
            return ((a * n + b) % bigPrimeNumber) % CARDINALITY;
        }

        public void Add(string name, long number)
        {
            long index = HashFunction(number);
            for(int i=0; i<hashTable[(int)index].Count; i++)
            {
                if (hashTable[(int)index][i].Number == number)
                {
                    hashTable[(int)index][i].Name = name;
                    return;
                }
            }
            hashTable[(int)index].Add(new Contact(name, number));
        }

        public string Find(int number)
        {
            long index = HashFunction(number);
            for (int i = 0; i < hashTable[(int)index].Count; i++)
            {
                if (hashTable[(int)index][i].Number == number)
                    return hashTable[(int)index][i].Name;             
            }
            return "not found";
        }

        public void Delete(long number)
        {
            long index = HashFunction(number);
            for (int i = 0; i < hashTable[(int)index].Count; i++)
            {
                if (hashTable[(int)index][i].Number == number)
                {
                    hashTable[(int)index].RemoveAt(i);
                    return;
                }
            }
        }
    }
}
