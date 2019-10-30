using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiverApplication;

namespace TransponderReceiverUser
{
    public class AirplanesList
    {
        public List<AirplaneData> AirplaneDataList = new List<AirplaneData>();

        public List<AirplaneData> GetList()
        {
            return AirplaneDataList;
        }

    }
}
