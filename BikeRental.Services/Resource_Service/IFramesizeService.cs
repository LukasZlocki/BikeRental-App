using BikeRental.Models.Models;

namespace BikeRental.Services.Resource_Service
{
    public interface IFramesizeService
    {
        public List<FrameSize> GetAllFramesizes();
        public FrameSize GetFrameSizeById(int id);
    }
}
