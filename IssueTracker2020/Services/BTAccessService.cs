﻿using IssueTracker2020.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker2020.Services
{
    public class BTAccessService : IBTAccessService
    {
        private readonly ApplicationDbContext _context;

        public BTAccessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CanInteractProject(string userId, int projectId, string roleName)
        {
            switch (roleName)
            {
                case "Admin":
                    return true;

                case "ProjectManager":
                    if (await _context.ProjectUsers.Where(pu => pu.UserId == userId && pu.ProjectId == projectId).AnyAsync())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }

        public async Task<bool> CanInteractTicket(string userId, int ticketId, string roleName)
        {
            bool result = false;
            switch (roleName)
            {
                case "Admin":
                    result = true;
                    break;

                case "ProjectManager":
                    var projectId = _context.Tickets.FindAsync(ticketId).Result.ProjectId;
                    if (await _context.ProjectUsers.Where(pu => pu.UserId == userId && pu.ProjectId == projectId).AnyAsync())
                    {
                        result = true;
                        break;
                    }
                    break;

                case "Developer":
                    if (await _context.Tickets.Where(t => (t.DeveloperUserId == userId || t.OwnerUserId == userId) && t.Id == ticketId).AnyAsync())
                    {
                        result = true;
                    }
                    break;

                case "Submitter":
                    if (await _context.Tickets.Where(t => t.Id == ticketId && t.OwnerUserId == userId).AnyAsync())
                    {
                        result = true;
                    }
                    break;

                default:
                    break;
            }
            return result;
        }
    }
}