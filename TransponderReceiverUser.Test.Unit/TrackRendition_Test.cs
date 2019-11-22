using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using TransponderReceiverApplication;

namespace TransponderReceiverUser.Test.Unit
{
    class TrackRendition_Test
    {
        private TrackRendition _uut;
        private ICalculateAirplaneData Printer;

        [SetUp]
        public void Setup()
        {
            Printer = Substitute.For<ICalculateAirplaneData>();
            _uut = new TrackRendition(Printer);
        }


        [TestCase("QUA537;20000;20000;20000;20191027221809363")]
        [TestCase("QU5137;25600;20000;20000;20191027221809363")]
        [TestCase("37;20000;25560;20;20191027221809363")]
        [TestCase("QUA537;20000;1;656;20191027221809363")]
        public void UpdatesList_DifferentArguments_PrintPlanesIsCorrect(string w)
        {
            var apd = new AirplaneData(w);
            Printer.UpdatedAirplaneListReady += Raise.EventWith(apd);
            Assert.That(_uut.PrintPlanes(apd), Is.EqualTo(apd));
        }
    }

    
}
