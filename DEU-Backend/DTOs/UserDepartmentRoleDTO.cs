using DEU_Lib.Model;

namespace DEU_Backend.DTOs
{
    public class UserDepartmentRoleDTO
    {
        public int UserDepartmentRoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public string? RoleDescription { get; set; }
    }
}