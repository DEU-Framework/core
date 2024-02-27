using DEU_Lib.Model;

namespace DEU_Backend.DTOs
{
    public class ApplicationUserDepartmentSettingDTO
    {
        public int DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public bool IsDefault { get; set; }
        //roles
        public ICollection<UserDepartmentRoleDTO> Roles { get; set; } = [];
        //skills
        public ICollection<UserDepartmentSkillDTO> Skills { get; set; } = [];

        /// <summary>
        /// Whether the user is a vehicle
        /// </summary>
        public bool IsVehicle { get; set; }
        /// <summary>
        /// The vehicle that the user is if IsVehicle is true
        /// </summary>
        public int? VehicleId { get; set; }
        /// <summary>
        /// The vehicle that the user is if IsVehicle is true
        /// </summary>
        public Vehicle? Vehicle { get; set; }
    }
}