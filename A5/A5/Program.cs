using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static long BisectionSearch(long[] array,long n)
        {
            long min = 0;
            long max = array.Length - 1;

            while (min <= max)
            {
                long mid = (min + max) / 2;

                if (n == array[mid])
                {
                    return mid;
                }
                else if (n < array[mid])
                {
                    max = mid - 1;
                }
                else
                    min = mid + 1;
            }

            return -1;
        }
        public static long[] BinarySearch1(long[] a, long[] b)
        {
            long[] result = new long[b.Length];

            for (long index = 0; index < b.Length; index++)
            {
                result[index] = BisectionSearch(a, b[index]);
            }

            return result;
        }
        public static string ProcessBinarySearch1(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[]>)BinarySearch1);

        public static long[] ExclusiveSlice(long[] array, long start, long end)
        {

            long[] result = new long[end - start - 1];

            for (long i = start + 1; i < end; i++)
            {
                result[i - start - 1] = array[i];
            }

            return result;
        }
        public static long MajorityElement2(long n, long[] a)
        {
            a = a.OrderBy(x => x).ToArray();

            long mid = (a.Length - 1) / 2;
            long majorityElement = a[(int)mid];

            long leftDownBoundry = -1;
            long leftUpBoundry = mid;

            long rightDownBoundry = mid;
            long rightUpBoundry = a.Length;

            long[] leftArray = ExclusiveSlice(a, leftDownBoundry, leftUpBoundry);
            long[] rightArray = ExclusiveSlice(a, rightDownBoundry, rightUpBoundry);

            long leftMid = (leftDownBoundry + leftUpBoundry) / 2;
            long rightMid = (rightDownBoundry + rightUpBoundry) / 2;

            while (leftArray.Length > 0 && rightArray.Length > 0)
            {
                
                if (a[leftMid] != majorityElement && a[rightMid] != majorityElement)
                {
                    return 0;
                }

                else if (a[leftMid] != majorityElement && a[rightMid] == majorityElement)
                {
                    leftDownBoundry = leftMid;
                    leftMid = (leftDownBoundry + leftUpBoundry) / 2;
                    leftArray = ExclusiveSlice(a, leftDownBoundry, leftUpBoundry);

                    rightDownBoundry = rightMid;
                    rightMid = (rightDownBoundry + rightUpBoundry) / 2;
                    rightArray = ExclusiveSlice(a, rightDownBoundry, rightUpBoundry);
                }
                else if (a[leftMid] == majorityElement && a[rightMid] != majorityElement)
                {
                    leftUpBoundry = leftMid;
                    leftMid = (leftDownBoundry + leftUpBoundry) / 2;
                    leftArray = ExclusiveSlice(a, leftDownBoundry, leftUpBoundry);

                    rightUpBoundry = rightMid;
                    rightMid = (rightDownBoundry + rightUpBoundry) / 2;
                    rightArray = ExclusiveSlice(a, rightDownBoundry, rightUpBoundry);
                }
                else
                {
                    return 1;
                }
            }
            //number of majority elements is exactly [n/2]; so the answer is based on array's length:
            if(a.Length % 2 == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static string ProcessMajorityElement2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>) MajorityElement2);

        public static void Swap(long[] list, long index1, long index2)
        {
            long temp = list[(int)index1];
            list[(int)index1] = list[(int)index2];
            list[(int)index2] = temp;
        }
        public static void Quicksort(long[] list, long left, long right)
        {
            long leftReference = left;
            long rightReference = right;
            long pivot = list[(int)(left + right) / 2];

            while (leftReference <= rightReference)
            {
                while (list[(int)leftReference] < pivot)
                {
                    leftReference++;
                }
                while (list[(int)rightReference] > pivot)
                {
                    rightReference--;
                }

                if (leftReference <= rightReference)
                {
                    Swap(list, leftReference, rightReference);
                    leftReference++;
                    rightReference--;
                }
            }
            if (left < rightReference)
            {
                Quicksort(list, left, rightReference);
            }

            if (leftReference < right)
            {
                Quicksort(list, leftReference, right);
            }
        }
        public static long[] ImprovingQuickSort3(long n, long[] a)
        {
            Quicksort(a, 0, n - 1);
            return a;
        }
        public static string ProcessImprovingQuickSort3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)ImprovingQuickSort3);

        public static Tuple<List<long>, long> SortAndCount(List<long> numbers, long numberOfInversions)
        {
            List<long> result = new List<long>();
            if (numbers.Count() > 1)
            {
                List<long> right = new List<long>();
                List<long> left = new List<long>();
                int mid = numbers.Count() / 2;

                for (int i = 0; i < mid; i++)
                {
                    left.Add(numbers[i]);
                }

                for (int i = mid; i < numbers.Count(); i++)
                {
                    right.Add(numbers[i]);
                }
                Tuple<List<long>, long> leftTuple = SortAndCount(left, numberOfInversions);
                left = leftTuple.Item1;
                //update number of inversions
                numberOfInversions = leftTuple.Item2;
                
                Tuple<List<long>, long> rightTuple = SortAndCount(right, numberOfInversions);
                right = rightTuple.Item1;
                //update number of inversions
                numberOfInversions = rightTuple.Item2;
                
                int leftIndex = 0;
                int rightIndex = 0;

                while (leftIndex < left.Count && rightIndex < right.Count)
                {
                    if (left[leftIndex] > right[rightIndex])
                    {
                        result.Add(right[rightIndex]);
                        rightIndex++;
                        numberOfInversions += left.Count() - leftIndex;
                    }
                    else
                    {
                        result.Add(left[leftIndex]);
                        leftIndex++;
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

            return Tuple.Create(result, numberOfInversions);
        }
        public static long NumberofInversions4(long n, long[] a)
        {
            List<long> aList = a.ToList();
            Tuple<List<long>, long> tuple = SortAndCount(aList, 0);
            return tuple.Item2;
        }
        public static string ProcessNumberofInversions4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)NumberofInversions4);
    
        public static long[] OrganizingLottery5(long[] points, long[] startSegments, long[] endSegment)
        {
            List<Tuple<long, long, long>> allPoints = new List<Tuple<long, long, long>>();
            long[] result = new long[points.Length];

            long START = 1;
            long POINT = 2;
            long END   = 3;
            long NA = -1;

            for (long i = 0; i < startSegments.Length; i++)
            {
                allPoints.Add(Tuple.Create(startSegments[i], START, NA));
            }

            for (long i = 0; i < points.Length; i++)
            {
                allPoints.Add(Tuple.Create(points[i], POINT, i));
            }
            
            for (long i = 0; i < endSegment.Length; i++)
            {
                allPoints.Add(Tuple.Create(endSegment[i], END, NA));
            }
            //sort points
            allPoints = allPoints.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();

            List<long> pointsList = points.ToList();
            Tuple<long, long, long> point;

            long counter = 0;
            long length = allPoints.Count;

            for (long pointIndex = 0; pointIndex < length; pointIndex++)
            {
                point = allPoints[(int)pointIndex];
                if (point.Item2 == START)
                {
                    counter++;
                }
                else if (point.Item2 == POINT)
                {
                    result[point.Item3] = counter;
                }
                else if (point.Item2 == END)
                {
                    counter--;
                }
            }
            return result;
        }
        public static string ProcessOrganizingLottery5(string inStr) =>
            TestTools.Process(inStr, (Func<long[] ,long[], long[], long[]>)OrganizingLottery5);
        
        public static double Distance(Tuple<long, long> point1, Tuple<long, long> point2)
        {
            return Math.Pow(Math.Pow(point1.Item1 - point2.Item1, 2) + Math.Pow(point1.Item2 - point2.Item2, 2), 0.5);
        }
        public static double BruteForceDistance(List<Tuple<long, long>> points)
        {
            double minDistance = double.MaxValue;
            for (int i = 0; i < points.Count(); i++)
            {
                for (int j = i + 1; j < points.Count(); j++)
                {
                    double dis = Distance(points[i], points[j]);
                    if (dis < minDistance)
                    {
                        minDistance = dis;
                    }
                }
            }
            return minDistance;
        }
        public static double ClosestPoint(List<Tuple<long, long>> points)
        {
            long length = points.Count();
            if (length > 3)
            {
                long mid = (length - 1) / 2;
                List<Tuple<long, long>> leftPoints = new List<Tuple<long, long>>();
                List<Tuple<long, long>> rightPoints = new List<Tuple<long, long>>();

                for (int i = 0; i < mid + 1; i++)
                {
                    leftPoints.Add(points[i]);
                }

                for (long i = mid + 1; i < length; i++)
                {
                    rightPoints.Add(points[(int) i]);
                }

                double leftMinDistance = ClosestPoint(leftPoints);
                double rightMinDistance = ClosestPoint(rightPoints);

                double minLeftAndRight = Math.Min(leftMinDistance, rightMinDistance);
                List<Tuple<long, long>> borderPoints = new List<Tuple<long, long>>();
                long midX = points[(int) mid].Item1;

                for (int i = 0; i < length; i++)
                {
                    if (Math.Abs(points[i].Item1 - midX) < minLeftAndRight)
                    {
                        borderPoints.Add(points[i]);
                    }
                }

                double minBorderDistance = BruteForceDistance(borderPoints);
                return Math.Min(minLeftAndRight, minBorderDistance);
            }
            else
            {
                return BruteForceDistance(points);
            }
        }
        public static double ClosestPoints6(long n, long[] xPoints, long[] yPoints)
        {
            List<Tuple<long, long>> points = new List<Tuple<long, long>>();
            for (int index = 0; index < n; index++)
            {
                points.Add(Tuple.Create(xPoints[index], yPoints[index]));
            }
            points = points.OrderBy(x => x.Item1).ToList();

            double result = ClosestPoint(points);
            return Math.Round(result, 4);
        }
        public static string ProcessClosestPoints6(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[], long[], double>)
               ClosestPoints6);

    }
}
