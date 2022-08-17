using IssueTracker2020.Data;
using IssueTracker2020.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Threading.Tasks;

namespace IssueTracker2020.Services
{
    public class BTHistoryService : IBTHistoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BTUser> _userManager;
        private readonly IEmailSender _emailSender;

        public BTHistoryService(ApplicationDbContext context, UserManager<BTUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task AddHistory(Ticket oldTicket, Ticket newTicket, string userId)
        {
            if (oldTicket.Title != newTicket.Title)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Title",
                    OldValue = oldTicket.Title,
                    NewValue = newTicket.Title,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            if (oldTicket.Description != newTicket.Description)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Description",
                    OldValue = oldTicket.Title,
                    NewValue = newTicket.Title,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            if (oldTicket.Created != newTicket.Created)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Created",
                    OldValue = oldTicket.Title,
                    NewValue = newTicket.Title,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            if (oldTicket.Updated != newTicket.Updated)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Updated",
                    OldValue = oldTicket.Title,
                    NewValue = newTicket.Title,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            if (oldTicket.TicketTypeId != newTicket.TicketTypeId)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Ticket Type",
                    OldValue = _context.TicketTypes.Find(oldTicket.Id).Name,
                    NewValue = _context.TicketTypes.Find(newTicket.Id).Name,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            if (oldTicket.TicketPriorityId != newTicket.TicketPriorityId)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Ticket Priority",
                    OldValue = _context.TicketPriorities.Find(oldTicket.Id).Name,
                    NewValue = _context.TicketPriorities.Find(newTicket.Id).Name,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            if (oldTicket.TicketStatusId != newTicket.TicketStatusId)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Ticket Status",
                    OldValue = _context.TicketStatuses.Find(oldTicket.Id).Name,
                    NewValue = _context.TicketStatuses.Find(newTicket.Id).Name,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            if (oldTicket.DeveloperUserId != newTicket.DeveloperUserId)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Developer",
                    OldValue = oldTicket.DeveloperUser.FullName,
                    NewValue = newTicket.DeveloperUser.FullName,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);

                Notification notification = new Notification
                {
                    TicketId = newTicket.Id,
                    Description = "You have been assigned a new ticket.",
                    Created = DateTime.Now,
                    SenderId = userId,
                    RecipientId = newTicket.DeveloperUserId
                };
                await _context.Notifications.AddAsync(notification);

                string devEmail = newTicket.DeveloperUser.Email;
                string subject = "New Ticket Assignment";
                string message = $"You have a new ticket for project: {newTicket.Project.Name}";

                await _emailSender.SendEmailAsync(devEmail, subject, message);
            }

            if (oldTicket.Comments != newTicket.Comments)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Comments",
                    OldValue = oldTicket.Title,
                    NewValue = newTicket.Title,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            if (oldTicket.Attachments != newTicket.Attachments)
            {
                TicketHistory history = new TicketHistory
                {
                    TicketId = newTicket.Id,
                    Property = "Attachments",
                    OldValue = oldTicket.Title,
                    NewValue = newTicket.Title,
                    Created = DateTime.Now,
                    UserId = userId
                };
                await _context.TicketHistories.AddAsync(history);
            }
            await _context.SaveChangesAsync();
        }
    }
}