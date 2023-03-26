using System.ComponentModel.DataAnnotations;

namespace ChargingStationWeb.Models
{
    public class ChargingStation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Infomation { get; set; }
        public int TotalChargerPorts { get; set; }
    }
}
