namespace DEU_Backend.DTOs
{
    public class OperationActionDTO
    {
        public Guid OperationActionId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; }

        public string OperationId { get; set; } = string.Empty;
    }
}