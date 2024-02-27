namespace DEU_Backend
{

    public class DepartmentNotFoundException : Exception
    {
        public DepartmentNotFoundException(string userid, int departmentId) : base($"Department with ID {departmentId} not found for user {userid}")
        {
        }
    }


    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string userid) : base($"User with ID {userid} not found")
        {
        }
    }
}