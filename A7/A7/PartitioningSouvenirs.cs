using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class PartitioningSouvenirs : Processor
    {
        public PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public static bool subsetSum(long[] items, long indexOfNextItem, long partition1Capacity, long partition2Capacity, long partition3Capacity)
        {
            if (partition1Capacity == 0 && partition2Capacity == 0 && partition3Capacity == 0)
            {
                return true;
            }

            if (indexOfNextItem < 0)
            {
                return false;
            }

            bool canFindSubset1 = false;
            if (partition1Capacity - items[indexOfNextItem] >= 0)
            {
                canFindSubset1 = subsetSum(items, indexOfNextItem - 1, partition1Capacity - items[indexOfNextItem], partition2Capacity, partition3Capacity);
            }

            bool canFindSubset2 = false;
            if (!canFindSubset1 && (partition2Capacity - items[indexOfNextItem] >= 0))
            {
                canFindSubset2 = subsetSum(items, indexOfNextItem - 1, partition1Capacity, partition2Capacity - items[indexOfNextItem], partition3Capacity);
            }

            bool canFindSubset3 = false;
            if ((!canFindSubset1 && !canFindSubset2) && (partition3Capacity - items[indexOfNextItem] >= 0))
            {
                canFindSubset3 = subsetSum(items, indexOfNextItem - 1, partition1Capacity, partition2Capacity, partition3Capacity - items[indexOfNextItem]);
            }

            return canFindSubset1 || canFindSubset2 || canFindSubset3;
        }

        public static bool partition(long[] items)
        {
            if (items.Length < 3)
            {
                return false;
            }
            long sum = items.ToList().Sum();
            return (sum % 3) == 0 && subsetSum(items, items.Length - 1, sum / 3, sum / 3, sum / 3);
        }

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long sum = souvenirs.ToList().Sum();
            if (partition(souvenirs))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
