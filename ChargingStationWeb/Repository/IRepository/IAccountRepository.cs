using ChargingStationWeb.Models;
using System.Threading.Tasks;

namespace ChargingStationWeb.Repository.IRepository
{
    public interface IAccountRepository : IRepository<User>
    {
        Task<User> LoginAsync(string url, User objToUser);
        Task<bool> RegisterAsync(string url, User objToUser);
    }
}
