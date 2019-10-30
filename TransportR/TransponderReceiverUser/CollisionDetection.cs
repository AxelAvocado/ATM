using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;

namespace TransponderReceiverUser
{
    public class CollisionDetection
    {
        private int DistY;
        private int DistX;
        private int DistH;
        private long TimeDiff;
        private string path;
        
        private List<AirplaneData> transponderReceiverFactories;
        public CollisionDetection(List<AirplaneData> r)
        {
            transponderReceiverFactories = r;
            //get the desktop path
            path = "c:\\Users\\zabih\\Desktop\\Detection.txt";
            CalcDist(transponderReceiverFactories);
        }

        public void CalcDist(List<AirplaneData> r)
        {
            //Først tjek hvis filen eksisterer hvis den ikke eksisterer så opret
            if (!File.Exists(path))
            {
                using (StreamWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine("Collision Detection File");
                }
            }
            else if(File.Exists(path))
            {
                using (StreamWriter tw = File.AppendText(path))
                {
                    tw.WriteLine("Starting New Collision Detection");
                }

            }
            AirplaneData[] TRF = r.ToArray();

                for (int j = 0; j < TRF.Length; j++)
                {
                    try
                    {
                        TimeDiff = (long) ((TimeSpan) (TRF[j].Time - TRF[j + 1].Time)).TotalSeconds;
                        DistH = TRF[j].Z - TRF[j + 1].Z;
                        DistY = TRF[j].Y - TRF[j + 1].Y;
                        DistX = TRF[j].X - TRF[j + 1].X;

                        if ((-300 < DistH && DistH < 300) && (-120 < TimeDiff && TimeDiff < 120))
                        {
                            if (TRF[j].Tag != TRF[j + 1].Tag && (-5000 < DistX && DistX < 5000) &&
                                (-5000 < DistY && DistY < 5000))
                            {
                                using (StreamWriter tw = File.AppendText(path))
                                {
                                    tw.WriteLine($"{TRF[j].Time}, {TRF[j].Tag}, {TRF[j + 1].Tag} is going to crash");
                                }
                            }
                        }
                    }
                    catch
                    {
                    using (StreamWriter tw = File.AppendText(path))
                    {
                            //StreamWriter stream = File.CreateText(path);
                            tw.WriteLine($"Collision Detection over");
                    }
                    }
                }
        }
    }
}
