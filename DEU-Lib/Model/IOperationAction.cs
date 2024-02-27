namespace DEU_Lib.Model
{
    public interface IOperationAction
    {
        Guid OperationActionId { get; set; }
        /// <summary>
        /// The name of the action
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The description of the action
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// The date the action was done
        /// </summary>
        DateTime ActionDate { get; set; }
        /// <summary>
        /// The OperationId for the Operation that the action is part of
        /// </summary>
        string OperationId { get; set; }
        /// <summary>
        /// The Operation that the action is part of
        /// </summary>
        Operation? Operation { get; set; }
        /// <summary>
        /// The files that are associated with the action
        /// </summary>
        ICollection<File>? Files { get; set; }
        /// <summary>
        /// The users that posted the action
        /// </summary>
        string UserId { get; set; }
        /// <summary>
        /// The department the user is part of that posted the action
        /// </summary>
        string DepartmentName { get; set; }
    }

    public class OperationAction : IOperationAction
    {
        public Guid OperationActionId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public string OperationId { get; set; } = string.Empty;
        public Operation? Operation { get; set; }
        public ICollection<File>? Files { get; set; }
        required public string UserId { get; set; } 
        required public string DepartmentName { get; set; }
    }
}