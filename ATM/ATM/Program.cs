using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Airspace a = new Airspace();
            TrackRendition T = new TrackRendition(a);
            T.printTrack("Zabih", 5, 10, 600, 138, 200);
        }
    }
}
