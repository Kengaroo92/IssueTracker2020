using IssueTracker2020.Data;
using IssueTracker2020.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker2020.Services
{
    public interface ITicketService
    {
        public int StatusFilter(string statusName);

        public int StatusCount(string statusName);

        public Task<IEnumerable<Ticket>> ListUserTickets();

    }
}
