using DEU_Lib.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DEU_Backend.Services
{
    public class AuthService(DeuDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        /// <summary>
        /// Get user profile by user ID
        /// </summary>
        /// <param name="userId">ID of the user</param>
        /// <returns>
        /// User
        /// </returns>
        /// <exception cref="ArgumentException">User not found</exception>
        /// <exception cref="ArgumentNullException">User ID is null</exception>
        /// <exception cref="Exception">Internal Server Error</exception>
        public async Task<ApplicationUser> GetUserProfileByIdAsync(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                throw new UserNotFoundException(userId);

            return user;
        }

        //get user roles for department
        /// <summary>
        /// Get user roles for department
        /// </summary>
        /// <param name="userId">ID of the user</param>
        /// <param name="departmentId">ID of the department</param>
        /// <returns>
        /// List of roles
        /// </returns>
        /// <exception cref="ArgumentException">User not found</exception>
        /// <exception cref="ArgumentNullException">User ID is null</exception>
        /// <exception cref="Exception">Internal Server Error</exception>
        public async Task<ICollection<UserDepartmentRole>> GetUserRolesForDepartmentAsync(string userId, int departmentId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                throw new UserNotFoundException(userId);

            var roles = user.DepartmentSettings.FirstOrDefault(d => d.DepartmentId == departmentId)?.Roles;

            if (roles == null)
                throw new UserNotFoundException(userId);

            return roles;
        }
    }
}