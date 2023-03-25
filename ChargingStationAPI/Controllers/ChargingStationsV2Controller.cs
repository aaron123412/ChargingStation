using AutoMapper;
using ChargingStationAPI.Models.Dtos;
using ChargingStationAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChargingStationAPI.Controllers
{
    [Route("api/v{version:apiVersion}/chargingstations")]
    [ApiController]
    [ApiVersion("2.0")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public class ChargingStationsV2Controller : ControllerBase
    {
        private readonly IChargingStationRepository _ctRepo;
        private readonly IMapper _mapper;

        public ChargingStationsV2Controller(IChargingStationRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Charging Station
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ChargingStationDto>))]
        public IActionResult GetChargingStations()
        {
            var objList = _ctRepo.GetChargingStations();

            var objDto = new List<ChargingStationDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ChargingStationDto>(obj));
            }

            return Ok(objDto);
        }
    }
}
