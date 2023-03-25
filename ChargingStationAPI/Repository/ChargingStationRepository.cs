using ChargingStationAPI.Data;
using ChargingStationAPI.Models;
using ChargingStationAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ChargingStationAPI.Repository
{
    public class ChargingStationRepository : IChargingStationRepository
    {
        private readonly ApplicationDbContext _db;
        public ChargingStationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateChargingStation(ChargingStation chargingStation)
        {
            _db.ChargingStations.Add(chargingStation);
            return Save();
        }
        public bool UpdateChargingStation(ChargingStation chargingStation)
        {
            _db.ChargingStations.Update(chargingStation);
            return Save();
        }

        public bool DeleteChargingStation(ChargingStation chargingStation)
        {
            _db.ChargingStations.Remove(chargingStation);
            return Save();
        }

        public ChargingStation GetChargingStation(int id)
        {
            return _db.ChargingStations.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<ChargingStation> GetChargingStations()
        {
            return _db.ChargingStations.OrderBy(c => c.Name).ToList();
        }
        public bool ChargingStationExists(string name)
        {
            return _db.ChargingStations.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool ChargingStationExists(int id)
        {
            return _db.ChargingStations.Any(c => c.Id == id);
        }
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public ICollection<ChargingStation> GetChargingStationByProvince(string province)
        {
            return _db.ChargingStations.Where(c => c.Province.ToLower().Trim() == province.ToLower().Trim()).OrderBy(c => c.Name).ToList();
        }
    }
}
