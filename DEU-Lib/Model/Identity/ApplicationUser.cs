using DEU_Lib.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DEU_Lib.Model.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<ApplicationUserDepartmentSetting> DepartmentSettings { get; set; } = [];
    }

    [PrimaryKey(nameof(DepartmentId), nameof(UserId))]
    public class ApplicationUserDepartmentSetting
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public bool IsDefault { get; set; }
        public ICollection<UserDepartmentRole> Roles { get; set; } = [];
        public ICollection<UserDepartmentSkill> Skills { get; set; } = [];

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

    public class UserDepartmentSkill
    {
        public int UserDepartmentSkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public string? SkillDescription { get; set; }
        public ICollection<ApplicationUserDepartmentSetting> Users { get; set; } = [];
    }

    public class UserDepartmentRole
    {
        public int UserDepartmentRoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public string? RoleDescription { get; set; }
        public ICollection<ApplicationUserDepartmentSetting> Users { get; set; } = [];
    }
}