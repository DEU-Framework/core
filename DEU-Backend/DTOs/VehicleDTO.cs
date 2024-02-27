namespace DEU_Backend.DTOs
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortName { get; set; }
        public string CallSign { get; set; } = string.Empty;
    }
}