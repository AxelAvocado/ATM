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
        //test af collision detection
        [Test]
        public void calcDist_test()
        {
            transponder.AirplaneListReady +=Raise.EventWith(new AirplanesList {});
            Assert.That(UUT.DistX, Is.EqualTo(0));
        }

    }
}
