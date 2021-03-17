using Microsoft.AspNetCore.Mvc.Rendering;

namespace IssueTracker2020.Models.ViewModels
{
    public class ProjectUsersViewModel
    {
        public Project Project { get; set; }

        public MultiSelectList Users { get; set; }

        public string[] SelectedUsers { get; set; }
    }
}
