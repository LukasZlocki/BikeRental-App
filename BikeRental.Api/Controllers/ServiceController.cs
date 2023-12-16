using BikeRental.Models.Models;
using BikeRental.Services.Resource_Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Api.Controllers
{
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly ResourceService _dbResource;

        public ServiceController(ResourceService dbResource)
        {
            _dbResource = dbResource;
        }

        // GET
        [HttpGet("api/service")]
        public IActionResult GetAllBikesInService()
        {
            var service = _dbResource.GetAllBikes()
                .Where(i => i.IsInService == true)
                .ToList();
           return Ok(service);
        }

        // PATCH
        [HttpPatch("api/service/done")]
        public IActionResult FinishBicycleServiceByBicycleId([FromBody] Bicycle bicycle)
        {
            var service = _dbResource.UpdateBikeData(bicycle);
            return Ok(service);
        }

        // POST
        [HttpPost("api/service/create/bicycle")]
        public IActionResult CreateNewBicycle([FromBody] Bicycle bicycle)
        {
            var service = _dbResource.CeateNewBike(bicycle);
            return Ok(service);
        }
    }
}
