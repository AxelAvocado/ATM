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
        private ITransponderReceiverClient Transponder;
        private CollisionDetection UUT;

        [SetUp]
        public void Setup()
        {
            Transponder = Substitute.For<ITransponderReceiverClient>();
            UUT = new CollisionDetection(Transponder);
        }

        [Test]
        ////test af collision detection med airplanelist object som ikke fuldfører programmet på grund af tidsforskel
        public void CalcDistObjectTime_test()
        {
            List<AirplaneData> airList = new List<AirplaneData>();
            AirplaneData a = new AirplaneData("QUA537;20000;20000;20000;20191027221909363");
            AirplaneData a1 = new AirplaneData("UQA937;10000;20000;20000;20191027221809363");
            airList.Add(a);
            airList.Add(a1);

            Transponder.AirplaneListReady += Raise.EventWith(new AirplanesList { AirplaneDataList = airList });
            Assert.That(UUT.TimeDiff, Is.EqualTo(60));
        }
        [Test]
        ////test af collision detection med airplanelist object som ikke fuldfører programmet på grund af Y koordinat
        public void CalcDistObjectY_test()
        {
            List<AirplaneData> airList = new List<AirplaneData>();
            AirplaneData a = new AirplaneData("QUA537;20000;20000;20000;20191027221909363");
            AirplaneData a1 = new AirplaneData("UQA937;20000;14000;20000;20191027221809363");
            airList.Add(a);
            airList.Add(a1);

            Transponder.AirplaneListReady += Raise.EventWith(new AirplanesList { AirplaneDataList = airList });
            Assert.That(UUT.DistY, Is.EqualTo(6000));
        }


        //test af collision detection med airplanelist object som fuldfører programmet
        [Test]
        public void CalcDistObjectTrue_test()
        {
            List<AirplaneData> airList = new List<AirplaneData>();
            AirplaneData a = new AirplaneData("QUA537;20000;20000;20000;20191027221809363");
            AirplaneData a1 = new AirplaneData("UQA937;18500;20000;20000;20191027221809363");
            airList.Add(a);
            airList.Add(a1);

            Transponder.AirplaneListReady += Raise.EventWith(new AirplanesList { AirplaneDataList = airList });
            Assert.That(UUT.DistX, Is.EqualTo(1500));
        }

    }
}
