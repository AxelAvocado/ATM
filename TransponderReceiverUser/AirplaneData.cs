using System;
using System.Collections.Generic;
using System.Text;
using TransponderReceiver;
using System.Collections;

namespace TransponderReceiverApplication
{
    public class AirplaneData : EventArgs
    {
        public string Tag { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public DateTime Time { get; set; }
        public Double Speed { get; set; }
        public Double Direction { get; set; }

        public AirplaneData(string data)
        {
            var dataArray = data.Split(';');

            Tag = dataArray[0];
            X = int.Parse(dataArray[1]);
            Y = int.Parse(dataArray[2]);
            Z = int.Parse(dataArray[3]);
            Time = DateTime.ParseExact(dataArray[4], "yyyyMMddHHmmssfff", null);
        }
    }
}
