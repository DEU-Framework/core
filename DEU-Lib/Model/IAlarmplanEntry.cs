namespace DEU_Lib.Model
{
    public interface IAlarmplanEntry
    {
        Guid AlarmplanEntryId { get; set; }
        Guid AlarmplanId { get; set; }
        Alarmplan? Alarmplan { get; set; }
        string VehicleName { get; set; }
        string Level { get; set; }
    }

    public class AlarmplanEntry : IAlarmplanEntry
    {
        required public Guid AlarmplanEntryId { get; set; }
        required public Guid AlarmplanId { get; set; }
        public Alarmplan? Alarmplan { get; set; }
        required public string VehicleName { get; set; }
        required public string Level { get; set; }
    }
}