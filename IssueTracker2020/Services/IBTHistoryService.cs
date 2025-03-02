﻿using IssueTracker2020.Models;
using System.Threading.Tasks;

namespace IssueTracker2020.Services
{
    public interface IBTHistoryService
    {
        Task AddHistory(Ticket oldTicket, Ticket newTicket, string userId);
    }
}