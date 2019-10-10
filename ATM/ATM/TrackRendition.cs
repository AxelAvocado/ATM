using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class TrackRendition
    {
        public TrackRendition(Airspace a)
        {
        }

        public void printTrack(string tag, int x, int y, int z, double V, int compasCourse)
        {
            tag = (tag.Length > 6) ? tag.Substring(0, 6) : tag;
            x = (x < 0) ? 0 : x;
            y = (y < 0) ? 0 : y;
            z = (z > 500 && z <= 20000) ? 0 : z;
            V = (V < 0) ? 0 : V;
            compasCourse = (compasCourse < 0 && compasCourse < 359) ? 0 : compasCourse;

            Console.WriteLine(tag + ", (" + x + ", " + y + ", " + z + "), " + "V: " + V + ", Course: " + compasCourse);
        }
    }
}
