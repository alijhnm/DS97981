using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A4
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
        public static long ChangingMoney1(long money)
        {
            
            long numberOf10Coins = money / 10;
            long numberOf5Coins = (money % 10) / 5;
            long numberOf1Coins = money % 5;
            return numberOf10Coins + numberOf5Coins + numberOf1Coins;
        }
        public static string ProcessChangingMoney1(string inStr)
            => TestTools.Process(inStr, (Func<long, long>) ChangingMoney1);
        public static long MaximizingLoot2(
            long capacity, long[] weights, long[] values)
        {
            double result = 0;
            long remainingCapacity = capacity;
            
            List<double> Densities = new List<double>();
            Dictionary<double, int> densityOfIndicis = new Dictionary<double, int>();

            for (int index = 0; index < weights.Length; index++)
            {
                double density = (double) values[index] / (double) weights[index];
                Densities.Add(density);
                densityOfIndicis[density] = index;
            }
            
            Densities.Sort();
            Densities.Reverse();

            while (remainingCapacity > 0)
            {
                int nextItemToAdd = densityOfIndicis[Densities[0]];
                Densities.RemoveAt(0);
                if (remainingCapacity >= weights[nextItemToAdd])
                {
                    result += (double) values[nextItemToAdd];
                    remainingCapacity -= weights[nextItemToAdd];
                }
                else
                {
                    result += (double)remainingCapacity / (double) weights[nextItemToAdd] * (double) values[nextItemToAdd];
                    break;   
                }    
            }
            return (long) result;
        }
        public static string ProcessMaximizingLoot2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingLoot2);
        public static long MaximizingOnlineAdRevenue3(long slotCount, 
            long[] adRevenue, long[] averageDailyClick)
        {
            List<long> adRevenueList = adRevenue.OrderByDescending(x => x).ToList();
            List<long> averageDailyClickList = averageDailyClick.OrderByDescending(x => x).ToList();
            List<long> revunueMultipliedByClicks = new List<long>();
    
            for (int index = 0; index < adRevenueList.Count; index++)
            {
                revunueMultipliedByClicks.Add(adRevenueList[index] * averageDailyClickList[index]);
            }
            return revunueMultipliedByClicks.Sum();
        }
        public static string ProcessMaximizingOnlineAdRevenue3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingOnlineAdRevenue3);
        public static long CollectingSignatures4(long tenantCount,
            long[] startTimes, long[] endTimes)
        {
            List<Tuple<long, long>> partitions = new List<Tuple<long, long>>();
            for (int index = 0; index < tenantCount; index++)
            {
                Tuple<long, long> t = Tuple.Create(startTimes[index], endTimes[index]);
                partitions.Add(t);
            }
            for (int i = 0; i < partitions.Count(); i++)
            {
                for (int j = i + 1; j < partitions.Count(); j++)
                {
                    if (partitions[i].Item1 >= partitions[j].Item1 && partitions[i].Item2 <= partitions[j].Item2)
                    {
                        partitions.RemoveAt(j);
                    }
                }
            }
            Console.WriteLine("Partitions.Count() after deleting : " + partitions.Count());
            partitions = partitions.OrderBy(x => x.Item1).ToList();
            Console.WriteLine(partitions[0].Item1 + "," + partitions[0].Item2);
            Tuple<long, long> partition = partitions[0];

            long result = 1;

            for(int index = 1; index < partitions.Count(); index++)
            {
                Tuple<long, long> nextPartition = partitions[index];
                if (nextPartition.Item1 == partition.Item1)
                {
                    if (nextPartition.Item2 < partition.Item2)
                    {
                        partition = nextPartition;
                        Console.WriteLine("smaller partition found : (" + partition.Item1 + ", " + partition.Item2 + ")");
                    }
                }
                else
                {
                    if (nextPartition.Item1 > partition.Item2)
                    {
                        partition = nextPartition;
                        result++;

                    }
                }
            }
            return result;
        }    
        public static string ProcessCollectingSignatures4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) CollectingSignatures4);
        public static long[] MaximizeNumberOfPrizePlaces5(long n)
        {
            long remainingCandies = n;
            List<long> candyPrizes = new List<long>();
            for (long i = 1; remainingCandies >= 0; i++)
            {
                if (remainingCandies - i >= 0)
                {
                    candyPrizes.Add(i);
                    remainingCandies -= i;
                }
                else
                {
                    candyPrizes[candyPrizes.Count - 1] += remainingCandies;
                    break;
                }
            }
            return candyPrizes.ToArray();
        }
        public static string ProcessMaximizeNumberOfPrizePlaces5(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)MaximizeNumberOfPrizePlaces5);
        public static List<long> sortedNumbers(List<long> numbers)
        {
            List<long> result = new List<long>();
            if (numbers.Count() > 1)
            {
                List<long> right = new List<long>();
                List<long> left = new List<long>();
                int mid = numbers.Count() / 2;

                int leftIndex;
                for (leftIndex = 0; leftIndex < mid; ++leftIndex)
                {
                    left.Add(numbers[leftIndex]);
                }

                for (leftIndex = mid; leftIndex < numbers.Count(); ++leftIndex)
                {
                    right.Add(numbers[leftIndex]);
                }

                left = sortedNumbers(left);
                right = sortedNumbers(right);
                leftIndex = 0;
                int rightIndex = 0;

                while (leftIndex < left.Count && rightIndex < right.Count)
                {
                    long case1 = int.Parse(left[leftIndex].ToString() + right[rightIndex].ToString());
                    long case2 = int.Parse(right[rightIndex].ToString() + left[leftIndex].ToString());
                    if (case1 > case2)
                    {
                        result.Add(left[leftIndex]);
                        ++leftIndex;
                    }
                    else
                    {
                        result.Add(right[rightIndex]);
                        ++rightIndex;
                    }
                }

                while (leftIndex < left.Count)
                {
                    result.Add(left[leftIndex]);
                    ++leftIndex;
                }

                while (rightIndex < right.Count)
                {
                    result.Add(right[rightIndex]);
                    ++rightIndex;
                }
            }
            else
            {
                result = numbers;
            }
            return result;
        }
        public static string MaximizeSalary6(long n, long[] numbers)
        {
            List<long> numbersList = numbers.ToList();
            numbersList = sortedNumbers(numbersList);
            string result = "";
            for (int index = 0; index < numbersList.Count(); index++)
            {
                result += numbersList[index];
            }
            return result;
        }
        public static string ProcessMaximizeSalary6(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) MaximizeSalary6);
        }
}
