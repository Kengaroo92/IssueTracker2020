﻿using IssueTracker2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker2020.Services
{
    public interface IBTProjectService
    {
        public bool IsUserOnProject(string userId, int projectId);

        public Task<ICollection<Project>> ListUserProjects(string userId);

        public Task AddUserToProject(string userId, int projectId);

        public Task RemoveUserFromProject(string userId, int projectId);

        public Task<ICollection<BTUser>> UsersOnProject(int projectId);

        public Task<ICollection<BTUser>> UsersNotOnProject(int projectId);
    }
}
