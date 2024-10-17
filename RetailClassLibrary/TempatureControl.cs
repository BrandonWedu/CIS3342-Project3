using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailClassLibrary
{
    //Enum for heating types
    public enum HeatingTypes
    {
        CentralHeating,
        Furnace,
        Boiler,
        HeatPump,
        ForcedAirHeat,
        RadiantFloorHeating,
        ElectricHeating,
        WoodStove,
        GasFireplace,
        OilHeat,
        PropaneHeat,
        HotWaterRadiators,
    }
    //Enum for cooling types
    public enum CoolingTypes
    {
        CentralAir,
        WindowAirConditioner,
        EvaporativeCooler,
        CeilingFans,
        ExhaustFans,
        ChilledBeams,
        IceStorageCooling,
        RadiantCooling
    }

    //Holds all data for heating and cooling
    internal class TempatureControl
    {
        //Fields 
        private HeatingTypes heating;
        private CoolingTypes cooling;

        //Constructor
        public TempatureControl(HeatingTypes heating, CoolingTypes cooling)
        {
            this.heating = heating;
            this.cooling = cooling;
        }

        //Get Set
        public HeatingTypes Heating
        {
            get { return heating; }
            set { heating = value; }
        }
        public CoolingTypes Cooling
        {
            get { return cooling; }
            set { cooling = value; }
        }
    }
}
