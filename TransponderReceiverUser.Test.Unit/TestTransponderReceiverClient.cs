using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace TransponderReceiverUser.Test.Unit
{
    public class TestTransponderReceiverClient
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private TransponderReceiverClient _uut;
        [SetUp]
        public void Setup()
        {
            // Make a fake Transponder Data Receiver
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            // Inject the fake TDR
            _uut = new TransponderReceiverClient(_fakeTransponderReceiver);
        }

        [Test]
        public void TestReception()
        {
            // Setup test data
            List<string> testData = new List<string>
            {
                "ATR423;39045;12932;14000;20151006213456789",
                "BCD123;10005;85890;12000;20151006213456789",
                "XYZ987;25059;75654;4000;20151006213456789"
            };

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            // Assert something here or use an NSubstitute Received
        }

        // Test: Tjek at tilføjet Airplane er InAirSpace
        [TestCase(10000, 10000)]
        [TestCase(23000, 12000)]
        [TestCase(65000, 50000)]
        [TestCase(90000, 90000)]
        public void AirplaneInAirSpace(int x, int y)
        {
            // Setup test data
            Boolean expectedResult = true;

            // Act: Tester at flyet er i airspacet
            Boolean result = _uut.InAirSpace(x, y);

            // Assert at functionen returnere true
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        // Test: Tjek at tilføjet Airplane ikke er InAirSpace
        [TestCase(9999, 9999)]
        [TestCase(550, 950)]
        [TestCase(105000, 12300)]
        [TestCase(90001, 90001)]
        public void AirplaneNotInAirSpace(int x, int y)
        {
            // Setup test data
            Boolean expectedResult = false;

            // Act: Tester at flyet er i airspacet
            Boolean result = _uut.InAirSpace(x, y);

            // Assert at functionen returnere true
            Assert.That(result, Is.EqualTo(expectedResult));

        }
    }
}
