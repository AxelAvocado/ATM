﻿using System;
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
        private int DistH ;
        private long TimeDiff;
        private string path;

        public CollisionDetection(ITransponderReceiverClient transponderReceiverClient)
        {
            transponderReceiverClient.AirplaneListReady += CalcDist;
            //path = "C:/Users/Sakariye/Skrivebord/detection.txt"; 
            path = "C:/Users/Bruger/Desktop/detection.txt";
             transponderReceiverFactories =new List<AirplaneData>();
        }
        
        public List<AirplaneData> transponderReceiverFactories { get; set; }
        //public void DetectCollision(List<AirplaneData> r)
        //{
        //    transponderReceiverFactories = r;
        //    //get the desktop path
        //    path = "C:/Users/Abdallah Ajjawi/Desktop/detection.txt";
        //    CalcDist(transponderReceiverFactories);
        //}

        public void CalcDist(object sender, AirplanesList e)
        {
            transponderReceiverFactories = e.AirplaneDataList;

            foreach(var t in transponderReceiverFactories)
            {
                Console.WriteLine($"{t.Tag}");
            }

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
                    //tw.WriteLine("Starting New Collision Detection");
                }

            }

            AirplaneData[] TRF = transponderReceiverFactories.ToArray();
            for (int j = 0; j < TRF.Length; j++)
            {
                for (int i = j; i < TRF.Length; i++)
                {
                    try
                    {
                        TimeDiff = (long)((TimeSpan)(TRF[j].Time - TRF[i].Time)).TotalSeconds;
                        DistH = TRF[j].Z - TRF[i].Z;
                        DistY = TRF[j].Y - TRF[i].Y;
                        DistX = TRF[j].X - TRF[i].X;
                        //Console.WriteLine($"højde forskellen mellem flyene er {TRF[i].Z} og {TRF[j].Z} er {DistH} {TRF[i].Tag} og {TRF[j].Tag}");
                        if ((-1000 < DistH && DistH < 1000) && (-120 < TimeDiff && TimeDiff < 120))
                        {
                            //Console.WriteLine($"{TRF[i].X} og {TRF[j].X} distance er {DistX} på {TRF[i].Tag} og {TRF[j].Tag}");
                            if (TRF[j].Tag != TRF[i].Tag && (-10000 < DistX && DistX < 10000) && (-10000 < DistY && DistY < 10000))
                            {
                                Console.WriteLine("vi når aldrig her");
                                using (StreamWriter tw = File.AppendText(path))
                                {
                                    tw.WriteLine($"{TRF[j].Time}, {TRF[j].Tag}, {TRF[i].Tag} is going to crash");
                                }

                                Console.WriteLine($"{TRF[j].Time}, {TRF[j].Tag}, {TRF[i].Tag} is going to crash");
                            }
                        }
                    }
                    catch
                    {
                        using (StreamWriter tw = File.AppendText(path))
                        {
                            tw.WriteLine($"Detection is over");
                        }
                    }
                }

            }

        }
    }
}
