using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using TransponderReceiverApplication;

namespace TransponderReceiverUser.Test.Unit
{
    public class AirPlaneList_Test
    {
        //laver unittest til AirPlaneList
        private AirplanesList UUT;

        [SetUp]
        public void Setup()
        {
            UUT=new AirplanesList();
        }

        [TestCase("QUA537;20000;20000;20000;20191027221809363")]
        [TestCase("QU5637;200000;200000;200000;20191027221809363")]
        [TestCase("QA537;2000;2000;2000;20191027221809365")]
        [TestCase("QUAF37;200;200;200;20191027221805363")]
        public void GetList_test(string e)
        {
            var apd = new AirplaneData(e);
            var apl = new AirplanesList();
            apl.AddToList(apd);
            var lapd = new List<AirplaneData>();
            lapd.Add(apd);

            Assert.That(apl.GetList(), Is.EqualTo(lapd));  
        }


        //tester AddToList fra AirPlaneList med at give den input parameter og se hvorvidt det er blevet indsat 

        //[Test]
        //public void AddToListTest()
        //{
        //    AirplaneData IairPlaneData = Substitute.For<AirplaneData>();
        //    IairPlaneData.Tag.Returns("Fly1");

        //    UUT.AddToList(IairPlaneData);
            
        //    List<AirplaneData> PlaneList= UUT.GetList();

        //    Assert.That(PlaneList[0].Tag, Is.EqualTo("fly1"));

        //}



    }
}
