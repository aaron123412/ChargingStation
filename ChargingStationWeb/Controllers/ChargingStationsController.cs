using ChargingStationWeb.Models;
using ChargingStationWeb.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChargingStationWeb.Controllers
{
    public class ChargingStationsController : Controller
    {
        readonly private IChargingStationRepository _ctRepo;
        public ChargingStationsController(IChargingStationRepository ctRepo)
        {
            _ctRepo = ctRepo;
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            return View(new ChargingStation());
        }

        public async Task<IActionResult> GetAllChargingStation()
        {
            return Json(new { data = await _ctRepo.GetAllAsync(SD.ChargingStationAPIPath, HttpContext.Session.GetString("JWToken")) });
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Upsert(int? id)
        {
            var obj = new ChargingStation();
            if (id == null)
            {
                return View(obj);
            }

            obj = await _ctRepo.GetAsync(SD.ChargingStationAPIPath, id.GetValueOrDefault(), HttpContext.Session.GetString("JWToken"));

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ChargingStation obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            if (obj.Id == 0)
            {
                await _ctRepo.CreateAsync(SD.ChargingStationAPIPath, obj, HttpContext.Session.GetString("JWToken"));
            }
            else
            {
                await _ctRepo.UpdateAsync(SD.ChargingStationAPIPath + obj.Id, obj, HttpContext.Session.GetString("JWToken"));
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _ctRepo.DeleteAsync(SD.ChargingStationAPIPath, id, HttpContext.Session.GetString("JWToken"));

            if (status)
            {
                return Json(new { success = true, message = "Delete successful!" });
            }
            return Json(new { success = false, message = "Delete not successful!" });
        }
    }
}
