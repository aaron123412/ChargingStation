using ChargingStationWeb.Models;
using ChargingStationWeb.Repository.IRepository;
using System.Net.Http;

namespace ChargingStationWeb.Repository
{
    public class ChargingStationRepository : Repository<ChargingStation>, IChargingStationRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public ChargingStationRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
