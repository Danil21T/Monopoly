using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using System;
using System.Collections.Generic;

namespace MonopolyTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetVolume_Box()
        {
            int x = 5; int y = 6; int z = 7;
            int expected = 210;

            Box b = new Box(x, y, z, DateTime.Now, true, 30);

            int actual = b.getVolume();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetVolume_Pallet()
        {
            int x1 = 5; int y1 = 6; int z1 = 7; int weight1 = 10;
            int x2 = 10; int y2 = 20; int z2 = 30; int weight2 = 50;
            List<Box> b = new List<Box>
            {
                new Box(x1, y1, z1, DateTime.Now, true, weight1),
                new Box(x2, y2, z2, DateTime.Now, true, weight2)
            };

            int x_p = 50; int y_p = 10; int z_p = 50;
            Pallet p = new Pallet(b, x_p, y_p, z_p);

            int expected = 31210;

            int actual = p.getVolume();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetWeight_Pallet()
        {
            int x1 = 5; int y1 = 6; int z1 = 7; int weight1 = 10;
            int x2 = 10; int y2 = 20; int z2 = 30; int weight2 = 50;
            List<Box> b = new List<Box>
            {
                new Box(x1, y1, z1, DateTime.Now, true, weight1),
                new Box(x2, y2, z2, DateTime.Now, true, weight2)
            };

            int x_p = 50; int y_p = 10; int z_p = 50;
            Pallet p = new Pallet(b, x_p, y_p, z_p);

            int expected = 90;

            int actual = p.getWeight();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddBox_Pallet()
        {
            int x = 5; int y = 6; int z = 7;
            Box b = new Box(x, y, z, DateTime.Now, true, 30);
            int x_p = 10; int y_p = 10; int z_p = 10;
            Pallet p = new Pallet(x_p, y_p, z_p);

            bool expected = true;

            bool actual = p.addBox(b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddBox_List_Pallet()
        {
            int x1 = 5; int y1 = 6; int z1 = 7; int weight1 = 10;
            int x2 = 10; int y2 = 20; int z2 = 30; int weight2 = 50;
            List<Box> b = new List<Box>
            {
                new Box(x1, y1, z1, DateTime.Now, true, weight1),
                new Box(x2, y2, z2, DateTime.Now, true, weight2)
            };

            int x_p = 50; int y_p = 10; int z_p = 50;
            Pallet p = new Pallet(x_p, y_p, z_p);

            bool expected = true;

            bool actual = p.addBox(b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddBox_WrongBox_Pallet()
        {
            int x = 15; int y = 6; int z = 20;
            Box b = new Box(x, y, z, DateTime.Now, true, 30);
            int x_p = 10; int y_p = 10; int z_p = 10;
            Pallet p = new Pallet(x_p, y_p, z_p);

            bool expected = false;

            bool actual = p.addBox(b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddBox_List_WrongBox_Pallet()
        {
            int x1 = 60; int y1 = 6; int z1 = 60; int weight1 = 10;
            int x2 = 100; int y2 = 20; int z2 = 300; int weight2 = 50;
            List<Box> b = new List<Box>
            {
                new Box(x1, y1, z1, DateTime.Now, true, weight1),
                new Box(x2, y2, z2, DateTime.Now, true, weight2)
            };

            int x_p = 50; int y_p = 10; int z_p = 50;
            Pallet p = new Pallet(x_p, y_p, z_p);

            bool expected = false;

            bool actual = p.addBox(b);

            Assert.AreEqual(expected, actual);
        }
    }
}
