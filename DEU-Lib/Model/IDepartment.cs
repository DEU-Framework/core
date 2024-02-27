using DEU_Lib.Model.Identity;

namespace DEU_Lib.Model
{
    public interface IDepartment
    {
        int DepartmentId { get; set; }
        /// <summary>
        /// The name of the department
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The short name of the department
        /// </summary>
        string? ShortName { get; set; }
        /// <summary>
        /// The phone number of the department
        /// </summary>
        string? PhoneNumber { get; set; }
        /// <summary>
        /// The email of the department
        /// </summary>
        string? Email { get; set; }
        /// <summary>
        /// The website of the department
        /// </summary>
        string? Website { get; set; }
        /// <summary>
        /// The full address of the department
        /// </summary>
        string Address { get; set; }
        /// <summary>
        /// The latitude of the department
        /// </summary>
        double Latitude { get; set; }
        /// <summary>
        /// The longitude of the department
        /// </summary>
        double Longitude { get; set; }
        /// <summary>
        /// The vehicles that the department has
        /// </summary>
        ICollection<Vehicle> Vehicles { get; set; }
        /// <summary>
        /// The operation responses that the department has
        /// </summary>
        ICollection<OperationResponse> OperationResponses { get; set; }
        /// <summary>
        /// The POIs that the department has
        /// </summary>
        ICollection<Poi> Pois { get; set; }
        /// <summary>
        /// The WakaWatersources that the department has
        /// </summary>
        ICollection<WaKaWaterSource> WakaWatersources { get; set; }
        /// <summary>
        /// The users that the department has
        /// </summary>
        ICollection<ApplicationUserDepartmentSetting> Users { get; set; }
        /// <summary>
        /// checklists that the department has
        /// </summary>
        ICollection<Checklist> Checklists { get; set; }
        /// <summary>
        /// The Alarmplans that the department has
        /// </summary>
        ICollection<Alarmplan> Alarmplans { get; set; }
        /// <summary>
        /// List of Contacts
        /// </summary>
        ICollection<Contact> Contacts { get; set; }

    }

    public class Department : IDepartment
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = [];
        public ICollection<OperationResponse> OperationResponses { get; set; } = [];
        public ICollection<Poi> Pois { get; set; } = [];
        public ICollection<WaKaWaterSource> WakaWatersources { get; set; } = [];
        public ICollection<ApplicationUserDepartmentSetting> Users { get; set; } = [];
        public ICollection<Checklist> Checklists { get; set; } = [];
        public ICollection<Alarmplan> Alarmplans { get; set; } = [];
        public ICollection<Contact> Contacts { get; set; } = [];
    }
}
