using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class HitTests
    {
        private Hit hit;

        [TestInitialize]
        public void Initialize()
        {
            hit = new Hit(5, 4, true);
        }

        [TestMethod]
        public void HitAgainstArmor()
        {
            Assert.AreEqual(5, hit.AgainstArmor);
        }

        [TestMethod]
        public void HitAgainstHitPoints()
        {
            Assert.AreEqual(4, hit.AgainstHitPoints);
        }

        public void HitIsCritical()
        {
            Assert.IsTrue(hit.IsCritical);
        }
    }
}
