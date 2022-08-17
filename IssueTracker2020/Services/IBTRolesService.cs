using IssueTracker2020.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueTracker2020.Services
{
    public interface IBTRolesService
    {
        public Task<bool> AddUserToRole(BTUser user, string roleName);

        public Task<bool> IsUserInRole(BTUser user, string roleName);

        public Task<IEnumerable<string>> ListUserRoles(BTUser user);

        public Task<bool> RemoveUserFromRole(BTUser user, string roleName);

        public Task<ICollection<BTUser>> UsersInRole(string roleName);

        public Task<ICollection<BTUser>> UsersNotInRole(IdentityRole role);
    }
}