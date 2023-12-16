using BikeRental.Services.Resource_Service;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Api.Controllers
{
    public class FramesizeController : Controller
    {
        private readonly FramesizeService _dbFramesize;

        public FramesizeController(FramesizeService dbFramesize)
        {
            _dbFramesize = dbFramesize;
        }

        // GET
        [HttpGet("api/framesize")]
        public IActionResult GetAllFramesizes()
        {
            var frameSize = _dbFramesize.GetAllFramesizes().ToList();
            return Ok(frameSize);
        }

        // GET
        [HttpGet("api/framesize/{id}")]
        public IActionResult GetFramesizesById(int id)
        {
            var frameSize = _dbFramesize.GetFrameSizeById(id);
            return Ok(frameSize);
        }


    }
}
