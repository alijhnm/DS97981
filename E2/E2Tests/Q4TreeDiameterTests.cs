using Microsoft.VisualStudio.TestTools.UnitTesting;
using E2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Tests
{
    [TestClass()]
    public class Q4TreeDiameterTests
    {
        [TestMethod()]
        public void Q4TreeDiameterTest()
        {
            //Assert.Inconclusive();
            Q4TreeDiameter td = new Q4TreeDiameter(10, 0);
            Assert.AreEqual(td.TreeHeight(), 4);
        }

        [TestMethod()]
        public void TreeHeightTest()
        {
            Q4TreeDiameter td = new Q4TreeDiameter(10, 0);
            Q4TreeDiameter td2 = new Q4TreeDiameter(15, 0);
            Assert.AreEqual(td.TreeHeight(), 4);
            Assert.AreEqual(td2.TreeHeight(), 4);
        }

        [TestMethod()]
        public void TreeHeightFromNodeTest()
        {
            Assert.Inconclusive();
            //Q4TreeDiameter td = new Q4TreeDiameter(10, 0);
            Q4TreeDiameter td2 = new Q4TreeDiameter(15, 0);
            //Assert.AreEqual(td.TreeHeightFromNode(5), 4);
            Assert.AreEqual(td2.TreeHeightFromNode(5), 6);
        }

        [TestMethod()]
        public void TreeDiameterN2Test()
        {
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void TreeDiameterNTest()
        {
            Assert.Inconclusive();
        }
    }
}