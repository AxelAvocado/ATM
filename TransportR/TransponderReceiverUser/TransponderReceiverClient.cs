using System;
using System.Collections.Generic;
using System.Data;
using TransponderReceiver;
using TransponderReceiverApplication;

namespace TransponderReceiverUser
{
    public class TransponderReceiverClient
    {
        private ITransponderReceiver receiver;

        

        public Boolean InAirSpace(int x, int y)
        {
            if (x > 90000 || x < 10000 || y > 90000 || y < 10000)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        // Using constructor injection for dependency/ies
        public TransponderReceiverClient(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {

            var AirplaneList = new AirplanesList();

            // Just display data
            foreach (var data in e.TransponderData)
            {
                
                var Airplane = new AirplaneData(data);


                if (InAirSpace(Airplane.X, Airplane.Y))
                {
                    System.Console.WriteLine($"Transponderdata {Airplane.Tag} {Airplane.Time}");

                    AirplaneList.myList.Add(Airplane);
                    AirplaneList.GetList();

                    //Airplane.UpdateAirplane(Airplane.Tag, Airplane.X, Airplane.Y, Airplane.Z, Airplane.Time);


                }
            }
        }
    }
}
