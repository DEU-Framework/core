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
    public class VehicleController(VehicleService vehicleService, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Get all Vehicles for Department from the database with pagination. Returns all Vehicles if page and pageSize are not set.
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Number of items per page</param>
        /// <returns>
        /// List of Vehicles
        /// </returns>
        /// <response code="200">Returns the list of Vehicles</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<VehicleDTO>>> GetAsync(int departmentId, int page = 0, int pageSize = 0)
        {
            var data = await vehicleService.GetAsync(departmentId, page, pageSize);
            return Ok(mapper.Map<List<VehicleDTO>>(data));
        }

        /// <summary>
        /// Get a Vehicle by its ID for the Department
        /// </summary>
        /// <param name="vehicleId">ID of the Vehicle</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// Vehicle
        /// </returns>
        /// <response code="200">Returns the Vehicle</response>
        /// <response code="404">Vehicle not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{vehicleId}")]
        public async Task<ActionResult<VehicleDTO>> GetByIdAsync(int vehicleId, int departmentId)
        {
            var data = await vehicleService.GetByIdAsync(vehicleId, departmentId);
            return Ok(mapper.Map<VehicleDTO>(data));
        }

        /// <summary>
        /// Create a new Vehicle for a Department
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="vehicle">Vehicle to create</param>
        /// <returns>
        /// Vehicle
        /// </returns>
        /// <response code="200">Returns the created Vehicle</response>
        /// <response code="400">Invalid Vehicle</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<VehicleDTO>> CreateAsync(int departmentId, VehicleDTO vehicle)
        {
            var data = await vehicleService.CreateAsync(mapper.Map<Vehicle>(vehicle), departmentId);
            return Ok(mapper.Map<VehicleDTO>(data));
        }
    }
}