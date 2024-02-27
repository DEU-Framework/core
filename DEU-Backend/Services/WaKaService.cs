using DEU_Lib.Model;
using Microsoft.EntityFrameworkCore;

namespace DEU_Backend.Services
{
    public class WaKaService
    {
        private readonly DeuDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly CustomServiceImplFetcherService _fetcherService;

        public WaKaService(DeuDbContext dbContext, IConfiguration configuration, CustomServiceImplFetcherService fetcherService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _fetcherService = fetcherService;
        }

        /// <summary>
        /// Fetch WaKa POIs from the WaKa data fetch service and update the database
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<WaKaWaterSource>> FetchAndUpdateWaKaDataAsync(int departmentId)
        {
            CustomServiceImplFetcherService _customServiceImplFetcherService = new CustomServiceImplFetcherService(_configuration);
            var wakaService = _customServiceImplFetcherService.GetWaKaDataFetchService();

            //Get config path from config
            var configPath = _configuration.GetSection("ConfigPaths").GetSection("WaKaDataFetchServiceConfigPath").Value ?? throw new Exception("Config path for WaKa data fetch service not found");
            var data = await wakaService.FetchDataAsync(configPath, 48.3700241, 14.5150614); //TODO: Get coordinates from config or database

            //Delete old WaKa POIs where SourceWaKaWaterSourceId is not in the new list
            var oldWaKaPOIs = await _dbContext.WaKaWaterSources.Where(p => !data.Select(d => d.SourceWaKaWaterSourceId).Contains(p.SourceWaKaWaterSourceId)).ToListAsync();
            _dbContext.WaKaWaterSources.RemoveRange(oldWaKaPOIs);

            //Add or update WaKa POIs
            foreach (var poi in data)
            {
                poi.DepartmentId = departmentId;
                var poiInDb = await _dbContext.WaKaWaterSources.FirstOrDefaultAsync(p => p.SourceWaKaWaterSourceId == poi.SourceWaKaWaterSourceId);
                if (poiInDb == null)
                {
                    await _dbContext.WaKaWaterSources.AddAsync((WaKaWaterSource)poi);
                }
                else
                {
                    poiInDb.Address = poi.Address;
                    poiInDb.Capacity = poi.Capacity;
                    poiInDb.Connections = poi.Connections;
                    poiInDb.Description = poi.Description;
                    poiInDb.Flowrate = poi.Flowrate;
                    poiInDb.IconAnchorX = poi.IconAnchorX;
                    poiInDb.IconAnchorY = poi.IconAnchorY;
                    poiInDb.IconHeight = poi.IconHeight;
                    poiInDb.IconUrl = poi.IconUrl;
                    poiInDb.IconWidth = poi.IconWidth;
                    poiInDb.Latitude = poi.Latitude;
                    poiInDb.Longitude = poi.Longitude;
                    poiInDb.Name = poi.Name;
                    poiInDb.SourceType = poi.SourceType;
                }
            }

            await _dbContext.SaveChangesAsync();

            return await GetAsync(departmentId);
        }

        /// <summary>
        /// Get all WaKa POIs for a Deaprtment from the database with pagination. Returns all POIs if page and pageSize are not set.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// List of WaKa POIs
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        public async Task<List<WaKaWaterSource>> GetAsync(int departmentId, int page = 0, int pageSize = 0)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            var query = _dbContext.WaKaWaterSources.Where(p => p.DepartmentId == departmentId);

            if (page > 0 && pageSize > 0)
                query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Get a WaKa POI by its ID for the Department
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="id">ID of the WaKa POI</param>
        /// <returns>
        /// WaKa POI
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        /// <exception cref="Exception">Thrown if WaKa POI not found</exception>
        public async Task<WaKaWaterSource> GetByIdAsync(int departmentId, Guid id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            var data = await _dbContext.WaKaWaterSources.FirstOrDefaultAsync(p => p.WaKaWaterSourceId == id) ?? throw new Exception("WaKa POI not found");
            return data;
        }
    }
}
