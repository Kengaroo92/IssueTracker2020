using IssueTracker2020.Data;
using IssueTracker2020.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IssueTracker2020.Services
{
    public class NotificatonService : INotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BTUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        public NotificatonService(ApplicationDbContext context, UserManager<BTUser> userManager, IHttpContextAccessor httpContext)
        {
            _context = context;
            _userManager = userManager;
            _httpContext = httpContext;
        }

        public List<Notification> NotificationList()
        {
            var user = _httpContext.HttpContext.User;
            var userId = _userManager.GetUserId(user);
            var notificationList = new List<Notification>();
            var notification = _context.Notifications
                .Where(n => n.RecipientId == userId)
                .Include(n => n.Ticket);

            notificationList.AddRange(notification);

            notificationList.RemoveAll(n => n.Viewed == true);

            return notificationList;
        }
    }
}