using System.Threading.Tasks;

namespace IssueTracker2020.Services
{
    public interface IBTAccessService
    {
        public Task<bool> CanInteractTicket(string userId, int ticketId, string roleName);

        public Task<bool> CanInteractProject(string userId, int projectId, string roleName);
    }
}