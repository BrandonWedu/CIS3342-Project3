using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    internal static class ReadTemperatureControl
    {
        internal static TemperatureControl GetByHomeID(int homeID)
        {
            return new TemperatureControl(HeatingTypes.Boiler, CoolingTypes.ChilledBeams);
        }
    }
}
