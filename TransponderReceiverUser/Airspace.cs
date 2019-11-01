using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace TransponderReceiverUser
{
    public class Airspace
    {
        public bool InAirSpace(int x, int y)
        {
            if (x > 90000 || x < 10000 || y > 90000 || y < 10000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
