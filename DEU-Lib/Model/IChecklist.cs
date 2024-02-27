namespace DEU_Lib.Model
{
    public interface IChecklist
    {
        Guid ChecklistId { get; set; }
        /// <summary>
        /// The id of the OperationType that the checklist is for
        /// </summary>
        string OperationTypeId { get; set; }
        /// <summary>
        /// The OperationType that the checklist is for
        /// </summary>
        OperationType? OperationType { get; set; }
        /// <summary>
        /// The id of the Department that the checklist is for
        /// </summary>
        int DepartmentId { get; set; }
        /// <summary>
        /// The Department that the checklist is for
        /// </summary>
        Department? Department { get; set; }
        /// <summary>
        /// The tasks that are part of the checklist
        /// </summary>
        ICollection<ChecklistTask> Tasks { get; set; }
        /// <summary>
        /// Whether the checklist is a template
        /// </summary>
        bool IsTemplate { get; set; }
    }

    public class Checklist : IChecklist
    {
        public Guid ChecklistId { get; set; } = Guid.NewGuid();
        public required string OperationTypeId { get; set; }
        public OperationType? OperationType { get; set; }
        public required int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<ChecklistTask> Tasks { get; set; } = [];
        public bool IsTemplate { get; set; } = false;
    }
}
