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
