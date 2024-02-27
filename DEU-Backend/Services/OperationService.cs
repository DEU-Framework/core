using DEU_Lib.Model;
using Microsoft.EntityFrameworkCore;

namespace DEU_Backend.Services
{
    public class OperationService(DeuDbContext dbContext)
    {
        private readonly DeuDbContext _dbContext = dbContext;

        /// <summary>
        /// Get all Responded Operations for a Department from the database(RespondedDepartments) with pagination. Returns all Operations if page and pageSize are not set.
        /// optinal get only running operations
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="running">get only running operations</param>
        /// <returns>
        /// List of Operations
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        public async Task<List<Operation>> GetAsync(int departmentId, int page = 0, int pageSize = 0, bool running = false)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            if (page <= 0 || pageSize <= 0)
            {
                var data = await _dbContext.OperationResponses
                .Include(o => o.Operation)
                    .ThenInclude(o => o!.OperationTypeHistories)
                    .ThenInclude(o => o!.Type)
                    .Include(o => o.Operation)
                    .ThenInclude(o => o!.OperationTypeHistories)
                    .ThenInclude(o => o!.SubType)
                    .Where(o => o.DepartmentId == departmentId)
                    .ToListAsync();
                if (data.Count == 0)
                    return [];
                return data.Select(o => o.Operation!).ToList();
            }
            else
            {
                var data = await _dbContext.OperationResponses
                    .Include(o => o.Operation)
                    .ThenInclude(o => o!.OperationTypeHistories)
                    .ThenInclude(o => o!.Type)
                    .Include(o => o.Operation)
                    .ThenInclude(o => o!.OperationTypeHistories)
                    .ThenInclude(o => o!.SubType)
                    .Where(o => o.DepartmentId == departmentId)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                if (data.Count == 0)
                    return [];
                return data.Select(o => o.Operation!).ToList();
            }
        }

        /// <summary>
        /// Get a Operation by its ID for the Department
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="operationId">ID of the Operation</param>
        /// <returns>
        /// Operation
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        /// <exception cref="Exception">Thrown if Operation not found</exception>
        /// <exception cref="Exception">Thrown if Operation is not for the Department</exception>
        public async Task<Operation?> GetByIdAsync(int departmentId, string operationId)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            var data = await _dbContext.OperationResponses
                .Include(o => o.Operation)
                .ThenInclude(o => o!.OperationTypeHistories)
                .ThenInclude(o => o!.Type)
                .Include(o => o.Operation)
                .ThenInclude(o => o!.OperationTypeHistories)
                .ThenInclude(o => o!.SubType)
                .Include(o => o.Operation)
                .ThenInclude(o => o!.RespondedDepartments)
                .ThenInclude(d => d.Department)
                .Include(o => o.Operation)
                .ThenInclude(o => o!.Actions)
                .FirstOrDefaultAsync(o => o.OperationId == operationId) ?? throw new Exception("Operation not found");
            if (data.DepartmentId != departmentId)
                throw new Exception("Operation is not for the Department");
            return data.Operation;
        }

        /// <summary>
        /// Create a new Operation for the Department
        /// if Operation already exists add Department to OperationResponses if it dindt respond to the Operation yet
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="operation">Operation to create</param>
        /// <returns>
        /// Created Operation
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        public async Task<Operation> CreateAsync(int departmentId, Operation operation)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            var data = await _dbContext.Operations.FirstOrDefaultAsync(o => o.OperationId == operation.OperationId);
            if (data == null)
            {
                var utcNow = DateTime.UtcNow;
                await _dbContext.Operations.AddAsync(operation);
                await _dbContext.SaveChangesAsync();
                await _dbContext.OperationResponses.AddAsync(new OperationResponse { DepartmentId = departmentId, OperationId = operation.OperationId, AlertTime = utcNow, DispatchTime = utcNow, Status = OperationResponseStatus.Alerted });
                await _dbContext.SaveChangesAsync();
                return _dbContext.Operations
                    .Include(o => o.OperationTypeHistories)
                    .ThenInclude(o=>o.Type)
                    .Include(o => o.OperationTypeHistories)
                    .ThenInclude(o=>o.Type)
                    .Include(o => o.RespondedDepartments)
                    .ThenInclude(d => d.Department)
                    .First(o => o.OperationId == operation.OperationId);
            }
            else
            {
                var utcNow = DateTime.UtcNow;
                var response = await _dbContext.OperationResponses.FirstOrDefaultAsync(o => o.OperationId == operation.OperationId && o.DepartmentId == departmentId);
                if (response == null)
                {
                    await _dbContext.OperationResponses.AddAsync(new OperationResponse { DepartmentId = departmentId, OperationId = operation.OperationId, AlertTime = utcNow, DispatchTime = utcNow, Status = OperationResponseStatus.Alerted });
                    await _dbContext.SaveChangesAsync();
                }
                return _dbContext.Operations
                    .Include(o => o.OperationTypeHistories)
                    .ThenInclude(o=>o.Type)
                    .Include(o => o.OperationTypeHistories)
                    .ThenInclude(o=>o.Type)
                    .Include(o => o.RespondedDepartments)
                    .ThenInclude(d => d.Department)
                    .First(o => o.OperationId == operation.OperationId);
            }
        }

        /// <summary>
        /// Get all Actions for a Operation from the database(Actions) with pagination. Returns all Actions if page and pageSize are not set.
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="id">ID of the Operation</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>
        /// List of Actions
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        /// <exception cref="Exception">Thrown if Operation not found</exception>
        /// <exception cref="Exception">Thrown if Operation is not for the Department</exception>
        public async Task<List<OperationAction>> GetActionsAsync(int departmentId, string id, int page = 0, int pageSize = 0)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            var data = await _dbContext.OperationResponses.Include(o => o.Operation).ThenInclude(o => o!.Actions).FirstOrDefaultAsync(o => o.OperationId == id) ?? throw new Exception("Operation not found");
            if (data.DepartmentId != departmentId)
                throw new Exception("Operation is not for the Department");
            if (page <= 0 || pageSize <= 0)
            {
                if (data.Operation!.Actions.Count == 0)
                    return [];
                return data.Operation!.Actions.ToList();
            }
            else
            {
                if (data.Operation!.Actions.Count == 0)
                    return [];
                return data.Operation!.Actions.Skip(page * pageSize).Take(pageSize).ToList();
            }
        }

        /// <summary>
        /// Add a new Action to a Operation
        /// </summary>
        /// <param name="departmentId">ID of the Department</param>
        /// <param name="id">ID of the Operation</param>
        /// <param name="action">Action to add</param>
        /// <returns>
        /// Created Action
        /// </returns>
        /// <exception cref="Exception">Thrown if Department not found</exception>
        /// <exception cref="Exception">Thrown if Operation not found</exception>
        /// <exception cref="Exception">Thrown if Operation is not for the Department</exception>
        public async Task<OperationAction> AddActionAsync(int departmentId, string id, OperationAction action)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId) ?? throw new Exception("Department not found");
            var data = await _dbContext.OperationResponses.Include(o => o.Operation).ThenInclude(o => o!.Actions).FirstOrDefaultAsync(o => o.OperationId == id) ?? throw new Exception("Operation not found");
            if (data.DepartmentId != departmentId)
                throw new Exception("Operation is not for the Department");
            action.ActionDate = DateTime.UtcNow;
            data.Operation!.Actions.Add(action);
            await _dbContext.SaveChangesAsync();
            return action;
        }
    }
}