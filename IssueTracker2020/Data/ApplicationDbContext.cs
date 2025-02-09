﻿using IssueTracker2020.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker2020.Data
{
    public class ApplicationDbContext : IdentityDbContext<BTUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectUser>()
                .HasKey(pu => new { pu.ProjectId, pu.UserId });
        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectUser> ProjectUsers { get; set; }

        public DbSet<TicketAttachment> TicketAttachments { get; set; }

        public DbSet<TicketComment> TicketComments { get; set; }

        public DbSet<TicketHistory> TicketHistories { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<TicketType> TicketTypes { get; set; }

        public DbSet<TicketStatus> TicketStatuses { get; set; }

        public DbSet<TicketPriority> TicketPriorities { get; set; }
    }
}