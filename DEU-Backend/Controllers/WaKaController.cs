using AutoMapper;
using DEU_Backend.DTOs;
using DEU_Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEU_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaKaController(WaKaService waKaService, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Fetch WaKa POIs for Department from WaKa service and store/update them in the database and remove old POIs from the database that are not in the new list.
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// List of WaKa POIs
        /// </returns>
        /// <response code="200">Returns the list of WaKa POIs</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("fetchWaKaFromService")]
        public async Task<ActionResult<List<WaKaWaterSourceDTO>>> FetchWaKaFromServiceAsync(int departmentId)
        {
            var data = await waKaService.FetchAndUpdateWaKaDataAsync(departmentId);
            return Ok(mapper.Map<List<WaKaWaterSourceDTO>>(data));
        }

        /// <summary>
        /// Get all WaKa for a Department from the database with pagination. Returns all WaKa POIs if page and pageSize are not set.
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Number of items per page</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// List of WaKa POIs
        /// </returns>
        /// <response code="200">Returns the list of WaKa POIs</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<WaKaWaterSourceDTO>>> GetAsync(int departmentId, int page = 0, int pageSize = 0)
        {
            var data = await waKaService.GetAsync(departmentId, page, pageSize);
            return Ok(mapper.Map<List<WaKaWaterSourceDTO>>(data));
        }

        /// <summary>
        /// Get a WaKa POI by its ID for the Department
        /// </summary>
        /// <param name="id">ID of the WaKa POI</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// WaKa POI
        /// </returns>
        /// <response code="200">Returns the WaKa POI</response>
        /// <response code="404">WaKa POI not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult<WaKaWaterSourceDTO>> GetByIdAsync(Guid id, int departmentId)
        {
            var data = await waKaService.GetByIdAsync(departmentId, id);
            return Ok(mapper.Map<WaKaWaterSourceDTO>(data));
        }
    }
}
