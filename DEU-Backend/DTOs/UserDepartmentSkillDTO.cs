using DEU_Lib.Model;

namespace DEU_Backend.DTOs
{
    public class UserDepartmentSkillDTO
    {
        public int UserDepartmentSkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public string? SkillDescription { get; set; }
    }
}