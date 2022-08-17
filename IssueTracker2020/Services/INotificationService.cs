using IssueTracker2020.Models;
using System.Collections.Generic;

namespace IssueTracker2020.Services
{
    internal interface INotificationService
    {
        public List<Notification> NotificationList();
    }
}