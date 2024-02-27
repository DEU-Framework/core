using DEU_Lib.Model;
using Microsoft.EntityFrameworkCore;

namespace DEU_Backend.Services
{
    public class VehicleService(DeuDbContext dbContext)
    {
        private readonly DeuDbContext _dbContext = dbContext;

        /// <summary>
        /// Get all Vehicles for a Department from the database with pagination. Returns all Vehicles if page and pageSize are not set.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// List of Vehicles
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        public async Task<List<Vehicle>> GetAsync(int departmentId, int page = 0, int pageSize = 0)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            //TODO: dont include the department in the response
            if (page <= 0 || pageSize <= 0)
            {
                var data = await _dbContext.Vehicles.Where(v => v.DepartmentId == departmentId).ToListAsync();
                if (data.Count == 0)
                    return [];
                return data;
            }
            else
            {
                var data = await _dbContext.Vehicles.Where(v => v.DepartmentId == departmentId).Skip(page * pageSize).Take(pageSize).ToListAsync();
                if (data.Count == 0)
                    return [];
                return data;
            }
        }

        /// <summary>
        /// Get a Vehicle by its ID for the Department
        /// </summary>
        /// <param name="id">ID of the Vehicle</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// Vehicle
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        /// <exception cref="Exception">Thrown if Vehicle not found</exception>
        public async Task<Vehicle> GetByIdAsync(int id, int departmentId)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            var data = await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == id) ?? throw new Exception("Vehicle not found");
            if (data.DepartmentId != departmentId)
                throw new Exception("Vehicle is not for the Department");
            return data;
        }

        /// <summary>
        /// Create a new Vehicle for a Department
        /// </summary>
        /// <param name="vehicle">Vehicle to create</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// Created Vehicle
        /// </returns>
        /// <exception cref="ArgumentException">Vehicle already exists</exception>
        /// <exception cref="ArgumentNullException">Vehicle is null</exception>
        /// <exception cref="Exception">Internal Server Error</exception>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        /// <exception cref="Exception">Thrown if Vehicle is not for the Department</exception>
        public async Task<Vehicle> CreateAsync(Vehicle vehicle, int departmentId)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            if (await _dbContext.Vehicles.AnyAsync(v => v.VehicleId == vehicle.VehicleId))
                throw new ArgumentException("Vehicle already exists");

            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            if (vehicle.DepartmentId != departmentId)
                throw new Exception("Vehicle is not for the Department");

            await _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();

            return vehicle;
        }

        /// <summary>
        /// Get Vehicles by their Department
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// List of Vehicles
        /// </returns>
        public async Task<List<Vehicle>> GetByDepartmentAsync(int departmentId)
        {
            var data = await _dbContext.Vehicles.Where(v => v.DepartmentId == departmentId).ToListAsync();
            if (data.Count == 0)
                return [];

            return data;
        }
    }
}