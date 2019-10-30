using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;
using TransponderReceiverUser;

namespace TransponderReceiverApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AirplaneData> airplane= new List<AirplaneData>();
            airplane.Add(new AirplaneData{Tag = "fly1", X = 100, Y = 100, Z = 100, Time = DateTime.Now});
            airplane.Add(new AirplaneData{Tag = "fly2", X = 101, Y = 101, Z = 101, Time = DateTime.Now});
            airplane.Add(new AirplaneData{Tag = "fly3", X = 103, Y = 102, Z = 102, Time = DateTime.Now});
            airplane.Add(new AirplaneData{Tag = "fly4", X = 104, Y = 103, Z = 103, Time = DateTime.Now });

            //airplane.Add(new AirplaneData{Tag = "fly4", X = 6000, Y = 6000, Z = 1030, Time = DateTime.Now });


            CollisionDetection c = new CollisionDetection(airplane);

            // Using the real transponder data receiver
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            // Dependency injection with the real TDR
            var system = new TransponderReceiverUser.TransponderReceiverClient(receiver);

            //var log = new log(receiver);

            //TrackLog.printData(receiver);

            // Let the real TDR execute in the background
            while (true)
                Thread.Sleep(1000);
        }
    }
}
