using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        [DeploymentItem("TestData", "A0_TestData")]
        public void GradedTest_Correctness()
        {
            TestCommon.TestTools.RunLocalTest("A0", Program.Process);
        }
        [TestMethod(), Timeout(500)]
        [DeploymentItem("TestData", "A0_TestData")]
        public void GradedTest_Performance()
        {
            TestCommon.TestTools.RunLocalTest("A0", Program.Process);
        }
        [TestMethod()]
        public void GradedTest_Stress()
        {
            int maximumListSize = 10;
            int M = 10;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 5000)
            {
                Random randomGenerator = new Random();
                int listSize = randomGenerator.Next(2, maximumListSize);
                List<int> list = new List<int>();
                for (int i = 0; i < listSize; i++)
                {
                    list.Add(randomGenerator.Next(0, M));
                }
                int naiveResult = Program.NaiveMaxPairwiseProduct(list);
                int fastResult = Program.FastMaxPairwiseProduct(list);
                if (naiveResult == fastResult)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("Wrong answer: ", naiveResult.ToString(), fastResult.ToString());
                }
            }
        }
    }
}