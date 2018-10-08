using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void Graded_FibonacciTest()
        {
            TestTools.RunLocalTest("A3", Program.ProcessFibonacci, "TD1");
        }

        [TestMethod()]
        public void Fibonacci_LastDigitTest()
        {
            TestTools.RunLocalTest("A3", Program.ProcessFibonacci_LastDigit, "TD2");
        }
        [TestMethod()]
        public void Graded_GCDTest()
        {
            TestTools.RunLocalTest("A3", Program.ProcessGCD, "TD3");
        }

        [TestMethod()]
        public void Graded_LCMTest()
        {
            TestTools.RunLocalTest("A3", Program.ProcessLCM, "TD4");
        }
        [TestMethod()]

        public void ProcessFibonacci_ModTest()
        {
            TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Mod, "TD5");
        }

        [TestMethod()]
        public void ProcessFibonacci_SumTest()
        {
            TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Sum, "TD6");
        }

        [TestMethod()]
        public void ProcessFibonacciPartialSumTest()
        {
            TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Partial_Sum, "TD7");
        }

        [TestMethod()]
        public void Graded_FibonacciSumSquaresTest()
        {
            TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Sum_Squares, "TD8");
        }

    }
}