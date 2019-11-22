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
                    }
                }
            };
        }

        public double CalculateSpeed(AirplaneData Airplane, AirplaneData AirplaneUpdated)
        {
            double speed;

            var x1 = Airplane.X;
            var y1 = Airplane.Y;
            var z1 = Airplane.Z;

            var x2 = AirplaneUpdated.X;
            var y2 = AirplaneUpdated.Y;
            var z2 = AirplaneUpdated.Z;

            var dx = x2 - x1;
            var dy = y2 - y1;
            var dz = z2 - z1;

            var dist = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));
            var timeElapsed = AirplaneUpdated.Time - Airplane.Time;

            // Kilometers pr. hour
            speed = (dist / (double) timeElapsed.TotalSeconds) * 3.6;
            return speed;
        }

        public double CalculateDirection(AirplaneData Airplane, AirplaneData AirplaneUpdated)
        {
            double direction;

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
                var Theta = Math.Atan2(y1 - y2, x1 - x2);
                Theta += Math.PI / 2;

                direction = Theta * (180 / Math.PI);

                if (direction < 0)
                {
                    direction += 360;
                }

                return direction;
            }
        }

    }
}
