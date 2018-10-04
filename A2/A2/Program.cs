using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static string Process(String input)
        {
            var inData = input.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();

            return FastMaxPairwiseProduct(inData).ToString();

        }
        public static int NaiveMaxPairwiseProduct(List<int> list)
        {
            int result = 0;
            for (int index1 = 0; index1 < list.Count; index1++)
            {
                for (int index2 = index1 + 1; index2 < list.Count; index2++)
                {
                    if (list[index1] * list[index2] > result)
                    {
                        result = list[index1] * list[index2];
                    }
                }
            }
            return result;
        }
        public static int FastMaxPairwiseProduct(List<int> list)
        {
            int firstIndex = 0;
            for (int index = 0; index < list.Count; index++)
            {
                if (list[index] > list[firstIndex])
                {
                    firstIndex = index;
                }
            }
            int secondIndex;
            if (firstIndex == 0) {
                secondIndex = 1;
            }
            else
            {
                secondIndex = 0;
            }
            

            for(int index = 0; index < list.Count; index++)
            {
                if (index != firstIndex && list[index] > list[secondIndex])
                {
                    secondIndex = index;
                }
            }
            return list[firstIndex] * list[secondIndex];
        }
    }
}
