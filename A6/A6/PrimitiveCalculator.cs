using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class PrimitiveCalculator: Processor
    {
        public PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);
        
        public long[] Solve(long n)
        {
            List<Tuple<long, long>> sequences = new List<Tuple<long, long>>() {
                Tuple.Create((long)0, (long)0),
                Tuple.Create((long)0, (long)1),
                Tuple.Create((long)2, (long)1),
                Tuple.Create((long)2, (long)1)};

            for (int i = 4; i <= n; i++)
            {
                Tuple<long, long> sequence = Tuple.Create(long.MaxValue, long.MaxValue);
                if ((i % 3) == 0)
                {
                    if (sequences[i / 3].Item1 + 1 < sequence.Item1)
                    {
                        sequence = Tuple.Create(sequences[i / 3].Item1 + 1, (long)i / 3);
                    }
                }

                if ((i % 2) == 0)
                {
                    if (sequences[i / 2].Item1 + 1 < sequence.Item1)
                    {
                        sequence = Tuple.Create(sequences[i / 2].Item1 + 1, (long)i / 2);
                    }
                }

                if (sequences[i - 1].Item1 + 1 < sequence.Item1)
                {
                    sequence = Tuple.Create(sequences[i - 1].Item1 + 1, (long)i - 1);
                }
                sequences.Add(sequence);
            }

            List<long> result = new List<long>() { n };

            long counter = n;
            while (counter > 1)
            {               
                counter = sequences[(int) counter].Item2;
                result.Add(counter);
            }
            result.Reverse();
            
            return result.ToArray();
        }
        
    }
}
