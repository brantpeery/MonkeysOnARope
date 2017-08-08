using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonkeysOnARope;

namespace MonkeysOnARopeTests
{
    [TestClass]
    public class MonkeyTests
    {
        [TestMethod]
        public void OneIsOne()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void LoadAMonkeyNamedJim()
        {
            Monkey Jim = new Monkey("Jim", World.Side.Left);
            Assert.AreEqual("Jim", Jim.ID);
            Assert.AreEqual(World.Side.Left, Jim.Destination);
        }

        [TestMethod]
        public void MonkeyStepsOneUnit()
        {
            Monkey Jim = new Monkey("Jim", World.Side.Left);
            Jim.Step();

            Assert.AreEqual(1, Jim.CurrentPosition);
        }
    }
}
