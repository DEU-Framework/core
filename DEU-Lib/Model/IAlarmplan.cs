using Microsoft.EntityFrameworkCore;

namespace DEU_Lib.Model
{
    public interface IAlarmplan
    {
        Guid AlarmplanId { get; set; }
        string OperationTypeId { get; set; }
        OperationType? OperationType { get; set; }
        int DepartmentId { get; set; }
        Department? Department { get; set; }
        string ZoneId { get; set; }
        ICollection<AlarmplanEntry> AlarmplanEntries { get; set; }
    }

    public class Alarmplan : IAlarmplan
    {
        required public Guid AlarmplanId { get; set; }
        required public string OperationTypeId { get; set; }
        public OperationType? OperationType { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        required public string ZoneId { get; set; }
        public ICollection<AlarmplanEntry> AlarmplanEntries { get; set; } = [];
    }
}