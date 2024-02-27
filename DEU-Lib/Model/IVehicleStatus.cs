namespace DEU_Lib.Model
{
    public interface IVehicleStatus
    {
        Guid VehicleStatusId { get; set; }
        /// <summary>
        /// The VehicleId for the Vehicle that the status is for
        /// </summary>
        int VehicleId { get; set; }
        /// <summary>
        /// The Vehicle that the status is for
        /// </summary>
        Vehicle? Vehicle { get; set; }
        /// <summary>
        /// The status of the vehicle
        /// </summary>
        string Status { get; set; }
        /// <summary>
        /// The description of the status
        /// </summary>
        string? StatusDescription { get; set; }
        /// <summary>
        /// The timestamp of the status
        /// </summary>
        DateTime TimeStamp { get; set; }
        /// <summary>
        /// The latitude of the vehicle
        /// </summary>
        double? Latitude { get; set; }
        /// <summary>
        /// The longitude of the vehicle
        /// </summary>
        double? Longitude { get; set; }
    }

    public class VehicleStatus : IVehicleStatus
    {
        public Guid VehicleStatusId { get; set; } = Guid.NewGuid();
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? StatusDescription { get; set; }
        public DateTime TimeStamp { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}