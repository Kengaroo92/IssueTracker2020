using IssueTracker2020.Data;
using IssueTracker2020.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker2020.Services
{
    public class BTProjectService : IBTProjectService
    {
        private readonly ApplicationDbContext _context;

        public BTProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsUserOnProject(string userId, int projectId)
        {
            //Project project = await _context.Projects
            //    .Include(u => u.ProjectUsers.Where(u => u.UserId == userId)).ThenInclude(u => u.User)
            //    .FirstOrDefaultAsync(u => u.Id == projectId);

            //bool result = project.ProjectUsers.Any(u => u.UserId == userId);
            //return result;

            return _context.ProjectUsers.Where(pu => pu.UserId == userId && pu.ProjectId == projectId).Any();
        }

        public async Task<ICollection<Project>> ListUserProjects(string userId)
        {
            BTUser user = await _context.Users
                .Include(p => p.ProjectUsers)
                .ThenInclude(p => p.Project)
                .FirstOrDefaultAsync(p => p.Id == userId);

            List<Project> projects = user.ProjectUsers.SelectMany(p => (IEnumerable<Project>)p.Project).ToList();
            return projects;
        }

        public async Task AddUserToProject(string userId, int projectId)
        {
            if (!IsUserOnProject(userId, projectId))
            {
                try
                {
                    await _context.ProjectUsers.AddAsync(new ProjectUser { ProjectId = projectId, UserId = userId });
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"*** ERROR *** - Error Adding User to Project. --> {ex.Message}");
                    throw;
                }
            }
        }

        public async Task RemoveUserFromProject(string userId, int projectId)
        {
            if (IsUserOnProject(userId, projectId))
            {
                try
                {
                    ProjectUser projectUser = await _context.ProjectUsers
                        .Where(pu => pu.UserId == userId && pu.ProjectId == projectId)
                        .FirstOrDefaultAsync();
                    _context.ProjectUsers.Remove(projectUser);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("************ An Error Occured When Removing the User from the Project **************");
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public async Task<ICollection<BTUser>> UsersOnProject(int projectId)
        {
            Project project = await _context.Projects
                .Include(u => u.ProjectUsers).ThenInclude(u => u.User)
                .FirstOrDefaultAsync(u => u.Id == projectId);

            List<BTUser> projectusers = project.ProjectUsers.Select(p => p.User).ToList();
            return projectusers;

            //return await _context.Users.Where(u => IsUserOnProject(u.Id, projectId)).ToListAsync();

        }

        public async Task<ICollection<BTUser>> UsersNotOnProject(int projectId)
        {
            return await _context.Users.Where(u => IsUserOnProject(u.Id, projectId) == false).ToListAsync();
        }
    }
}
