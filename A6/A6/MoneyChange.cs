using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public  static Dictionary<long, long> ValueDictionary = new Dictionary<long, long>
            {
                { 1, 1 },
                { 2, 2 },
                { 3, 1 },
                { 4, 1 }
            };
        
        public long Solve(long n)
        {
            if (ValueDictionary.Keys.Contains(n))
            {
                return ValueDictionary[n];
            }
            else
            {
                long result = Math.Min(Math.Min(Solve(n - 1), Solve(n - 3)), Solve(n - 4));
                ValueDictionary.Add(n, result + 1);
                return result + 1;
            }
        }
    }
}
