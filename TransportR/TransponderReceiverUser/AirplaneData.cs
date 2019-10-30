using System;
using System.Collections.Generic;
using System.Text;
using TransponderReceiver;

namespace TransponderReceiverApplication
{
    public class AirplaneData
    {
        public string Tag { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public DateTime Time { get; set; }

        public AirplaneData(string data)
        {
            var dataArray = data.Split(';');

            Tag = dataArray[0];
            X = int.Parse(dataArray[1]);
            Y = int.Parse(dataArray[2]);
            Z = int.Parse(dataArray[3]);
            Time = DateTime.ParseExact(dataArray[4], "yyyyMMddHHmmssfff", null);

        }



        //public void UpdateAirplane(string newTag, int newX, int newY, int newZ, DateTime newTime)
        //{
        //    //Tag = currentTag;
        //    //X = currentX;
        //    //Y = currentY;
        //    //Z = currentZ;
        //    //Time = currentTime;

        //    if (newTag == Tag)
        //    {
        //        currentX = newX;
        //        currentY = newY;
        //        currentZ = newZ;
        //        currentTime = newTime;
        //    }
        //}

    }
}
