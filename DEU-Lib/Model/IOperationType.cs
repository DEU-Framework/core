namespace DEU_Lib.Model
{
    public interface IOperationType
    {
        string OperationTypeId { get; set; }
        /// <summary>
        /// The name of the OperationType like V1-PERS-PKW
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The Operations that are of this OperationType like Personenrettung Verkehrsunfall PKW
        /// </summary>
        ICollection<OperationTypeHistory> Operations { get; set; }
        /// <summary>
        /// The color of the OperationType
        /// </summary>
        string Color { get; set; }
        /// <summary>
        /// checklists that are associated with the operation
        /// </summary>
        ICollection<Checklist> Checklists { get; set; }
        /// <summary>
        /// The Alarmplans that are associated with the OperationType
        /// </summary>
        ICollection<Alarmplan> Alarmplans { get; set; }
    }

    public class OperationType : IOperationType
    {
        public required string OperationTypeId { get; set; }
        public required string Name { get; set; }
        public ICollection<OperationTypeHistory> Operations { get; set; } = [];
        public string Color { get; set; } = string.Empty;
        public ICollection<Checklist> Checklists { get; set; } = [];
        public ICollection<Alarmplan> Alarmplans { get; set; } = [];
    }

    public interface IOperationSubType
    {
        /// <summary>
        /// The OperationSubTypeId for the OperationSubType like PERSPKW-VU
        /// </summary>
        string OperationSubTypeId { get; set; }
        /// <summary>
        /// The name of the OperationSubType like Personenrettung Verkehrsunfall PKW
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The Operations that are of this OperationSubType
        /// </summary>
        ICollection<OperationTypeHistory> Operations { get; set; }
    }

    public class OperationSubType : IOperationSubType
    {
        public required string OperationSubTypeId { get; set; }
        public required string Name { get; set; }
        public ICollection<OperationTypeHistory> Operations { get; set; } = [];
    }
}