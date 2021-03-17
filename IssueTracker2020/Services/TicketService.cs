using IssueTracker2020.Data;
using IssueTracker2020.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IssueTracker2020.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BTUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBTProjectService _projectService;
        private readonly BTUser _user;

        public TicketService(ApplicationDbContext context, UserManager<BTUser> userManager, IHttpContextAccessor contextAccessor, IBTProjectService projectService)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _projectService = projectService;
            _user = _context.Users.Find(_userManager.GetUserId(_contextAccessor.HttpContext.User));
        }
        public int StatusFilter(string statusName)
        {
            return _context.TicketStatuses.Where(t => t.Name == statusName).FirstOrDefault().Id;
        }

        public int StatusCount(string statusName)
        {
            var id = StatusFilter(statusName);
            return _context.Tickets.Where(t => t.TicketStatusId == id).Count();
        }

        public async Task<IEnumerable<Ticket>> ListUserTickets()
        {
            if (_contextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                return await _context.Tickets
                    .Include(t => t.DeveloperUser)
                    .Include(t => t.OwnerUser)
                    .Include(t => t.Project)
                    .Include(t => t.TicketPriority)
                    .Include(t => t.TicketStatus)
                    .Include(t => t.TicketType)
                    .ToListAsync();
            }
            else if (_contextAccessor.HttpContext.User.IsInRole("ProjectManager"))
            {
                BTUser user = await _context.Users.Include(p => p.ProjectUsers).ThenInclude(p => p.Project).ThenInclude(p => p.Tickets).FirstOrDefaultAsync(p => p.Id == _user.Id);
                var data = user.ProjectUsers.Select(p => p.Project).Select(p => p.Tickets);
                List<Ticket> tickets = new List<Ticket>();
                foreach (var collection in data)
                {
                    tickets.AddRange(collection);
                }

                var ticketIncludes = _context.Tickets
                    .Include(t => t.DeveloperUser)
                    .Include(t => t.OwnerUser)
                    .Include(t => t.Project)
                    .Include(t => t.TicketPriority)
                    .Include(t => t.TicketStatus)
                    .Include(t => t.TicketType);


                return tickets;
            }
            return await _context.Tickets
                .Include(t => t.DeveloperUser)
                .Include(t => t.OwnerUser)
                .Include(t => t.Project)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.TicketType)
                .Where(t => t.DeveloperUserId == _user.Id || t.OwnerUserId == _user.Id).ToListAsync();
        }
    }
}
