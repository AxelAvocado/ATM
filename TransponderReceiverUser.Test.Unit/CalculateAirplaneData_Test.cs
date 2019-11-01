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
    public class CalculateAirplaneData_Test
    {
        private ITransponderReceiverClient _fakeTransponderReceiverClient;
        private CalculateAirplaneData _uut;

        [SetUp]
        public void Setup()
        {
            _fakeTransponderReceiverClient = Substitute.For<ITransponderReceiverClient>();
            _uut = new CalculateAirplaneData(_fakeTransponderReceiverClient);
        }

        // Test: Opdatering af planedata med sammenligning af to lister
        [Test]
        public void UpdatePlaneDataEventRecepientTest()
        {
            AirplanesList apl = new AirplanesList();
            AirplaneData ap = new AirplaneData("QUA537;20000;20000;20000;20191027221809363");

            apl.AirplaneDataList.Add(ap);

            _fakeTransponderReceiverClient.AirplaneListReady += Raise.EventWith(apl);
            Assert.That(_uut.AirplanesUpdated.ElementAt(0).Tag, Is.EqualTo("QUA537"));
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

        // Test: Beregning af retning
        [TestCase("QUA537;20000;20000;20000;20191027221809363",
                  "QUA537;20000;20000;20000;20191027221809363",
                  double.NaN)]
        [TestCase("QUA537;20000;20000;20000;20191027221809363",
                  "QUA537;20500;20500;20000;20191027221809363",
                  315.00)]
        public void CalculateDirectionTest(string planeString, string planeUpdatedString, double directionExpected)
        {
            // Setup test data

            AirplaneData plane = new AirplaneData(planeString);
            AirplaneData planeUpdated = new AirplaneData(planeUpdatedString);
            double expectedResult = directionExpected;

            // Act: Beregner hastighed mellem to logs af samme fly
            double result = _uut.CalculateDirection(plane, planeUpdated);

            // Assert at resultatet er lig 30 km/t
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
