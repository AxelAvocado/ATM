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

        public void AddToList(AirplaneData AirplaneObj)
        {
            foreach (var ARDL in AirplaneDataList)
            {
                if (ARDL.Tag == AirplaneObj.Tag)
                {
                    AirplaneDataList.Remove(ARDL);
                    break;
                }
            }

            AirplaneDataList.Add(AirplaneObj);
        }

        public List<AirplaneData> GetList()
        {
            return AirplaneDataList;
        }
    }
}
