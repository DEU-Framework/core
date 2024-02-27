using DEU_Lib.Model;

namespace DEU_Backend.DTOs
{
    public class OperationDTO
    {
        public required string OperationId { get; set; }
        public string Level { get; set; } = "0";
        public string District { get; set; } = "OTHER";
        public string Municipal { get; set; } = "OTHER";
        public string Location { get; set; } = string.Empty;
        public double Latitude { get; set; } = 0.0;
        public double Longitude { get; set; } = 0.0;
        public string Zone { get; set; } = string.Empty;
        public bool Exercise { get; set; } = false;
        public bool Public { get; set; } = true;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public string CallerName { get; set; } = string.Empty;
        public string CallerPhone { get; set; } = string.Empty;
        required public string TypeId { get; set; }
        public OperationTypeDTO? Type { get; set; }
        required public string SubTypeId { get; set; }
        public OperationSubTypeDTO? SubType { get; set; }
        public ICollection<OperationResponseDTO>? RespondedDepartments { get; set; } = [];
        public ICollection<OperationActionDTO>? Actions { get; set; } = [];
    }
}