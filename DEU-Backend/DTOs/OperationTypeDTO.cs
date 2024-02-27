namespace DEU_Backend.DTOs
{
    public class OperationSubTypeDTO
    {
        public required string OperationSubTypeId { get; set; }
        public required string Name { get; set; }
    }

    public class OperationTypeDTO
    {
        public required string OperationTypeId { get; set; }
        public required string Name { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}