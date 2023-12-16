using BikeRental.Models.Models;

namespace BikeRental.Services.Resource_Service
{
    public interface IResourceService
    {
        // CREATE
        public ResponseService<bool> CeateNewBike(Bicycle bicycle);
        // READ
        public List<Bicycle> GetAllBikes();
        public Bicycle GetBikeById(int id);
        public List<Bicycle> GetAllBikesReadyToRent();
        // UPDATE
        public ResponseService<bool> UpdateBikeData(Bicycle bicycle);
        // DELETE
        public ResponseService<bool> DeleteBike(int id);
    }
}