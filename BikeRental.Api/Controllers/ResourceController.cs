using BikeRental.Models.Models;
using BikeRental.Services.Resource_Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Api.Controllers
{
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ResourceService _dbResource;

        public ResourceController(ResourceService dbResource)
        {
            _dbResource = dbResource;
        }

        // GET
        [HttpGet("api/bike")]
        public IActionResult GetAllBikes()
        {
            var _bicycles = _dbResource.GetAllBikes();
            return Ok(_bicycles);
        }

        // GET
        [HttpGet("Api/bike/rent")]
        public IActionResult GetAllBikesReadyToRent()
        {
            var service = _dbResource.GetAllBikesReadyToRent();
            return Ok(service);
        }

        // GET
        [HttpGet("api/bike/{id}")]
        public IActionResult GetBikeById(int id)
        {
            var service = _dbResource.GetBikeById(id);
            return Ok(service);
        }

        // PATCH
        [HttpPatch("api/bike/service/send")]
        public IActionResult SendBicycleToService([FromBody] Bicycle bicycle)
        {
            var service = _dbResource.UpdateBikeData(bicycle);
            return Ok(service);
        }

        // PATCH
        [HttpPatch("api/bike/update")]
        public IActionResult UpdateBikeData([FromBody] Bicycle bicycle)
        {
            var service = _dbResource.UpdateBikeData(bicycle);
            return Ok(service);
        }

        // DELETE
        [HttpDelete("api/bike/remove/{id}")]
        public IActionResult DeleteBike(int id)
        {
            var service = _dbResource.DeleteBike(id);
            return Ok(service);
        }

    }
}
