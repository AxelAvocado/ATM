using System;
using System;
using System.Collections.Generic;
using Castle.Core.Smtp;
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

        //test af collision detection med airplanelist object
        [Test]
        public void calcDistObject_test()
        {
            List<AirplaneData> airlList=new List<AirplaneData>();
            AirplaneData a = new AirplaneData("QUA537;20000;20000;20000;20191027221809363");
            AirplaneData a1 = new AirplaneData("UQA937;16000;15000;19999;20191027221809363");
            airlList.Add(a);
            airlList.Add(a1);

            transponder.AirplaneListReady += Raise.EventWith(new AirplanesList {AirplaneDataList = airlList });
            Assert.That(UUT.DistX, Is.EqualTo(-4000));
        }

    }
}
