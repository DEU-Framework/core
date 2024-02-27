using AutoMapper;
using DEU_Backend.DTOs;
using DEU_Backend.Services;
using DEU_Lib.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEU_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController(DeuDbContext deuDbContext) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOperationAsync(int departmentId, string operationTypeId = "B0-BMA")
        {

            var utcNow = DateTime.UtcNow;
            var opid = Guid.NewGuid();
            // Create a new operation
            var operation = new Operation
            {
                OperationId = opid.ToString(),
                CallerName = "John Doe",
                CallerPhone = "123456789",
                Location = "Test Location",
                District = "Test District",
                Exercise = false,
                EndDate = utcNow.AddMinutes(221),
                StartDate = utcNow,
                Latitude = 48.37474349737338,
                Longitude = 14.518456483473758,
                Level = "1",
                Municipal = "Test Municipal",
                Public = true,
                Zone = "Test Zone",
                OperationTypeHistories = new List<OperationTypeHistory>
                {
                    new OperationTypeHistory
                    {
                        OperationId = opid.ToString(),
                        TypeId = operationTypeId,
                        SubTypeId = "BMA1-BR",
                        Level = "1",
                    }
                }
            };

            deuDbContext.Operations.Add(operation);
            await deuDbContext.SaveChangesAsync();

            await deuDbContext.OperationResponses.AddAsync(new OperationResponse { DepartmentId = departmentId, OperationId = operation.OperationId, AlertTime = utcNow, DispatchTime = utcNow, Status = OperationResponseStatus.Alerted });
            await deuDbContext.SaveChangesAsync();

            // Attempt to find the predefined checklist for the operation type and department
            var checklist = await deuDbContext.Checklists.Include(c => c.Tasks)
                .FirstOrDefaultAsync(c => c.OperationTypeId == operationTypeId && c.DepartmentId == departmentId && c.IsTemplate);
            if (checklist != null)
            {
                var checklistId = Guid.NewGuid();
                var clonedChecklist = new Checklist
                {
                    ChecklistId = checklistId,
                    OperationTypeId = checklist.OperationTypeId,
                    DepartmentId = checklist.DepartmentId,
                    Tasks = checklist.Tasks.Select(task => new ChecklistTask
                    {
                        ChecklistId = checklistId,
                        Name = task.Name,
                        Description = task.Description,
                        IsCompleted = false // Ensure tasks are marked as not completed
                    }).ToList()
                };

                deuDbContext.Checklists.Add(clonedChecklist);
                await deuDbContext.SaveChangesAsync();

                deuDbContext.OperationChecklists.Add(new OperationChecklist { OperationId = operation.OperationId, ChecklistId = clonedChecklist.ChecklistId });
                await deuDbContext.SaveChangesAsync();
            }


            return Ok(operation);
        }

        [HttpPost("checklist")]
        public async Task<IActionResult> GetChecklistForOperationAsync(string operationId)
        {
            var checklist = await deuDbContext.OperationChecklists.Include(oc => oc.Checklist).ThenInclude(c => c!.Tasks)
                .Where(oc => oc.OperationId == operationId)
                .Select(oc => oc.Checklist)
                .FirstOrDefaultAsync();

            return Ok(checklist);
        }

        [HttpPost("action")]
        public async Task<IActionResult> CompleteFirstTaskOfOperationAsync(string operationId)
        {
            // Assuming each operation directly knows its ChecklistId or you can derive it
            // Fetch the operation to get its ChecklistId
            var operation = await deuDbContext.Operations
                .Include(o => o.OperationChecklists)
                .ThenInclude(oc => oc.Checklist)
                .FirstOrDefaultAsync(o => o.OperationId == operationId);

            if (operation == null || operation.OperationChecklists == null || !operation.OperationChecklists.Any())
            {
                throw new InvalidOperationException("Operation not found or has no checklists.");
            }

            // Assuming there's a direct way to identify the correct checklist for the operation
            var checklistId = operation.OperationChecklists.First().ChecklistId; // This assumes a single checklist per operation, adjust logic as needed

            // Now, fetch the first task of this checklist
            var firstTask = await deuDbContext.ChecklistTasks
                .Where(ct => ct.ChecklistId == checklistId)
                .OrderBy(ct => ct.ChecklistTaskId) // Adjust ordering as necessary
                .FirstOrDefaultAsync();

            if (firstTask != null)
            {
                firstTask.IsCompleted = true;
                await deuDbContext.SaveChangesAsync();
            }
            return Ok(firstTask);
        }
    }
}