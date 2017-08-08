using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonkeysOnARope;

namespace MonkeysOnARopeTests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void WorldInitialization()
        {
            World w = new World();
            Assert.IsInstanceOfType(w, typeof(World));
            Assert.IsNotNull(w.LeftQue);
            Assert.IsNotNull(w.RightQue);
            Assert.IsFalse(w.Done); 
        }

        [TestMethod]
        public void WorldStepsByOne()
        {
            World w = new World();
            w.LeftQue.Add(new Monkey("Jim", World.Side.Left));
            Assert.AreEqual(0, w.NumStepsTaken);
            w.Step();
            Assert.AreEqual(1, w.NumStepsTaken);
        }

        [TestMethod]
        public void IntegrationTestWorld()
        {
            World w = new World();

            w.LeftQue.Add(new Monkey("Left1", World.Side.Right));
            w.LeftQue.Add(new Monkey("Left2", World.Side.Right));
            w.LeftQue.Add(new Monkey("Left3", World.Side.Right));
            w.LeftQue.Add(new Monkey("Left4", World.Side.Right));
            w.LeftQue.Add(new Monkey("Left5", World.Side.Right));

            w.RightQue.Add(new Monkey("Right1", World.Side.Left));
            w.RightQue.Add(new Monkey("Right2", World.Side.Left));
            w.RightQue.Add(new Monkey("Right3", World.Side.Left));
            w.RightQue.Add(new Monkey("Right4", World.Side.Left));
            w.RightQue.Add(new Monkey("Right5", World.Side.Left));

            do
            {
                w.Step();
            } while (w.Done == false);

            Assert.AreEqual(19, w.NumStepsTaken);
        }
    }

}
