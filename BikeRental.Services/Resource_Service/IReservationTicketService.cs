using BikeRental.Models.Models;

namespace BikeRental.Services.Resource_Service
{
    public interface IReservationTicketService
    {
        public List<ReservationTicket> GetAllReservations();
        public ReservationTicket GetReservationById(int id);
        public ResponseService<ReservationTicket> CreateReservationTicket(ReservationTicket reservation);
        public ResponseService<ReservationTicket> DeleteReservationTicket(int id);
    }
}
