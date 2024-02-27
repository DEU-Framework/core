using Microsoft.EntityFrameworkCore;
namespace DEU_Lib.Model
{
    public interface IOperationChecklist
    {
        string OperationId { get; set; }
        Operation? Operation { get; set; }
        Guid ChecklistId { get; set; }
        Checklist? Checklist { get; set; }
    }

    [PrimaryKey(nameof(ChecklistId), nameof(OperationId))]
    public class OperationChecklist : IOperationChecklist
    {
        public required string OperationId { get; set; }
        public Operation? Operation { get; set; }
        public required Guid ChecklistId { get; set; }
        public Checklist? Checklist { get; set; }
    }
}
