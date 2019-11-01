using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;

namespace TransponderReceiverUser.Test.Unit
{
    class CalculateAirplaneData_Test
    {
        private ITransponderReceiverClient _fakeTransponderReceiverClient;
        private CalculateAirplaneData _uut;

        [SetUp]
        public void Setup()
        {
            _fakeTransponderReceiverClient = Substitute.For<ITransponderReceiverClient>();
            _uut = new CalculateAirplaneData(_fakeTransponderReceiverClient);
        }

        // Test: Beregning af hastighed
        [Test]
        public void CalculateSpeedTest()
        {
            // Setup test data

            // 500 m på 10 sekund er 180 km/t

            AirplaneData plane = new AirplaneData("QUA537;20000;20000;20000;20191027221809363");
            AirplaneData planeUpdated = new AirplaneData("QUA537;20500;20000;20000;20191027221819363");
            double expectedResult = 180;

            // Act: Beregner hastighed mellem to logs af samme fly
            double result = _uut.CalculateSpeed(plane, planeUpdated);

            // Assert at resultatet er lig 30 km/t
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
