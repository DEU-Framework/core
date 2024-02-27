namespace DEU_Backend.DTOs
{
    public class WaKaWaterSourceDTO
    {
        public Guid WaKaWaterSourceId { get; set; }
        public string SourceWaKaWaterSourceId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SourceType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? IconUrl { get; set; }
        public double IconWidth { get; set; }
        public double IconHeight { get; set; }
        public double IconAnchorX { get; set; }
        public double IconAnchorY { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int Capacity { get; set; }
        public int Flowrate { get; set; }
        public string? Connections { get; set; }
        public int DepartmentId { get; set; }
    }
}