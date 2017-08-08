using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonkeysOnARope;

namespace MonkeysOnARopeTests
{
    [TestClass]
    public class RopeTests
    {
        [TestMethod]
        public void RopeInitializesDefault3Cap()
        {
            Rope r = new Rope();

            Assert.AreEqual(3, r.MaxCapacity);
        }

        [TestMethod]
        public void RopeCapSetInConstructor()
        {
            Rope r = new Rope(4);
            Assert.AreEqual(4, r.MaxCapacity);
        }

        [TestMethod]
        public void RopeDirectionSetByTraveler()
        {
            Rope r = new Rope();
            r.Travelers.Add(new Monkey("Jim", World.Side.Left));

            Assert.AreEqual(World.Side.Left, r.CurrentDirection);
        }
    }
}
