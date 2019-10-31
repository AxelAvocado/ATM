using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;

namespace TransponderReceiverUser
{
    public interface ICalculateAirplaneData
    {
        event EventHandler<AirplaneData> UpdatedAirplaneListReady;
    }
    public class CalculateAirplaneData : ICalculateAirplaneData
    {
        public event EventHandler<AirplaneData> UpdatedAirplaneListReady;
        protected virtual void OnAirplaneListUpdatedEvent(AirplaneData e )
        {
            UpdatedAirplaneListReady?.Invoke(this, e);
        }
        public CalculateAirplaneData(ITransponderReceiverClient transponderReceiverClient)
        {
            transponderReceiverClient.AirplaneListReady += UpdatePlaneData;
            Airplanes = new List<AirplaneData>();
            AirplanesUpdated = new List<AirplaneData>();
        }

        public List<AirplaneData> Airplanes { get; set; }
        public List<AirplaneData> AirplanesUpdated { get; set; }

        public void UpdatePlaneData(object sender, AirplanesList e)
        {
            Airplanes = new List<AirplaneData>(AirplanesUpdated);
            AirplanesUpdated = new List<AirplaneData>(e.AirplaneDataList);

            foreach (var AirplaneUpdated in AirplanesUpdated)
            {
                foreach (var Airplane in Airplanes)
                {
                    if (Airplane.Tag == AirplaneUpdated.Tag)
                    {
                        AirplaneUpdated.Speed = CalculateSpeed(Airplane, AirplaneUpdated);
                        AirplaneUpdated.Direction = CalculateDirection(Airplane, AirplaneUpdated);
                        OnAirplaneListUpdatedEvent(AirplaneUpdated);
                        //Console.WriteLine($"{Airplane.X} og {AirplaneUpdated.X}");
                        //Console.WriteLine($"Calculated new data for {AirplaneUpdated.Tag}: Speed = {AirplaneUpdated.Speed} km/t, Direction = {AirplaneUpdated.Direction} degrees");
                    }
                }
            };
        }

        public double CalculateSpeed(AirplaneData Airplane, AirplaneData AirplaneUpdated)
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
            return speed;
        }

        public double CalculateDirection(AirplaneData Airplane, AirplaneData AirplaneUpdated)
        {
            double direction = 0.0;

            var x1 = Airplane.X;
            var y1 = Airplane.Y;

            var x2 = AirplaneUpdated.X;
            var y2 = AirplaneUpdated.Y;

            if (x2 == x1 && y2 == y1)
            {
                direction = double.NaN;
                return direction;
            }
            else
            {
                var x = (Math.Atan2(y2 - y1, x2 - x1) * 180 / Math.PI);
                var temp = Math.Round(x - 90, 2);

                if (temp > 0)
                {
                    direction = 360 - temp;
                    return direction;
                }
                else
                {
                    direction = Math.Abs(temp);
                    return direction;
                }
            }
        }

    }
}
