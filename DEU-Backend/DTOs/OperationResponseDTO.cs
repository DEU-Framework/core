namespace DEU_Backend.DTOs
{
    public class OperationResponseDTO
    {
        public string OperationId { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public DateTime DispatchTime { get; set; }
        public DateTime? AlertTime { get; set; }
        public DateTime? AcceptedTime { get; set; }
        public DateTime? EnrouteTime { get; set; }
        public DateTime? ArriveTime { get; set; }
        public DateTime? FreeTime { get; set; }
    }
}