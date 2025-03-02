﻿using IssueTracker2020.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace IssueTracker2020.Utilities
{
    public static class DataHelper
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            // The default connection string will come from appSettings like usual.
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // It will be automatically overwritten if we are running on Heroku.
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        public static string BuildConnectionString(string databaseUrl)
        {
            // Provides an object representation of a uniform resource identifier (URI) and easy access to the parts of the URI.
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            // Provides a simple way to create and manage the contents of connection strings used by the NpgsqlConnection class.
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Prefer,
                TrustServerCertificate = true
            };

            return builder.ToString();
        }

        public static async Task ManageData(IHost host)
        {
            try
            {
                // This technique is used to obtain references to services.
                // Normally I would just inject these services but you can't use a constructor in a static class.
                using var svcScope = host.Services.CreateScope();
                var svcProvider = svcScope.ServiceProvider;

                // The service will run your migrations.
                var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();
                await dbContextSvc.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while running Manage Data => {ex}");
            }
        }
    }
}