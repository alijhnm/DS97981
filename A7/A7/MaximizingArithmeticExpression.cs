using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximizingArithmeticExpression : Processor
    {
        char ADD = '+';
        char SUB = '-';
        char MUL = '*';
        public MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long DoTheMath(long num1, long num2, char operand)
        {
            if (operand == ADD)
            {
                return num1 + num2;
            }
            else if (operand == SUB)
            {
                return num1 - num2;
            }
            else if (operand == MUL)
            {
                return num1 * num2;
            }
            else
            {
                return 0;
            }
        }

        public long Max(long num1, long num2, long num3, long num4, long num5)
        {
            return Math.Max(Math.Max(Math.Max(num1, num2), Math.Max(num3, num4)), num5);
        }

        public long Min(long num1, long num2, long num3, long num4, long num5)
        {
            return Math.Min(Math.Min(Math.Min(num1, num2), Math.Min(num3, num4)), num5);
        }

        public Tuple<long, long> MinAndMaxFinder(long[,] minValues, long[,] maxValues, int i, int j, List<char> operands)
        {
            long maxValue = long.MinValue, minValue = long.MaxValue;
            
            for (int k  = i; k < j; k++)
            {
                char operand = operands[k];
                long case1 = DoTheMath(maxValues[i, k], maxValues[k + 1, j], operand);
                long case2 = DoTheMath(maxValues[i, k], minValues[k + 1, j], operand);
                long case3 = DoTheMath(minValues[i, k], maxValues[k + 1, j], operand);
                long case4 = DoTheMath(minValues[i, k], minValues[k + 1, j], operand);

                maxValue = Max(maxValue, case1, case2, case3, case4);
                minValue = Min(minValue, case1, case2, case3, case4);

            }
            return Tuple.Create(maxValue, minValue);
        }
        public long Solve(string expression)
        {
            string numbers = "0123456789";
            List<char> operands = new List<char>() { ADD, SUB, MUL };
            
            List<long> expressionNumbers = new List<long>();
            List<char> expressionOperands = new List<char>();

            foreach (char ch in expression)
            {
                if (numbers.Contains(ch))
                {
                    expressionNumbers.Add(int.Parse(ch.ToString()));
                }
                else if (operands.Contains(ch))
                {
                    expressionOperands.Add(ch);
                }
            }

            long[,] minimumValues = new long[expressionNumbers.Count(), expressionNumbers.Count()];
            long[,] maximumValues = new long[expressionNumbers.Count(), expressionNumbers.Count()];

            for (int i = 0; i < expressionNumbers.Count; i++)
            {
                maximumValues[i, i] = expressionNumbers[i];
                minimumValues[i, i] = expressionNumbers[i];
            }
            int j;
            for (int s = 1; s < expressionNumbers.Count(); s++)
            {
                for(int i = 0; i < expressionNumbers.Count - s; i++)
                {
                    j = i + s;
                    Tuple<long, long> minAndMax = MinAndMaxFinder(minimumValues, maximumValues, i, j, expressionOperands);
                    maximumValues[i, j] = minAndMax.Item1;
                    minimumValues[i, j] = minAndMax.Item2;
                }
            }
            return maximumValues[0, expressionNumbers.Count() - 1];
        }
    }
}
