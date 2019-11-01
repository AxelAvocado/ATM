using System;
using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using TransponderReceiverApplication;

namespace TransponderReceiverUser.Test.Unit
{
    public class CollisionDetection_Test
    {
        private ITransponderReceiverClient transponder;
        private CollisionDetection UUT;
        private int EventsPasser = 0;

        [SetUp]
        public void setup()
        {
            transponder = Substitute.For<ITransponderReceiverClient>();
            UUT=new CollisionDetection(transponder);
        }
        //test af collision detection property X
        [Test]
        public void calcDistx_test()
        {
            transponder.AirplaneListReady += Raise.EventWith(new AirplanesList { });
            Assert.That(UUT.DistX, Is.EqualTo(0));
        }
        //test af collision detection property y
        [Test]
        public void calcDisty_test()
        {
            transponder.AirplaneListReady += Raise.EventWith(new AirplanesList { });
            Assert.That(UUT.DistY, Is.EqualTo(0));
        }
        //test af collision detection property H
        [Test]
        public void calcDistH_test()
        {
            transponder.AirplaneListReady += Raise.EventWith(new AirplanesList { });
            Assert.That(UUT.DistH, Is.EqualTo(0));
        }
        //Test af collision detection property timediff
        [Test]
        public void calcDistTime_test()
        {
            transponder.AirplaneListReady += Raise.EventWith(new AirplanesList { });
            Assert.That(UUT.TimeDiff, Is.EqualTo(0));
        }


    }
}
