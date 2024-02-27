using DEU_Lib.Model.Identity;

namespace DEU_Lib.Model
{
    public interface IDepartmentSettings
    {
        int DepartmentSettingsId { get; set; }
        //Flags
        bool UsesWaKa { get; set; }


    }

    public class DepartmentSettings : IDepartmentSettings
    {
        public int DepartmentSettingsId { get; set; }
        //Flags
        public bool UsesWaKa { get; set; }
    }
}
