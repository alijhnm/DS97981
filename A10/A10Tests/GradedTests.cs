using Microsoft.VisualStudio.TestTools.UnitTesting;
using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A10.Tests
{
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(10000)]
        [DeploymentItem("TestData", "A10_TestData")]
        public void SolveTest()
        {
            Processor[] problems = new Processor[] {
                new PhoneBook("TD1"),
                new HashingWithChain("TD2"),
                new RabinKarp("TD3")
            };

            foreach (var p in problems)
            {
                TestTools.RunLocalTest("A10", p.Process, p.TestDataName);
            }
        }
    }
}