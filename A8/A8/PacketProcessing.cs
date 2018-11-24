using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class PacketProcessing : Processor
    {
        public PacketProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            Queue<long> queue =  new Queue<long>();

            long n = arrivalTimes.Count();
            long[] result = new long[n];

            queue.Enqueue(0);
            long time = 0;

            for (int i = 0; i < n ; i++)
            {
                if (arrivalTimes[i] < time + processingTimes[queue.Peek()])
                {
                    //Processing a packet.
                    if (queue.Count() < bufferSize)
                    {
                        queue.Enqueue(i);
                    }

                    //Dropping a packet.
                    else
                    {
                        result[i] = -1;
                    }
                }
                else
                {

                    long processedPacket = queue.Dequeue();
                    result[processedPacket] = time;

                    if (queue.Count() == 0)
                    {
                        time = Math.Max(time + processingTimes[processedPacket], arrivalTimes[i]);
                    }
                    else
                    {
                        time = Math.Max(time + processingTimes[processedPacket], arrivalTimes[queue.Peek()]);
                    }

                    queue.Enqueue(i);  
                }
            }

            //Processing the remaining packets.
            while (queue.Count() > 0)
            {
                long temp = queue.Dequeue();
                result[temp] = time;

                if (queue.Count() > 0)
                {
                    time = Math.Max(time + processingTimes[temp], arrivalTimes[queue.Peek()]);
                }
            }
            return result;
        }
    }
}
