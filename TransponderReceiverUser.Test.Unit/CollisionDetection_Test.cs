﻿using System;
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

        [SetUp]
        public void setup()
        {
            transponder = Substitute.For<ITransponderReceiverClient>();
            UUT = new CollisionDetection(transponder);
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
            AirplaneData a2 = Substitute.For<AirplaneData>();
            AirplaneData a3 = Substitute.For<AirplaneData>();
            a2.Tag.Returns("fl1");
            a3.Tag.Returns("fl2");

            List<AirplaneData> airList = new List<AirplaneData>();
            AirplaneData a = new AirplaneData("QUA537;20000;20000;20000;20191027221809363");
            AirplaneData a1 = new AirplaneData("UQA937;80000;80000;10000;20191027221809363");
            airList.Add(a);
            airList.Add(a1);

            transponder.AirplaneListReady += Raise.EventWith(new AirplanesList {AirplaneDataList = airList });
            Assert.That(UUT.DistX, Is.EqualTo(0));
        }

    }
}
