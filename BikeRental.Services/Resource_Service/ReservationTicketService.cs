using BikeRental.Models;
using BikeRental.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Services.Resource_Service
{
    public class ReservationTicketService : IReservationTicketService
    {
        private readonly RentalDbContext _db;
        public ReservationTicketService(RentalDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all reservation tickets.
        /// </summary>
        /// <returns>ReservationsTicket object.</returns>
        public List<ReservationTicket> GetAllReservations()
        {
            var service = _db.ReservationTickets
                .Include(b => b.Bicycle) 
                    .ToList();
            return service;
        }

        /// <summary>
        /// Returns reservation ticket by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ReservationTicket object.</returns>
        public ReservationTicket GetReservationById(int id)
        {
            var service = _db.ReservationTickets
                .Include(bi => bi.Bicycle)
                    .Include(ca => ca.Bicycle != null ? ca.Bicycle.Category : null)
                            .FirstOrDefault(x => x.Id == id);

            if (service == null)
            {
                return new ReservationTicket();
            }
            if (service.Bicycle == null)
            {
                service.Bicycle = new Bicycle();
            }
            if (service.Bicycle.Category == null)
            {
                service.Bicycle.Category = new Category();
            }
            return service;
        }

        /// <summary>
        /// Create reservation ticket.
        /// </summary>
        /// <param name="reservation">ReservationTicket object.</param>
        /// <returns>ResponseService object.</returns>
        public ResponseService<ReservationTicket> CreateReservationTicket(ReservationTicket reservation)
        {
            try
            {
                _db.ReservationTickets.Add(reservation);
                // Add
                _db.SaveChanges();
                return new ResponseService<ReservationTicket>
                {
                    IsSucess = true,
                    Message = "Order added.",
                    Time = DateTime.UtcNow,
                    Data = reservation
                };
            }
            catch (Exception e)
            {
                return new ResponseService<ReservationTicket>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = reservation
                };
            }
        }

        /// <summary>
        /// Delete reservation ticket by its id.
        /// </summary>
        /// <param name="id">ReservationTicket id.</param>
        /// <returns>ResponseService object.</returns>
        public ResponseService<ReservationTicket> DeleteReservationTicket(int id)
        {
            var reservation = _db.ReservationTickets.Find(id);
            if(reservation == null)
            {
                return new ResponseService<ReservationTicket>
                {
                    IsSucess = false,
                    Message = "No reservation ticket found.",
                    Time = DateTime.UtcNow,
                    Data = reservation
                };
            }
            try
            {
                _db.ReservationTickets.Remove(reservation);
                // delete
                _db.SaveChanges();
                return new ResponseService<ReservationTicket>
                {
                    IsSucess = true,
                    Message = "reservation deleted.",
                    Time = DateTime.UtcNow,
                    Data = reservation
                };
            }
            catch (Exception e)
            {
                return new ResponseService<ReservationTicket>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = reservation
                };
            }
        }
    }
}
