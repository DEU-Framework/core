namespace DEU_Lib.Model
{
    public interface IPoi
    {
        Guid PoiId { get; set; }
        /// <summary>
        /// The name of the POI
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The description of the POI
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// The latitude of the POI
        /// </summary>
        double Latitude { get; set; }
        /// <summary>
        /// The longitude of the POI
        /// </summary>
        double Longitude { get; set; }
        /// <summary>
        /// Icon of the POI
        /// </summary>
        string Icon { get; set; }
        /// <summary>
        /// DepartmentId for the department that the POI is part of
        /// </summary>
        int DepartmentId { get; set; }
        /// <summary>
        /// The department that the POI is part of
        /// </summary>
        Department? Department { get; set; }
        /// <summary>
        /// The files that are associated with the POI
        /// </summary>
        ICollection<File>? Files { get; set; }
    }

    public class Poi : IPoi
    {
        public Guid PoiId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Icon { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<File>? Files { get; set; }
    }
}