namespace DEU_Lib.Model
{
    public interface IVehicle
    {
        int VehicleId { get; set; }
        /// <summary>
        /// The DepartmentId for the department that the vehicle is part of
        /// </summary>
        int DepartmentId { get; set; }
        /// <summary>
        /// The department that the vehicle is part of
        /// </summary>
        Department? Department { get; set; }
        /// <summary>
        /// The name of the vehicle like Tanklöschfahrzeug 2000
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The short name of the vehicle like TLF 2000
        /// </summary>
        string? ShortName { get; set; }
        /// <summary>
        /// The call sign of the vehicle like TANK 1 Hagenberg
        string CallSign { get; set; }
        /// <summary>
        /// The statuses of the vehicle
        /// </summary>
        ICollection<VehicleStatus> Statuses { get; set; }
        /// <summary>
        /// The operation responses that the vehicle has
        /// </summary>
        ICollection<OperationResponse> OperationResponses { get; set; }
        /// <summary>
        /// Crew count
        /// </summary>
        int CrewCount { get; set; }
        /// <summary>
        /// Connected CallOutOrders
        /// </summary>
        ICollection<CallOutOrder> CallOutOrders { get; set; }
    }

    public class Vehicle : IVehicle
    {
        public int VehicleId { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortName { get; set; }
        public string CallSign { get; set; } = string.Empty;
        public ICollection<VehicleStatus> Statuses { get; set; } = [];
        public ICollection<OperationResponse> OperationResponses { get; set; } = [];
        public int CrewCount { get; set; }
        public ICollection<CallOutOrder> CallOutOrders { get; set; } = [];
    }
}
