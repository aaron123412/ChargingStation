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
    }
}
