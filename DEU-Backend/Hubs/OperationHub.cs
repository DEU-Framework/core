using DEU_Backend.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace DEU_Backend.Hubs
{
    public class OperationHub : Hub
    {
        public async Task SendOperation(OperationDTO operation)
        {
            if(operation.RespondedDepartments == null)
            {
                return;
            }
            var departmentIds = operation.RespondedDepartments.Select(d => d.DepartmentId).ToList();
            foreach (var departmentId in departmentIds)
            {
                await Clients.Group(departmentId.ToString()).SendAsync("ReceiveOperation", operation);
            }
        }

        public async Task AddToGroup(int departmentId)
        {
            var did = departmentId.ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, did);

            await Clients.Group(did).SendAsync("Send", $"{Context.ConnectionId} has joined the group {did}.");
        }

        public async Task RemoveFromGroup(int departmentId)
        {
            var did = departmentId.ToString();
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, did);

            await Clients.Group(did).SendAsync("Send", $"{Context.ConnectionId} has left the group {did}.");
        }
    }
}