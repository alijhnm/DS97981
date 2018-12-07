using TestCommon;
using System;
using System.Collections.Generic;


namespace A9
{
    public class ConvertIntoHeap : Processor
    {
        public ConvertIntoHeap(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public static void Swap(long[] array, long firstIndex, long secondIndex)
        {
            long temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        public Tuple<long, long>[] Solve(
            long[] array)
        {
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();

            long lastParrent = array.Length / 2 - 1;
            for (long i = lastParrent; i >= 0; i--)
            {
                long index = i;
                long firstChild = 2 * index + 1;
                while (firstChild < array.Length)
                {
                    long secondChild = -1;
                    if (2 * index + 2 < array.Length)
                    {
                        secondChild = 2 * index + 2;
                    }
                    if (secondChild != -1)
                    {
                        if (array[firstChild] < array[secondChild])
                        {
                            if (array[index] > array[firstChild])
                            {
                                Swap(array, firstChild, index);
                                result.Add(Tuple.Create(index, firstChild));
                                index = firstChild;
                                firstChild = 2 * index + 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (array[index] > array[secondChild])
                            {
                                Swap(array, secondChild, index);
                                result.Add(Tuple.Create(index, secondChild));
                                index = secondChild;
                                firstChild = 2 * secondChild + 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (array[index] > array[firstChild])
                        {
                            Swap(array, firstChild, index);
                            result.Add(Tuple.Create(index, firstChild));
                            index = firstChild;
                            firstChild = 2 * index + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                
            }
            return result.ToArray();
        }
    }

}