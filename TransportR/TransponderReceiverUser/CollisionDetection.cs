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

        public CollisionDetection()
        {

        }
        
        private List<AirplaneData> transponderReceiverFactories;
        public void DetectCollision(List<AirplaneData> r)
        {
            transponderReceiverFactories = r;
            //get the desktop path
            path = "C:/Users/Abdallah Ajjawi/Desktop/detection.txt";
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
                    //tw.WriteLine("Starting New Collision Detection");
                }

            }
            AirplaneData[] TRF = r.ToArray();
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

                        if ((-300 < DistH && DistH < 300) && (-120 < TimeDiff && TimeDiff < 120))
                        {
                            if (TRF[j].Tag != TRF[i].Tag && (-5000 < DistX && DistX < 5000) &&
                                (-5000 < DistY && DistY < 5000))
                            {
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
