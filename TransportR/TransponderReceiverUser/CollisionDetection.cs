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
        private int TimeDiff;
        private string path;
        //public delegate void Seperation(TransponderReceiverFactory p1, TransponderReceiverFactory p2);

        private List<AirplaneData> transponderReceiverFactories;
        public CollisionDetection(List<AirplaneData> r)
        {
            transponderReceiverFactories = r;
            //Create the file
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            CalcDist(transponderReceiverFactories);
        }

        public void CalcDist(List<AirplaneData> r)
        {
            TextWriter tw = new StreamWriter(path);
            //Først tjek hvis filen eksisterer hvis den ikke eksisterer så opret
            if (!File.Exists(path))
            {
                File.Create(path);
                tw.WriteLine("Collision Detection");
            }
            else
            {
                using (var tw1 = new StreamWriter(path, true))
                {
                    tw1.WriteLine("Starting Collision Detection");
                }
            }
            AirplaneData[] TRF = r.ToArray();

            for (int i = 0; i < TRF.Length; i++)
            {
                for (int j = 0; j < TRF.Length; j++)
                {
                    TimeDiff = int.Parse(TRF[j].Time.ToString()) - int.Parse(TRF[i].Time.ToString());
                    DistH = TRF[j].Z - TRF[i].Z;
                    DistY = TRF[j].Y - TRF[i].Y;
                    DistX = TRF[j].X - TRF[i].X;

                    if ((-300 < DistH && DistH < 300) && TimeDiff == 0)
                    {
                        if (TRF[j].Tag != TRF[i].Tag && (-5000 < DistX && DistX < 5000) && (-5000 < DistY && DistY < 5000))
                        {

                            //StreamWriter stream = File.CreateText(path);
                            tw.WriteLine($"{TRF[j].Time}, {TRF[j].Tag}, {TRF[i].Tag}");
                        }
                    }
                }
            }
        }
    }
}
