using BikeRental.Models;
using BikeRental.Models.Models;

namespace BikeRental.Services.Resource_Service
{
    public class FramesizeService : IFramesizeService
    {
        private readonly RentalDbContext _db;

        public FramesizeService(RentalDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all frame sizes.
        /// </summary>
        /// <returns>List of FrameSize objects.</returns>
        public List<FrameSize> GetAllFramesizes()
        {
            var service = _db.FrameSizes.ToList();
            return service;
        }

        /// <summary>
        /// Returns frame size by FrameSize object id.
        /// </summary>
        /// <param name="id">FrameSize object id.</param>
        /// <returns>FrameSize object.</returns>
        public FrameSize GetFrameSizeById(int id)
        {
            var service = _db.FrameSizes.FirstOrDefault(x => x.Id == id);
            return service ?? new FrameSize();
        }
    }
}
