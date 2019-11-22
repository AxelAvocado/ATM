using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using TransponderReceiverApplication;

namespace TransponderReceiverUser.Test.Unit
{
    public class AirPlaneList_Test
    {
        //laver unittest til AirPlaneList
        private AirplanesList _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new AirplanesList();
        }

        [TestCase("QUA537;20000;20000;20000;20191027221809363")]
        [TestCase("QU5637;200000;200000;200000;20191027221809363")]
        [TestCase("QA537;2000;2000;2000;20191027221809365")]
        [TestCase("QUAF37;200;200;200;20191027221805363")]
        public void GetList_test(string planeData)
        {
            // Setup test data
            var apd = new AirplaneData(planeData);

            var listPlaneData = new List<AirplaneData>();
            listPlaneData.Add(apd);

            // Act: Add apd object to uut.list
            _uut.AddToList(apd);
            
            // Assert that lists are the same
            Assert.That(_uut.GetList(), Is.EqualTo(listPlaneData));  
        }

        // Tester remove
        [Test]
        public void RemovingObject_test()
        {
            AirplaneData planeData = new AirplaneData("QUAF37;200;200;200;20191027221805363");

            // Setup data
            _uut.AirplaneDataList.Add(planeData);

            var listPlaneData = new List<AirplaneData>();
            listPlaneData.Add(planeData);

            // Act: Add apd object to uut.list
            _uut.AddToList(planeData);

            // Assert that lists are the same
            Assert.That(_uut.GetList(), Is.EqualTo(listPlaneData));
        }
    }
}
