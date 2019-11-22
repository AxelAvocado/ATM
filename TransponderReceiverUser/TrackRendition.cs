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
            CalculateAirplaneData.UpdatedAirplaneListReady += EventHandler;
    }
        public void EventHandler(object sender, AirplaneData e)
        {
            PrintPlanes(e);
        }

        public AirplaneData PrintPlanes(AirplaneData a)
        {
            Console.WriteLine(Environment.NewLine + "----------------------------------------------------------------------------------------------" + Environment.NewLine);

            Console.WriteLine($"Transponderdata {a.Tag} {a.Time}");
            Console.WriteLine($"Calculated new data for {a.Tag}: Speed = {a.Speed} km/t, Direction = {a.Direction} degrees");

            Console.WriteLine(Environment.NewLine + "----------------------------------------------------------------------------------------------" + Environment.NewLine);

            return a;

        }
        
    }
}
