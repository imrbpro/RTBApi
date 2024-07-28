using RTBApi.Models;

namespace RTBApi.Hubs.Interface
{
    public interface ITeamUpdateHub
    {
        Task ReceiveTeamItem(TaskItem item);
        Task UpdateConnectedMembersCount(int count);
    }
}
