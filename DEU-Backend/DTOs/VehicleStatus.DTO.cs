namespace DEU_Backend.DTOs
{
    public class VehicleStatusDTO
    {
        public int VehicleStatusId { get; set; }
        public int VehicleId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? StatusDescription { get; set; }
        public DateTime TimeStamp { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}