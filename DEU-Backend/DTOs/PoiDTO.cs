namespace DEU_Backend.DTOs
{
    public class PoiDTO
    {
        public Guid PoiId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Icon { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}