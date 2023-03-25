using ChargingStationAPI.Models;

namespace ChargingStationAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        public bool IsUserUnique(string username);
        public User Authenticate(string username, string password);
        public User Register(string username, string password);
    }
}
