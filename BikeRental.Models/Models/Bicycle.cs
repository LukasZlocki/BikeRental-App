namespace BikeRental.Models.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? ModelName { get; set; }
        public int FrameSizeId { get; set; }
        public FrameSize? FrameSize { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime StartService { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsInService { get; set; }
        public bool IsRent { get; set; }
    }
}