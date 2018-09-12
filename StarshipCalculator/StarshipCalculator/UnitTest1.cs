using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarshipCalculator;

namespace StarshipUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateStarshipConstructor1()
        {

            var ship = new Starship();

            Assert.IsNotNull(ship);
            
        }

        [TestMethod]
        public void CreateStarshipConstructor2()
        {

            var ship = new Starship("TestName", 12.5M);

            Assert.IsNotNull(ship);

        }

        [TestMethod]
        public void GetStarshipsTest()
        {

            var result = Program.GetStarships();

            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        public void GetFuelRangeTest1()
        {

            var result = Program.GetFuelStops(10,100);

            Assert.AreEqual(result, 9);


        }

        [TestMethod]
        public void GetFuelRangeTest2()
        {

            var result = Program.GetFuelStops(15, 100);

            Assert.AreEqual(result, 6);


        }

        [TestMethod]
        public void GetFuelRangeTest3()
        {

            var result = Program.GetFuelStops(0, 100);

            Assert.AreEqual(result, 0);
            
        }

        [TestMethod]
        public void GetFuelRangeTest4()
        {

            var result = Program.GetFuelStops(100, 0);

            Assert.AreEqual(result, 0);

        }

        public void GetFuelRangeTest5()
        {
            //Range is larger than distance

            var result = Program.GetFuelStops(10, 100);

            Assert.AreEqual(result, 0);

        }
    }
}
