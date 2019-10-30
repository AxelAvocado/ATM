using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;

namespace TransponderReceiverUser
{
    public class CalculateAirplaneData
    {
        public List<AirplaneData> Airplanes { get; set; }
        public List<AirplaneData> AirplanesUpdated { get; set; }

        public List<AirplaneData> UpdatePlaneData(List<AirplaneData> Airplanes, List<AirplaneData> AirplanesUpdated)
        {
            foreach (var AirplaneUpdated in AirplanesUpdated)
            {
                var AirplaneResult =
                    from AP in Airplanes
                    where AP.Tag == AirplaneUpdated.Tag
                    select AP;

                Console.WriteLine($"Transponderdata {AirplaneUpdated.Tag}");
            };

            return AirplanesUpdated;
        }

        public void CalculateSpeed(AirplaneData Airplane, AirplaneData AirplaneUpdated)
        {
            double speed = 0.0;

            var x1 = Airplane.X;
            var y1 = Airplane.Y;
            var z1 = Airplane.Z;

            var x2 = AirplaneUpdated.X;
            var y2 = AirplaneUpdated.Y;
            var z2 = AirplaneUpdated.Z;

            var dx = x2 - x1;
            var dy = x2 - x1;
            var dz = x2 - x1;

            var dist = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));
            var timeElapsed = AirplaneUpdated.Time - Airplane.Time;

            // Kilometers pr. hour
            speed = (dist / (double) timeElapsed.TotalSeconds) * 3.6;        
        }

        public void CalculateDirection(AirplaneData Airplane, AirplaneData AirplaneUpdated)
        {
            double direction = 0.0;

            var x1 = Airplane.X;
            var y1 = Airplane.Y;

            var x2 = AirplaneUpdated.X;
            var y2 = AirplaneUpdated.Y;

            if (x2 == x1 && y2 == y1)
            {
                direction = double.NaN;
            }
            else
            {
                var x = (Math.Atan2(y2 - y1, x2 - x1) * 180 / Math.PI);
                var temp = Math.Round(x - 90, 2);

                if (temp > 0)
                {
                    direction = 360 - temp;
                }
                else
                {
                    direction = Math.Abs(temp);
                }
            }
        }

    }
}
