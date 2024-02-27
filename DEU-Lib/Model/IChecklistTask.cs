using System.Runtime.InteropServices;

namespace DEU_Lib.Model
{
    public interface IChecklistTask
    {
        Guid ChecklistTaskId { get; set; }
        /// <summary>
        /// The id of the Checklist that the task is part of
        /// </summary>
        Guid ChecklistId { get; set; }
        /// <summary>
        /// The Checklist that the task is part of
        /// </summary>
        Checklist? Checklist { get; set; }
        /// <summary>
        /// The name of the task
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The description of the task
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Whether the task is completed
        /// </summary>
        bool IsCompleted { get; set; }
        /// <summary>
        /// the userid of the user that completed the task
        /// </summary>
        string? CompletedBy { get; set; }
    }

    public class ChecklistTask : IChecklistTask
    {
        public Guid ChecklistTaskId { get; set; } = Guid.NewGuid();
        public required Guid ChecklistId { get; set; }
        public Checklist? Checklist { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public string? CompletedBy { get; set; }
    }
}
