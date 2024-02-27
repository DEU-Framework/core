using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AutoMapper;
using DEU_Backend.DTOs;
using DEU_Backend.Filters;
using DEU_Backend.Services;
using DEU_Lib.Model;
using DEU_Lib.Model.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DEU_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController(DepartmentService departmentService, AuthService authService, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Get a Department by its ID
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// Department
        /// </returns>
        /// <response code="200">Returns the Department</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(DepartmentAuthorizeFilter))]
        [HttpGet("{departmentId}")]
        public async Task<ActionResult<DepartmentDTO>> GetByIdAsync(int departmentId)
        {
            var department = await departmentService.GetByIdAsync(departmentId);
            if (department == null)
                return NotFound();

            return Ok(mapper.Map<DepartmentDTO>(department));
        }

        /// <summary>
        /// Create a new Department
        /// </summary>
        /// <param name="department">Department to create</param>
        /// <returns>
        /// Department
        /// </returns>
        /// <response code="200">Returns the created Department</response>
        /// <response code="400">Invalid Department</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DepartmentDTO department)
        {
            var data = await departmentService.CreateAsync(mapper.Map<Department>(department));
            return Ok(mapper.Map<DepartmentDTO>(data));
        }

        //Add user to department
        /// <summary>
        /// Add a user to a department
        /// </summary>
        /// <param name="userEmail">Email</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// User
        /// </returns>
        /// <response code="200">Returns the User</response>
        /// <response code="400">Invalid User or Department</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{departmentId}/user/{userEmail}")]
        public async Task<IActionResult> AddUserToDepartment(string userEmail, int departmentId)
        {
            if (string.IsNullOrEmpty(userEmail) || departmentId <= 0)
                return BadRequest("Invalid User or Department");

            var requestUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (requestUserId == null)
                return BadRequest("Invalid User");

            var requestUserRoles = await authService.GetUserRolesForDepartmentAsync(requestUserId, departmentId);

            if (!requestUserRoles.Any(r => r.RoleName.ToLower().Equals("admin")))
                return BadRequest("Invalid User");

            var data = await departmentService.AddUserToDepartmentAsync(userEmail, departmentId);
            return Ok(new { data.Email, data.Id });
        }

        /// <summary>
        /// Get default department for user
        /// </summary>
        /// <returns>
        /// Department
        /// </returns>
        /// <response code="200">Returns the Department</response>
        /// <response code="400">Invalid User</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("default")]
        public async Task<IActionResult> GetDefaultDepartment()
        {
            try
            {
                var requestUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (requestUserId == null)
                    return BadRequest("Invalid User");

                var data = await departmentService.GetDefaultDepartmentOfUserAsync(requestUserId);
                return Ok(mapper.Map<ApplicationUserDepartmentSettingDTO>(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}