using Microsoft.EntityFrameworkCore;

namespace DEU_Backend.Services
{
    public class DepartmentAuthorizationService(DeuDbContext context)
    {
        public async Task<bool> IsUserAuthorizedForDepartmentAsync(string userId, int departmentId)
        {
            return await context.ApplicationUserDepartmentSettings
                .AnyAsync(d => d.DepartmentId == departmentId && d.UserId == userId);
        }
    }

}