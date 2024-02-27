using DEU_Lib.Model;
using Microsoft.EntityFrameworkCore;

namespace DEU_Backend.Services
{
    public class PoiService(DeuDbContext dbContext)
    {
        private readonly DeuDbContext _dbContext = dbContext;

        /// <summary>
        /// Get all POIs for the Department from the database with pagination. Returns all POIs if page and pageSize are not set.
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>
        /// List of POIs
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        public async Task<List<Poi>> GetAsync(int departmentId, int page = 0, int pageSize = 0)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            if (page <= 0 || pageSize <= 0)
            {
                var data = await _dbContext.Pois.Where(p => p.DepartmentId == departmentId).ToListAsync();
                if (data.Count == 0)
                    return [];
                return data;
            }
            else
            {
                var data = await _dbContext.Pois.Where(p => p.DepartmentId == departmentId).Skip(page * pageSize).Take(pageSize).ToListAsync();
                if (data.Count == 0)
                    return [];
                return data;
            }
        }

        /// <summary>
        /// Get a POI by its ID for the Department
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="id">ID of the POI</param>
        /// <returns>
        /// POI
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        /// <exception cref="Exception">Thrown if POI not found</exception>
        /// <exception cref="Exception">Thrown if POI is not for the Department</exception>
        public async Task<Poi?> GetByIdAsync(int departmentId, Guid id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            var data = await _dbContext.Pois.FirstOrDefaultAsync(p => p.PoiId == id) ?? throw new Exception("POI not found");
            if (data.DepartmentId != departmentId)
                throw new Exception("POI is not for the Department");
            return data;
        }

        /// <summary>
        /// Create a new POI
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="poi">POI</param>
        /// <returns>
        /// Created POI
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        /// <exception cref="ArgumentException">POI already exists</exception>
        /// <exception cref="ArgumentNullException">POI is null</exception>
        public async Task<Poi> CreateAsync(int departmentId, Poi poi)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            if (poi == null)
                throw new ArgumentNullException(nameof(poi));
            if (await _dbContext.Pois.AnyAsync(p => p.PoiId == poi.PoiId))
                throw new ArgumentException("POI already exists");
            poi.DepartmentId = departmentId;
            await _dbContext.Pois.AddAsync(poi);
            await _dbContext.SaveChangesAsync();
            return poi;
        }
    }
}