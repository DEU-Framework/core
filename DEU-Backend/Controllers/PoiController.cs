using AutoMapper;
using DEU_Backend.DTOs;
using DEU_Backend.Services;
using DEU_Lib.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEU_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoiController(PoiService poiService, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Get all POIs for a Department from the database with pagination. Returns all POIs if page and pageSize are not set.
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Number of items per page</param>
        /// <returns>
        /// List of POIs
        /// </returns>
        /// <response code="200">Returns the list of POIs</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<PoiDTO>?>> GetAsync(int departmentId, int page = 0, int pageSize = 0)
        {
            var data = await poiService.GetAsync(departmentId, page, pageSize);
            return Ok(mapper.Map<List<PoiDTO>>(data));
        }

        /// <summary>
        /// Get a POI by its ID for the Department
        /// </summary>
        /// <param name="id">ID of the POI</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// POI
        /// </returns>
        /// <response code="200">Returns the POI</response>
        /// <response code="404">POI not found</response>
        /// <response code="404">Department not found</response>
        /// <response code="404">POI is not for the Department</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PoiDTO>> GetByIdAsync(Guid id, int departmentId)
        {
            var data = await poiService.GetByIdAsync(departmentId, id);
            return Ok(mapper.Map<PoiDTO>(data));
        }

        /// <summary>
        /// Create a new POI for a Department
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="poi">POI to create</param>
        /// <returns>
        /// Created POI
        /// </returns>
        /// <response code="200">Returns the created POI</response>
        /// <response code="400">Invalid POI</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<PoiDTO>> CreateAsync(int departmentId, Poi poi)
        {
            var data = await poiService.CreateAsync(departmentId, poi);
            return Ok(mapper.Map<PoiDTO>(data));
        }
    }
}