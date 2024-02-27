namespace DEU_Lib.Model
{
    public interface IOperation
    {
        string OperationId { get; set; }
        /// <summary>
        /// The level of the operation
        /// </summary>
        string Level { get; set; }

        /// <summary>
        /// The district that the operation is in
        /// </summary>
        string District { get; set; }
        /// <summary>
        /// The municipality that the operation is ins
        /// </summary>
        string Municipal { get; set; }
        /// <summary>
        /// The location info of the operation
        /// </summary>
        string Location { get; set; }
        /// <summary>
        /// The latitude of the operation
        /// </summary>
        double Latitude { get; set; }
        /// <summary>
        /// The longitude of the operation
        /// </summary>
        double Longitude { get; set; }
        /// <summary>
        /// The zone of the operation
        /// </summary>
        string Zone { get; set; }

        /// <summary>
        /// Whether the operation is an exercise or not
        /// </summary>
        bool Exercise { get; set; }
        /// <summary>
        /// Whether the operation should be public or not
        /// </summary>
        bool Public { get; set; }

        /// <summary>
        /// The start date of the operation
        /// </summary>
        DateTime StartDate { get; set; }
        /// <summary>
        /// The end date of the operation
        /// </summary>
        DateTime? EndDate { get; set; }

        /// <summary>
        /// The name of the caller
        /// </summary>
        string CallerName { get; set; }
        /// <summary>
        /// The phone number of the caller
        /// </summary>
        string CallerPhone { get; set; }
        /// <summary>
        /// The departments that have responded to the operation
        /// </summary>
        ICollection<OperationResponse> RespondedDepartments { get; set; }

        /// <summary>
        /// The actions/messages that have been sent during the operation
        /// </summary>
        ICollection<OperationAction> Actions { get; set; }
        /// <summary>
        /// checklists that are associated with the operation
        /// </summary>
        ICollection<OperationChecklist> OperationChecklists { get; set; }
        /// <summary>
        /// Type History of the operation
        /// </summary>
        ICollection<OperationTypeHistory> OperationTypeHistories { get; set; }
    }

    public class Operation : IOperation
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
        public ICollection<OperationResponse> RespondedDepartments { get; set; } = [];
        public ICollection<OperationAction> Actions { get; set; } = [];
        public ICollection<OperationChecklist> OperationChecklists { get; set; } = [];
        public ICollection<OperationTypeHistory> OperationTypeHistories { get; set; } = [];
    }

    public interface IOperationTypeHistory
    {
        Guid OperationTypeHistoryId { get; set; }
        /// <summary>
        /// The OperationId for the Operation that the history is part of
        /// </summary>
        string OperationId { get; set; }
        /// <summary>
        /// The Operation that the history is part of
        /// </summary>
        Operation? Operation { get; set; }
        /// <summary>
        /// Level of the operation
        /// </summary>
        string Level { get; set; }
        /// <summary>
        /// The OperationTypeId for the OperationType that the operation is
        /// </summary>
        string TypeId { get; set; }
        /// <summary>
        /// The OperationType that the operation is like V1-PERS-PKW
        /// </summary>
        OperationType? Type { get; set; }
        /// <summary>
        /// The OperationTypeId for the OperationSubType that the operation is
        /// </summary>
        string SubTypeId { get; set; }
        /// <summary>
        /// The OperationSubType that the operation is like PERSPKW-VU
        /// </summary>
        OperationSubType? SubType { get; set; }
        /// <summary>
        /// The start date of the operation
        /// </summary>
        DateTime ChangeDate { get; set; }
    }

    public class OperationTypeHistory : IOperationTypeHistory
    {
        public Guid OperationTypeHistoryId { get; set; } = Guid.NewGuid();
        required public string OperationId { get; set; }
        public Operation? Operation { get; set; }
        public string Level { get; set; } = "0";
        required public string TypeId { get; set; }
        public OperationType? Type { get; set; }
        required public string SubTypeId { get; set; }
        public OperationSubType? SubType { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;
    }

}
