using System;
using System.Collections.Generic;
using System.Text;
using TransponderReceiver;

namespace TransponderReceiverApplication
{
    class Airplane
    {
        public string Tag { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public DateTime Time { get; set; }

        public Airplane(string data)
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
