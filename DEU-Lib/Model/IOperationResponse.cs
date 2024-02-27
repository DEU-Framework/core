using Microsoft.EntityFrameworkCore;

namespace DEU_Lib.Model
{
    public interface IOperationResponse
    {
        /// <summary>
        /// The id of the Operation that the response is for
        /// </summary>
        string OperationId { get; set; }
        /// <summary>
        /// The Operation that the response is for
        /// </summary>
        Operation? Operation { get; set; }
        /// <summary>
        /// The id of the Department that the response is for
        /// </summary>
        int DepartmentId { get; set; }
        /// <summary>
        /// The Department that the response is for
        /// </summary>
        Department? Department { get; set; }
        /// <summary>
        /// The vehicles that are part of the response
        /// </summary>
        ICollection<Vehicle> Vehicles { get; set; }
        /// <summary>
        /// The time that the unit was dispatched
        /// </summary>
        DateTime DispatchTime { get; set; }
        /// <summary>
        /// The time that the unit was alerted
        /// </summary>
        DateTime? AlertTime { get; set; }
        /// <summary>
        /// The time that the operation was accepted
        /// </summary>
        DateTime? AcceptedTime { get; set; }
        /// <summary>
        /// The time that the unit was enroute
        /// </summary>
        DateTime? EnrouteTime { get; set; }
        /// <summary>
        /// The time that the unit arrived
        /// </summary>
        DateTime? ArriveTime { get; set; }
        /// <summary>
        /// The time that the unit was freed
        /// </summary>
        DateTime? FreeTime { get; set; }
        /// <summary>
        /// The status of the response
        /// </summary>
        OperationResponseStatus Status { get; set; }
        /// <summary>
        /// The users that are part of the response
        /// </summary>
        ICollection<UserOperationResponse> UserResponses { get; set; }
    }

    [PrimaryKey(nameof(DepartmentId), nameof(OperationId))]
    public class OperationResponse : IOperationResponse
    {
        public string OperationId { get; set; } = string.Empty;
        public Operation? Operation { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = [];
        public DateTime DispatchTime { get; set; }
        public DateTime? AlertTime { get; set; }
        public DateTime? AcceptedTime { get; set; }
        public DateTime? EnrouteTime { get; set; }
        public DateTime? ArriveTime { get; set; }
        public DateTime? FreeTime { get; set; }
        public OperationResponseStatus Status { get; set; }
        public ICollection<UserOperationResponse> UserResponses { get; set; } = [];
    }

    public enum OperationResponseStatus
    {
        Dispatched,
        Alerted,
        Accepted,
        Enroute,
        Arrived,
        Free
    }
}
