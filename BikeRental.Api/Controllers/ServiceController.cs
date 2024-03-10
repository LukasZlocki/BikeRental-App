using BikeRental.Api.Hubs;
using BikeRental.Models.Models;
using BikeRental.Services.Resource_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

namespace BikeRental.Api.Controllers
{
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly ResourceService _dbResource;
        private readonly IHubContext<NotificationsHub, INotificationClient> _context;

        public ServiceController(ResourceService dbResource, IHubContext<NotificationsHub, INotificationClient> context)
        {
            _dbResource = dbResource;
            _context = context;
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
        [HttpPatch("api/service/toservice")]
        public IActionResult SendBicycleToService([FromBody] Bicycle bicycle)
        {
            bicycle.IsAvailable = false;
            bicycle.IsInService = true;
            bicycle.IsRent = false;

            var service = _dbResource.UpdateBikeData(bicycle);

            // Add client side message - update service page
            _context.Clients.All.ReceiveNotification($"RefreshServicePage");

            return Ok(service);
        }

        // PATCH
        [HttpPatch("api/service/done")]
        public  IActionResult FinishBicycleServiceByBicycleId([FromBody] Bicycle bicycle)
        {
            bicycle.IsAvailable = true;
            bicycle.IsInService = false;
            bicycle.IsRent = false;
            bicycle.StartService = DateTime.UtcNow.AddDays(30);

            var service = _dbResource.UpdateBikeData(bicycle);

            // add signalR message - update rental page
            _context.Clients.All.ReceiveNotification($"UpdateRentalPage");

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
