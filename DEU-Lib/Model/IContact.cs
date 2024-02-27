namespace DEU_Lib.Model
{
    public interface IContact
    {
        Guid ContactId { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string? Address { get; set; }
        string? Infos { get; set; }
        string? SirenCode { get; set; }
        bool IsSpecialDepartment { get; set; }

        int DepartmentId { get; set; }
        Department? Department { get; set; }
    }

    public class Contact : IContact
    {
        required public Guid ContactId { get; set; } = Guid.NewGuid();
        required public string Name { get; set; }
        required public string PhoneNumber { get; set; }
        required public string Email { get; set; }
        public string? Address { get; set; }
        public string? Infos { get; set; }
        public string? SirenCode { get; set; }
        required public bool IsSpecialDepartment { get; set; }

        required public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}