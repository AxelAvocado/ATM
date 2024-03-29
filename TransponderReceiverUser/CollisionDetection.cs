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
        public int DistY { get; set; }
        public int DistX { get; set; }
        public int DistH { get; set; }
        public long TimeDiff { get; set; }
        public string path { get; set; }

        public CollisionDetection(ITransponderReceiverClient transponderReceiverClient)
        {
            transponderReceiverClient.AirplaneListReady += CalcDist;
            //path = "C:/Users/Sakariye/Skrivebord/detection.txt"; 
            path = "../detection.txt";
             transponderReceiverFactories =new List<AirplaneData>();
        }
        
        public List<AirplaneData> transponderReceiverFactories { get; set; }

        public void CalcDist(object sender, AirplanesList e)
        {
            transponderReceiverFactories = e.AirplaneDataList;

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
                    if (TRF[j].Tag != TRF[i].Tag)
                    {
                        TimeDiff = (long)((TimeSpan)(TRF[j].Time - TRF[i].Time)).TotalSeconds;
                        DistH = TRF[j].Z - TRF[i].Z;
                        DistY = TRF[j].Y - TRF[i].Y;
                        DistX = TRF[j].X - TRF[i].X;
                        if ((-300 < DistH && DistH < 300) && (-120 < TimeDiff && TimeDiff < 120))
                        {
                            //Console.WriteLine($"{TRF[i].X} og {TRF[j].X} distance er {DistX} på {TRF[i].Tag} og {TRF[j].Tag}");
                            if (TRF[j].Tag != TRF[i].Tag && (-5000 < DistX && DistX < 5000) && (-5000 < DistY && DistY < 5000))
                            {
                                Console.WriteLine($"{TRF[j].Time}, {TRF[j].Tag}, {TRF[i].Tag} is going to crash");
                                using (StreamWriter tw = File.AppendText(path))
                                {
                                    tw.WriteLine($"{TRF[j].Time}, {TRF[j].Tag}, {TRF[i].Tag} is going to crash");
                                }

                            }
                        }
                    }                     
                    
                }

            }

        }
    }
}
