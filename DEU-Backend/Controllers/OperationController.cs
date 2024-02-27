using AutoMapper;
using DEU_Backend.DTOs;
using DEU_Backend.Hubs;
using DEU_Backend.Services;
using DEU_Lib.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DEU_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController(OperationService operationService, IMapper mapper, IHubContext<OperationHub> operationHub) : ControllerBase
    {
        /// <summary>
        /// Get all Operations for a Department from the database with pagination. Returns all Operations if page and pageSize are not set.
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Number of items per page</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// List of Operations
        /// </returns>
        /// <response code="200">Returns the list of Operations</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<OperationDTO>>> GetAsync(int departmentId, int page = 0, int pageSize = 0)
        {
            var data = await operationService.GetAsync(departmentId, page, pageSize);
            return Ok(mapper.Map<List<OperationDTO>>(data));
        }

        /// <summary>
        /// Get an Operation by its ID for the Department
        /// </summary>
        /// <param name="operationId">ID of the Operation</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <returns>
        /// Operation
        /// </returns>
        /// <response code="200">Returns the Operation</response>
        /// <response code="404">Operation not found</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{operationId}")]
        public async Task<ActionResult<OperationDTO>> GetByIdAsync(string operationId, int departmentId)
        {
            var data = await operationService.GetByIdAsync(departmentId, operationId);
            if (data == null) return NotFound("Operation not found");
            var dto = mapper.Map<OperationDTO>(data);
            if (dto!.RespondedDepartments != null && dto.RespondedDepartments.Any() && data.RespondedDepartments.First().Department != null)
                dto.RespondedDepartments.First().DepartmentName = data.RespondedDepartments.First().Department!.Name;
            return Ok(dto);
        }

        /// <summary>
        /// Create a new Operation for a Department
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="operation">Operation to create</param>
        /// <returns>
        /// Operation
        /// </returns>
        /// <response code="200">Returns the created Operation</response>
        /// <response code="400">Invalid Operation</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<OperationDTO>> CreateAsync(int departmentId, OperationDTO operation)
        {
            var data = await operationService.CreateAsync(departmentId, mapper.Map<Operation>(operation));
            var dto = mapper.Map<OperationDTO>(data);
            if (dto == null) return BadRequest("Invalid Operation");
            if (dto!.RespondedDepartments != null && dto.RespondedDepartments.Any() && data.RespondedDepartments.First().Department != null)
                dto.RespondedDepartments.First().DepartmentName = data.RespondedDepartments.First().Department!.Name;
            await operationHub.Clients.Group(departmentId.ToString()).SendAsync("ReceiveOperation", dto);
            return Ok(dto);
        }

        /// <summary>
        /// Add Action to Operation for the Department
        /// </summary>
        /// <param name="operationId">ID of the Operation</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="action">Action to add</param>
        /// <returns>
        /// OperationAction
        /// </returns>
        /// <response code="200">Returns the Operation</response>
        /// <response code="400">Invalid Operation</response>
        /// <response code="404">Operation not found</response>
        /// <response code="404">Department not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{operationId}/actions")]
        public async Task<ActionResult<OperationActionDTO>> AddActionAsync(string operationId, int departmentId, OperationActionDTO action)
        {
            var data = await operationService.AddActionAsync(departmentId, operationId, mapper.Map<OperationAction>(action));
            return Ok(mapper.Map<OperationActionDTO>(data));
        }

        /// <summary>
        /// Get all Actions for a Operation from the database(Actions) with pagination. Returns all Actions if page and pageSize are not set.
        /// </summary>
        /// <param name="operationId">ID of the Operation</param>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>
        /// List of Actions
        /// </returns>
        /// <response code="200">Returns the list of Actions</response>
        /// <response code="404">Operation not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{operationId}/actions")]
        public async Task<ActionResult<List<OperationActionDTO>>> GetActionsAsync(string operationId, int departmentId, int page = 0, int pageSize = 0)
        {
            var data = await operationService.GetActionsAsync(departmentId, operationId, page, pageSize);
            return Ok(mapper.Map<List<OperationActionDTO>>(data));
        }
    }
}
