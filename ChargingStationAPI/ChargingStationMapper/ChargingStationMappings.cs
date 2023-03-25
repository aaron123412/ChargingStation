using AutoMapper;
using ChargingStationAPI.Models;
using ChargingStationAPI.Models.Dtos;

namespace ChargingStationAPI.ChargingStationMapper
{
    public class ChargingStationMappings : Profile
    {
        public ChargingStationMappings()
        {
            CreateMap<ChargingStation, ChargingStationDto>().ReverseMap();
            CreateMap<ChargingStation, ChargingStationCreateDto>().ReverseMap();
            CreateMap<ChargingStation, ChargingStationUpdateDto>().ReverseMap();
        }
    }
}
