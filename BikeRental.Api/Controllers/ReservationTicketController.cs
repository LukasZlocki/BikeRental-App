using BikeRental.Models.Models;
using BikeRental.Services.Resource_Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Api.Controllers
{
    public class ReservationTicketController : Controller
    {
        private readonly ReservationTicketService _dbReservationTicket;

        public ReservationTicketController(ReservationTicketService dbReservationTicket)
        {
            _dbReservationTicket = dbReservationTicket;
        }

        // GET
        [HttpGet("api/reservationticket/{id}")]
        public IActionResult GetReservationTickedById(int id)
        {
            var reservation = _dbReservationTicket.GetReservationById(id);
            return Ok(reservation);
        }

        // GET
        [HttpGet("api/reservationticket")]
        public IActionResult GetAllReservationTickets()
        {
            var reservations = _dbReservationTicket.GetAllReservations();
            return Ok(reservations);
        }

        // POST
        [HttpPost("api/reservationticket/create")]
        public IActionResult CreateNewBicycle([FromBody] ReservationTicket reservation)
        {
            var service = _dbReservationTicket.CreateReservationTicket(reservation);
            return Ok(service);
        }

        // DELETE
        [HttpDelete("api/reservationticket/close/{id}")]
        public IActionResult DeleteReservationTicket(int id)
        {
            var service = _dbReservationTicket.DeleteReservationTicket(id);
            return Ok(service);
        }

    }
}
