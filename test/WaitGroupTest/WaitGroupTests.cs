using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandardCore.Routine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WaitGroupTest
{
    [TestClass]
    public class WaitGroupTests
    {
        [TestMethod]
        public void NoWaitOnZero()
        {
            var wg = new WaitGroup();

            wg.Await();
        }

        [TestMethod]
        public void Await()
        {
            var wg = new WaitGroup();
            var i = new byte[] { 0 };
            wg.Add(2);
            new Thread(new ParameterizedThreadStart((state) =>
            {
                Thread.Sleep(100);
                i[0] = (byte)(i[0] + 1);
                wg.Done();
            })).Start();
            new Thread(new ParameterizedThreadStart((state) =>
            {
                Thread.Sleep(100);
                i[0] = (byte)(i[0] + 1);
                wg.Done();
            })).Start();

            wg.Await();
            Assert.AreNotEqual(i[0], 0);
        }
    }
}
