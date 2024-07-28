using Microsoft.AspNetCore.SignalR;
using RTBApi.Hubs.Interface;
using RTBApi.Models;

namespace RTBApi.Hubs
{
    public class TeamUpdateHub : Hub<ITeamUpdateHub>
    {
        static int ConnectedMembersCount = 0;
        public async Task AddTeamUpdate(TaskItem item)
        {
            await Clients.All.ReceiveTeamItem(item);
        }

        public override async Task OnConnectedAsync()
        {
            ConnectedMembersCount++;
            await Clients.All.UpdateConnectedMembersCount(ConnectedMembersCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedMembersCount--;
            await Clients.All.UpdateConnectedMembersCount(ConnectedMembersCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
