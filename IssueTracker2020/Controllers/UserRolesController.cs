using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueTracker2020.Data;
using IssueTracker2020.Models;
using IssueTracker2020.Models.ViewModels;
using IssueTracker2020.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IssueTracker2020.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBTRolesService _rolesService;
        private readonly UserManager<BTUser> _userManager;

        public UserRolesController(ApplicationDbContext context, IBTRolesService rolesService, UserManager<BTUser> userManager)
        {
            _context = context;
            _rolesService = rolesService;
            _userManager = userManager;
        }

        public async Task<IActionResult> ManageUserRoles()
        {
            List<ManageUserRolesViewModel> BTUser = new List<ManageUserRolesViewModel>();
            List<BTUser> users = _context.Users.ToList();

            foreach (var user in users)
            {
                ManageUserRolesViewModel vm = new ManageUserRolesViewModel();
                vm.User = user;
                var selected = await _rolesService.ListUserRoles(user);
                vm.Roles = new MultiSelectList(_context.Roles, "Name", "Name", selected);
                BTUser.Add(vm);
            }

            return View(BTUser);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel BTUser)
        {
            BTUser user = await _context.Users.FindAsync(BTUser.User.Id);

            IEnumerable<string> roles = await _rolesService.ListUserRoles(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            string userRole = BTUser.SelectedRoles.FirstOrDefault();

            if (Enum.TryParse(userRole, out Roles roleValue))
            {
                await _rolesService.AddUserToRole(user, userRole);
                return RedirectToAction("ManagerUserRoles");
            }

            return RedirectToAction("ManagerUserRoles");

        }
    }
}
