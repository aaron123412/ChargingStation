using AutoMapper;
using ChargingStationAPI.Models;
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public class ChargingStationsController : ControllerBase
    {
        private readonly IChargingStationRepository _ctRepo;
        private readonly IMapper _mapper;

        public ChargingStationsController(IChargingStationRepository ctRepo, IMapper mapper)
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
        [AllowAnonymous]
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

        /// <summary>
        /// Get individual Charging Station
        /// </summary>
        /// <param name="id">The Id of Charging Station</param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = nameof(GetChargingStation))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChargingStationDto))]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetChargingStation(int id)
        {
            var obj = _ctRepo.GetChargingStation(id);

            if (obj == null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<ChargingStationDto>(obj);

            return Ok(objDto);
        }

        /// <summary>
        /// Create a Charging Station
        /// </summary>
        /// <param name="objDto">The obj of Charging Station DTO</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ChargingStationDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateChargingStation([FromBody] ChargingStationCreateDto objDto)
        {
            if (objDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ctRepo.ChargingStationExists(objDto.Name))
            {
                ModelState.AddModelError("", "Charging Station Exists!");
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var obj = _mapper.Map<ChargingStation>(objDto);

            var status = _ctRepo.CreateChargingStation(obj);

            if (status == false)
            {
                ModelState.AddModelError("", $"Something went wrong while saving record {obj.Name}!");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return CreatedAtRoute(nameof(GetChargingStation), new { version = HttpContext.GetRequestedApiVersion().ToString(), id = obj.Id }, obj);
        }

        /// <summary>
        /// Update a Charging Station
        /// </summary>
        /// <param name="id">The Id of Charging Station</param>
        /// <param name="objDto">The obj of Charging Station DTO</param>
        /// <returns></returns>
        [HttpPatch("{id:int}", Name = nameof(UpdateChargingStation))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateChargingStation(int id, ChargingStationUpdateDto objDto)
        {
            if (objDto == null || id != objDto.Id)
            {
                return BadRequest(ModelState);
            }

            var obj = _mapper.Map<ChargingStation>(objDto);

            var status = _ctRepo.UpdateChargingStation(obj);

            if (!status)
            {
                ModelState.AddModelError("", $"Something went wrong while updating record {obj.Name}!");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a Charging Station
        /// </summary>
        /// <param name="id">The Id of Charging Station</param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = nameof(DeleteChargingStation))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteChargingStation(int id)
        {
            var obj = _ctRepo.GetChargingStation(id);

            if (obj == null)
            {
                return NotFound();
            }

            var status = _ctRepo.DeleteChargingStation(obj);

            if (!status)
            {
                ModelState.AddModelError("", $"Something went wrong while deleting record {obj.Name}!");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Get list of Charging Station by Province
        /// </summary>
        /// <param name="province">The Name of Province</param>
        /// <returns></returns>
        [HttpPost("[action]", Name = nameof(GetChargingStationByProvince))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ChargingStationDto>))]
        public IActionResult GetChargingStationByProvince([FromBody] string province)
        {
            if (province == null || province == "")
            {
                return BadRequest();
            }

            var objList = _ctRepo.GetChargingStationByProvince(province);
            var objDto = new List<ChargingStationDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ChargingStationDto>(obj));
            }

            return Ok(objDto);
        }
    }
}
