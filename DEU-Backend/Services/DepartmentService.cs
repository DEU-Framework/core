using DEU_Lib.Model;
using DEU_Lib.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DEU_Backend.Services
{
    public class DepartmentService(DeuDbContext dbContext, UserManager<ApplicationUser> userManager)
    {

        /// <summary>
        /// Get a Department by its ID
        /// </summary>
        /// <param name="id">ID of the Department</param>
        /// <returns>
        /// Department
        /// </returns>
        public async Task<Department?> GetByIdAsync(int id)
        {
            var data = await dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);
            if (data == null)
                return null;

            return data;
        }

        /// <summary>
        /// Create a new Department
        /// </summary>
        /// <param name="department">Department to create</param>
        /// <returns>
        /// Created Department
        /// </returns>
        /// <exception cref="ArgumentException">Department already exists</exception>
        /// <exception cref="ArgumentNullException">Department is null</exception>
        /// <exception cref="Exception">Internal Server Error</exception>
        public async Task<Department> CreateAsync(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department));

            if (await dbContext.Departments.AnyAsync(d => d.DepartmentId == department.DepartmentId))
                throw new ArgumentException("Department already exists");

            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();

            return department;
        }

        /// <summary>
        /// Add a user to a department
        /// </summary>
        /// <param name="userEmail">Email</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// User
        /// </returns>
        /// <exception cref="ArgumentException">User already exists in department</exception>
        /// <exception cref="ArgumentNullException">User or Department is null</exception>
        /// <exception cref="Exception">Internal Server Error</exception>
        public async Task<ApplicationUser> AddUserToDepartmentAsync(string userEmail, int departmentId)
        {
            if (string.IsNullOrEmpty(userEmail))
                throw new ArgumentNullException(nameof(userEmail));

            if (departmentId <= 0)
                throw new ArgumentNullException(nameof(departmentId));

            var user = await userManager.FindByEmailAsync(userEmail);
            if (user == null)
                throw new UserNotFoundException(userEmail);

            var department = await dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (department == null)
                throw new DepartmentNotFoundException(user.Id, departmentId);

            if (await dbContext.Departments.Include(d => d.Users).AnyAsync(d => d.Users.Any(u => u.UserId == user.Id)))
                throw new ArgumentException("User already exists in department");

            department.Users.Add(new ApplicationUserDepartmentSetting
            {
                DepartmentId = departmentId,
                UserId = user.Id,
                IsDefault = true,
            });
            await dbContext.SaveChangesAsync();

            return user;
        }

        //Get default department of user
        /// <summary>
        /// Get the default department of a user
        /// </summary>
        /// <param name="userId">userid</param>
        /// <returns>
        /// Department
        /// </returns>
        /// <exception cref="ArgumentException">User not found</exception>
        /// <exception cref="ArgumentNullException">User is null</exception>
        /// <exception cref="Exception">Internal Server Error</exception>
        public async Task<ApplicationUserDepartmentSetting> GetDefaultDepartmentOfUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            var department = await dbContext.ApplicationUserDepartmentSettings.Where(d => d.UserId == user.Id && d.IsDefault).Include(d => d.Roles).Include(d => d.Skills).Include(d => d.Department).FirstOrDefaultAsync();
            if (department == null)
                throw new DepartmentNotFoundException(user.Id, -1);

            return department;
        }
    }
}