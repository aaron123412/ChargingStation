using ChargingStationAPI.Models;
using ChargingStationAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChargingStationAPI.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = _userRepo.Authenticate(model.Username, model.Password);

            if (user is null)
            {
                return BadRequest(new { message = "Username or password is incorect." });
            }

            user.Password = "";

            return Ok(user);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] AuthenticationModel model)
        {
            var isUserUnique = _userRepo.IsUserUnique(model.Username);
            if (isUserUnique is false)
            {
                return BadRequest(new { message = $"Username: {model.Username} already exists!" });
            }

            var user = _userRepo.Register(model.Username, model.Password);
            if (user is null)
            {
                ModelState.AddModelError("", $"Something went wrong while registing user {model.Username}!");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return Created("", user);
        }
    }
}
