using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;

namespace TransponderReceiverUser
{
    class AirplanesList
    {
        public List<AirplaneData> myList = new List<AirplaneData>();

        public List<AirplaneData> GetList()
        {
            return myList;
        }

    }
}
