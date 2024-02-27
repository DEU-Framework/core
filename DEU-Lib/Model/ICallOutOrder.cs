using Microsoft.EntityFrameworkCore;

namespace DEU_Lib.Model
{
    public interface ICallOutOrder
    {
        string OperationTypeId { get; set; }
        OperationType? OperationType { get; set; }
        int DepartmentId { get; set; }
        Department? Department { get; set; }
        ICollection<Vehicle> Vehicles { get; set; }
    }

    [PrimaryKey(nameof(OperationTypeId), nameof(DepartmentId))]
    public class CallOutOrder : ICallOutOrder
    {
        required public string OperationTypeId { get; set; }
        public OperationType? OperationType { get; set; }
        required public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = [];
    }
}