using System.ComponentModel.DataAnnotations;

namespace ChargingStationAPI.Models.Dtos
{
    public class ChargingStationUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
    }
}
