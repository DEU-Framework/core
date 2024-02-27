namespace DEU_Lib.Model
{
    public interface IWaKaWaterSource
    {
        Guid WaKaWaterSourceId { get; set; }
        /// <summary>
        /// Source ID from the WaKa Provider
        /// </summary>
        string SourceWaKaWaterSourceId { get; set; }
        /// <summary>
        /// Name of the water source
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Source type (e.g. "Hydrant")
        /// </summary>
        string SourceType { get; set; }
        /// <summary>
        /// Description/Info of the water source
        /// </summary>
        string? Description { get; set; }
        /// <summary>
        /// full Address of the water source
        /// </summary>
        string? Address { get; set; }
        /// <summary>
        /// URL to the icon of the water source
        /// </summary>
        string? IconUrl { get; set; }
        /// <summary>
        /// Icon width and height in pixels
        /// </summary>
        double IconWidth { get; set; }
        /// <summary>
        /// Icon width and height in pixels
        /// </summary>
        double IconHeight { get; set; }
        /// <summary>
        /// Icon anchor point in pixels
        /// </summary>
        double IconAnchorX { get; set; }
        /// <summary>
        /// Icon anchor point in pixels
        /// </summary>
        double IconAnchorY { get; set; }
        /// <summary>
        /// Longitude of the water source
        /// </summary>
        double Longitude { get; set; }
        /// <summary>
        /// Latitude of the water source
        /// </summary>
        double Latitude { get; set; }
        /// <summary>
        /// Capacity in cubic meters
        /// </summary>
        int Capacity { get; set; }
        /// <summary>
        /// Flowrate in liters per minute
        /// </summary>
        int Flowrate { get; set; }
        /// <summary>
        /// Outlets for hoses (e.g. 2x C, 1x B, 1x A)
        /// </summary>
        string? Connections { get; set; }
        /// <summary>
        /// The DepartmentId for the Department that the water source is for
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// The Department that the water source is for
        /// </summary>
        public Department? Department { get; set; }
    }

    public class WaKaWaterSource : IWaKaWaterSource
    {
        public Guid WaKaWaterSourceId { get; set; } = Guid.NewGuid();
        public string SourceWaKaWaterSourceId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SourceType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? IconUrl { get; set; }
        public double IconWidth { get; set; }
        public double IconHeight { get; set; }
        public double IconAnchorX { get; set; }
        public double IconAnchorY { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int Capacity { get; set; }
        public int Flowrate { get; set; }
        public string? Connections { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
