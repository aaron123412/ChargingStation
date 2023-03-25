using ChargingStationAPI.Models;
using System.Collections.Generic;

namespace ChargingStationAPI.Repository.IRepository
{
    public interface IChargingStationRepository
    {
        ICollection<ChargingStation> GetChargingStations();
        ChargingStation GetChargingStation(int id);
        ICollection<ChargingStation> GetChargingStationByProvince(string province);
        bool ChargingStationExists(string name);
        bool ChargingStationExists(int id);
        bool CreateChargingStation(ChargingStation chargingStation);
        bool UpdateChargingStation(ChargingStation chargingStation);
        bool DeleteChargingStation(ChargingStation chargingStation);
        bool Save();
    }
}
