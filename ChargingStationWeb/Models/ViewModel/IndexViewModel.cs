using System.Collections.Generic;

namespace ChargingStationWeb.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<ChargingStation> ChargingStationList { get; set; }
    }
}
