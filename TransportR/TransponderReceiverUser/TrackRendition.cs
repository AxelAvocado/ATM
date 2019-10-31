using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;

namespace TransponderReceiverUser
{
    public class TrackRendition
    {
        public TrackRendition(ICalculateAirplaneData CalculateAirplaneData)
        {
            CalculateAirplaneData.UpdatedAirplaneListReady += PrintPlanes;
        }
        private void PrintPlanes(object sender, AirplaneData e)
        {
            Console.WriteLine($"Calculated new data for {e.Tag}: Speed = {e.Speed} km/t, Direction = {e.Direction} degrees");
        }
    }
}
