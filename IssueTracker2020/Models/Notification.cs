﻿using System;

namespace IssueTracker2020.Models

{
    public class Notification

    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset Created { get; set; }

        public string RecipientId { get; set; }

        public string SenderId { get; set; }

        public bool Viewed { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual BTUser Recipient { get; set; }

        public virtual BTUser Sender { get; set; }
    }
}