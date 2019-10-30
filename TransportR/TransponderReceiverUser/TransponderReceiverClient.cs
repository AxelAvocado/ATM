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

        private AirplanesList AirplaneList_ = new AirplanesList();
        private Airspace Airspace_ = new Airspace();

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
            // Just display data
            foreach (var data in e.TransponderData)
            {
                var Airplane = new AirplaneData(data);
                
                if (Airspace_.InAirSpace(Airplane.X, Airplane.Y))
                {
                    System.Console.WriteLine($"Transponderdata {Airplane.Tag} {Airplane.Time}");

                    AirplaneList_.AddToList(Airplane);
                }
            }
        }
    }
}
