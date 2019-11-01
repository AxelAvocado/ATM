using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void CalculateSpeed(AirplaneData Airplane, AirplaneData AirplaneUpdated)
        {

        }
    }
}
