using DEU_Lib.Model.Identity;

namespace DEU_Lib.Model
{
    public interface IUserOperationResponse
    {
        public Guid UserOperationResponseId { get; set; }
        public string OperationId { get; set; }
        public Operation? Operation { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime? AcceptedTime { get; set; }
    }

    public class UserOperationResponse : IUserOperationResponse
    {
        public Guid UserOperationResponseId { get; set; } = Guid.NewGuid();
        required public string OperationId { get; set; }
        public Operation? Operation { get; set; }
        required public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime? AcceptedTime { get; set; }
    }
}