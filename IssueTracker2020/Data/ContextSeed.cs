using IssueTracker2020.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker2020.Data
{
    public enum Roles
    {
        Admin,
        ProjectManager,
        Developer,
        Submitter,
        NewUser,
        Demo
    }

    public static class ContextSeed
    {
        public static async Task RunSeedMethodsAsync(RoleManager<IdentityRole> roleManager, UserManager<BTUser> userManager, ApplicationDbContext context)
        {
            await SeedRolesAsync(roleManager);
            await SeedDefaultUsersAsync(userManager);
            await SeedTicketTypesAsync(context);
            await SeedTicketPrioritiesAsync(context);
            await SeedTicketStatusesAsync(context);
            await SeedProjectAsync(context);
            await SeedProjectUsersAsync(context, userManager);
            await SeedTicketsAsync(context, userManager);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.ProjectManager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Developer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Submitter.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.NewUser.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Demo.ToString()));
        }

        private static async Task SeedDefaultUsersAsync(UserManager<BTUser> userManager)
        {
            #region Seed defaultAdmin

            // Seed Default Admin User
            var defaultAdmin = new BTUser
            {
                UserName = "admin@mailinator.com",
                Email = "admin@mailinator.com",
                FirstName = "Nick",
                LastName = "Fury",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdmin, "Abc123!@");
                    await userManager.AddToRoleAsync(defaultAdmin, Roles.Admin.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default Admin User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Seed defaultAdmin

            #region Seed defaultPM

            // Seed Default ProjectManager User

            var defaultPM = new BTUser
            {
                UserName = "pm@mailinator.com",
                Email = "pm@mailinator.com",
                FirstName = "Peter",
                LastName = "Quill",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultPM.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultPM, "Abc123!@");
                    await userManager.AddToRoleAsync(defaultPM, Roles.ProjectManager.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default Project Manager User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Seed defaultPM

            #region Seed defaultDeveloper

            // Seed Default Developer User

            var defaultDeveloper = new BTUser
            {
                UserName = "developer@mailinator.com",
                Email = "developer@mailinator.com",
                FirstName = "Stephen",
                LastName = "Vincent",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultDeveloper.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultDeveloper, "Abc123!@");
                    await userManager.AddToRoleAsync(defaultDeveloper, Roles.Developer.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default Developer User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Seed defaultDeveloper

            #region Seed defaultSubmitter

            // Seed Default Submitter User

            var defaultSubmitter = new BTUser
            {
                UserName = "submitter@mailinator.com",
                Email = "submitter@mailinator.com",
                FirstName = "Bruce",
                LastName = "Banner",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultSubmitter.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultSubmitter, "Abc123!@");
                    await userManager.AddToRoleAsync(defaultSubmitter, Roles.Submitter.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default Submitter User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Seed defaultSubmitter

            #region Seed defaultNewUser

            // Seed Default New User

            var defaultNewUser = new BTUser
            {
                UserName = "newuser@mailinator.com",
                Email = "newuser@mailinator.com",
                FirstName = "Tony",
                LastName = "Stark",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultNewUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultNewUser, "Abc123!@");
                    await userManager.AddToRoleAsync(defaultNewUser, Roles.Submitter.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default New User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Seed defaultNewUser

            // Demo User Are Below

            string demoPassword = "Xyz#*@183!!";

            #region Demo Seed defaultAdmin

            // Seed Default Admin User
            defaultAdmin = new BTUser
            {
                UserName = "demoadmin@mailinator.com",
                Email = "demoadmin@mailinator.com",
                FirstName = "Peter",
                LastName = "Parker",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdmin, demoPassword);
                    await userManager.AddToRoleAsync(defaultAdmin, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultAdmin, Roles.Demo.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Admin User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Seed defaultAdmin

            #region Demo Seed defaultPM

            // Seed Default ProjectManager User

            defaultPM = new BTUser
            {
                UserName = "demopm@mailinator.com",
                Email = "demopm@mailinator.com",
                FirstName = "Donald",
                LastName = "Blake",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultPM.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultPM, demoPassword);
                    await userManager.AddToRoleAsync(defaultPM, Roles.ProjectManager.ToString());
                    await userManager.AddToRoleAsync(defaultPM, Roles.Demo.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Project Manager User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Seed defaultPM

            #region Demo Seed defaultDeveloper

            // Seed Default Developer User

            defaultDeveloper = new BTUser
            {
                UserName = "demodeveloper@mailinator.com",
                Email = "demodeveloper@mailinator.com",
                FirstName = "Scott",
                LastName = "Summers",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultDeveloper.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultDeveloper, demoPassword);
                    await userManager.AddToRoleAsync(defaultDeveloper, Roles.Developer.ToString());
                    await userManager.AddToRoleAsync(defaultDeveloper, Roles.Demo.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Developer User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Seed defaultDeveloper

            #region Demo Seed defaultSubmitter

            // Seed Default Submitter User

            defaultSubmitter = new BTUser
            {
                UserName = "demosubmitter@mailinator.com",
                Email = "demosubmitter@mailinator.com",
                FirstName = "Alex",
                LastName = "Smith",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultSubmitter.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultSubmitter, demoPassword);
                    await userManager.AddToRoleAsync(defaultSubmitter, Roles.Submitter.ToString());
                    await userManager.AddToRoleAsync(defaultSubmitter, Roles.Demo.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Alex Smith User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Seed defaultSubmitter

            #region Demo Seed defaultNewUser

            // Seed Default New User

            defaultNewUser = new BTUser
            {
                UserName = "demonewuser@mailinator.com",
                Email = "demonewuser@mailinator.com",
                FirstName = "Wanda",
                LastName = "Maximoff",
                EmailConfirmed = true,
            };
            try
            {
                var user = await userManager.FindByEmailAsync(defaultNewUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultNewUser, demoPassword);
                    await userManager.AddToRoleAsync(defaultNewUser, Roles.Submitter.ToString());
                    await userManager.AddToRoleAsync(defaultNewUser, Roles.Demo.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo New User.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Seed defaultNewUser
        }

        private static async Task SeedTicketTypesAsync(ApplicationDbContext context)
        {
            #region Seed defaultSeedGeneral

            // Seed General TicketType
            var defaultSeedGeneral = new TicketType
            {
                Name = "General"
            };
            try
            {
                var ticketType = await context.TicketTypes.Where(tt => tt.Name == "General").FirstOrDefaultAsync();
                if (ticketType == null)
                {
                    context.TicketTypes.Add(defaultSeedGeneral);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default General Ticket Type.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
            };

            #endregion Seed defaultSeedGeneral

            #region Seed defaultSeedUI

            // Seed UI TicketType
            // Setting a new variable named defaultSeedUI that calls the TicketType model.
            var defaultSeedUI = new TicketType
            {
                // Setting the TicketType Property Name to UI.
                Name = "UI"
            };
            // The method will then try the following code.
            try
            {
                // Setting a new variable named type that allows us to access properties from the ApplicationDBContext class and the TicketType Model.
                // It then will use the .Where extension to filter values based on the lambda expression.
                // The lambda expression takes the input tt and compares it to the database table tt.Name to see if it has any values that have the name UI.
                // It will then return the first element of the sequence or set it to a default value if none exist.
                var ticketType = await context.TicketTypes.Where(tt => tt.Name == "UI").FirstOrDefaultAsync();

                // Now we create an if statement that does the following if the var type above is null
                if (ticketType == null)
                {
                    // if it is null, it will add the defaultSeedUI Name = "UI" to the database for TicketType model.
                    context.TicketTypes.Add(defaultSeedUI);
                    await context.SaveChangesAsync();
                }
            }

            // if it returns something other then null, it will throw and error which is written out below.
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default UI Ticket Type.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
            };

            #endregion Seed defaultSeedUI

            #region Seed defaultSeedRuntime

            // Seed Runtime TicketType
            var defaultSeedRuntime = new TicketType
            {
                Name = "Runtime"
            };
            try
            {
                var ticketType = await context.TicketTypes.Where(tt => tt.Name == "Runtime").FirstOrDefaultAsync();
                if (ticketType == null)
                {
                    context.TicketTypes.Add(defaultSeedRuntime);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default Runtime Ticket Type.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
            };

            #endregion Seed defaultSeedRuntime

            #region Seed defaultSeedBackEnd

            // Seed BackEnd TicketType
            var defaultSeedBackEnd = new TicketType
            {
                Name = "BackEnd"
            };
            try
            {
                var ticketType = await context.TicketTypes.Where(tt => tt.Name == "BackEnd").FirstOrDefaultAsync();
                if (ticketType == null)
                {
                    context.TicketTypes.Add(defaultSeedBackEnd);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Default BackEnd Ticket Type.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
            };

            #endregion Seed defaultSeedBackEnd
        }

        private static async Task SeedTicketPrioritiesAsync(ApplicationDbContext context)
        {
            try
            {
                // This line of code does the following.
                // Looks into the database of the TicketPriorities Model.
                // The lambda expression will then check the tp table and compare it to tp.Name to see if it has the name Low.
                // If it doesn't, it will go to the next step.
                // If it does have a name of Low, it will change Low as a priority in the database.
                if (!context.TicketPriorities.Any(tp => tp.Name == "Low"))
                {
                    // This is the next step. If the above code didn't have anything named Low in the database it will add Low to the database.
                    await context.TicketPriorities.AddAsync(new TicketPriority { Name = "Low" });
                }
                if (!context.TicketPriorities.Any(tp => tp.Name == "Normal"))
                {
                    await context.TicketPriorities.AddAsync(new TicketPriority { Name = "Normal" });
                }
                if (!context.TicketPriorities.Any(tp => tp.Name == "High"))
                {
                    await context.TicketPriorities.AddAsync(new TicketPriority { Name = "High" });
                }
                if (!context.TicketPriorities.Any(tp => tp.Name == "Critical"))
                {
                    await context.TicketPriorities.AddAsync(new TicketPriority { Name = "Critical" });
                }
                // This line of code saves the information to the database.
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Ticket Priorities.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
            };
        }

        private static async Task SeedTicketStatusesAsync(ApplicationDbContext context)
        {
            try
            {
                if (!context.TicketStatuses.Any(ts => ts.Name == "Open"))
                {
                    await context.TicketStatuses.AddAsync(new TicketStatus { Name = "Open" });
                }
                if (!context.TicketStatuses.Any(ts => ts.Name == "In Progress"))
                {
                    await context.TicketStatuses.AddAsync(new TicketStatus { Name = "In Progress" });
                }
                if (!context.TicketStatuses.Any(ts => ts.Name == "Pending"))
                {
                    await context.TicketStatuses.AddAsync(new TicketStatus { Name = "Pending" });
                }
                if (!context.TicketStatuses.Any(ts => ts.Name == "Resolved"))
                {
                    await context.TicketStatuses.AddAsync(new TicketStatus { Name = "Resolved" });
                }
                if (!context.TicketStatuses.Any(ts => ts.Name == "Closed"))
                {
                    await context.TicketStatuses.AddAsync(new TicketStatus { Name = "Closed" });
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Ticket Statuses.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
            };
        }

        private static async Task SeedProjectAsync(ApplicationDbContext context)
        {
            #region Portfolio Project Seed

            Project seedProject1 = new Project
            {
                Name = "Portfolio Project"
            };
            try
            {
                var project = context.Projects.Where(p => p.Name == "Portfolio Project").FirstOrDefault();
                if (project == null)
                {
                    await context.Projects.AddAsync(seedProject1);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Portfolio Project.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Portfolio Project Seed

            #region Blog Project Seed

            Project seedProject2 = new Project
            {
                Name = "Blog Project"
            };
            try
            {
                var project = context.Projects.Where(p => p.Name == "Blog Project").FirstOrDefault();
                if (project == null)
                {
                    await context.Projects.AddAsync(seedProject2);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Blog Project.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Blog Project Seed

            #region Bug Tracker Project Seed

            Project seedProject3 = new Project
            {
                Name = "Bug Tracker Project"
            };
            try
            {
                var project = context.Projects.Where(p => p.Name == "Bug Tracker Project").FirstOrDefault();
                if (project == null)
                {
                    await context.Projects.AddAsync(seedProject3);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Bug Tracker Project.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Bug Tracker Project Seed

            #region Financial Portfolio Project Seed

            Project seedProject4 = new Project
            {
                Name = "Get A Job"
            };
            try
            {
                var project = context.Projects.Where(p => p.Name == "Get A Job").FirstOrDefault();
                if (project == null)
                {
                    await context.Projects.AddAsync(seedProject4);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Get A Job Project.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Financial Portfolio Project Seed
        }

        private static async Task SeedProjectUsersAsync(ApplicationDbContext context, UserManager<BTUser> userManager)
        {
            string adminId = (await userManager.FindByEmailAsync("demoadmin@mailinator.com")).Id;
            string projectManagerId = (await userManager.FindByEmailAsync("demopm@mailinator.com")).Id;
            string developerId = (await userManager.FindByEmailAsync("demodeveloper@mailinator.com")).Id;
            string submitterId = (await userManager.FindByEmailAsync("demosubmitter@mailinator.com")).Id;

            int project1Id = (await context.Projects.FirstOrDefaultAsync(p => p.Name == "Portfolio Project")).Id;
            int project2Id = (await context.Projects.FirstOrDefaultAsync(p => p.Name == "Blog Project")).Id;
            int project3Id = (await context.Projects.FirstOrDefaultAsync(p => p.Name == "Bug Tracker Project")).Id;
            int project4Id = (await context.Projects.FirstOrDefaultAsync(p => p.Name == "Get A Job")).Id;

            #region Admin Project 1 Seed

            ProjectUser projectUser = new ProjectUser
            {
                UserId = adminId,
                ProjectId = project1Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == adminId && r.ProjectId == project1Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Admin Project 1.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Admin Project 1 Seed

            #region Admin Project 2 Seed

            projectUser = new ProjectUser
            {
                UserId = adminId,
                ProjectId = project2Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == adminId && r.ProjectId == project2Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Admin Project 2.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Admin Project 2 Seed

            #region Admin Project 3 Seed

            projectUser = new ProjectUser
            {
                UserId = adminId,
                ProjectId = project3Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == adminId && r.ProjectId == project3Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Admin Project 3.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Admin Project 3 Seed

            #region Admin Project 4 Seed

            projectUser = new ProjectUser
            {
                UserId = adminId,
                ProjectId = project4Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == adminId && r.ProjectId == project4Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Admin Project 4.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Admin Project 4 Seed

            #region Project Manager Project 1 Seed

            projectUser = new ProjectUser
            {
                UserId = projectManagerId,
                ProjectId = project1Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == projectManagerId && r.ProjectId == project1Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Project Manager Project 1.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Project Manager Project 1 Seed

            #region Project Manager Project 2 Seed

            projectUser = new ProjectUser
            {
                UserId = projectManagerId,
                ProjectId = project2Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == projectManagerId && r.ProjectId == project2Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Project Manager Project 2.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Project Manager Project 2 Seed

            #region Project Manager Project 3 Seed

            projectUser = new ProjectUser
            {
                UserId = projectManagerId,
                ProjectId = project3Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == projectManagerId && r.ProjectId == project3Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Project Manager Project 3.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Project Manager Project 3 Seed

            #region Project Manager Project 4 Seed

            projectUser = new ProjectUser
            {
                UserId = projectManagerId,
                ProjectId = project4Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == projectManagerId && r.ProjectId == project4Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Project Manager Project 4.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Project Manager Project 4 Seed

            #region Developer Project 1 Seed

            projectUser = new ProjectUser
            {
                UserId = developerId,
                ProjectId = project1Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == developerId && r.ProjectId == project1Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Developer Project 1.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Developer Project 1 Seed

            #region Developer Project 2 Seed

            projectUser = new ProjectUser
            {
                UserId = developerId,
                ProjectId = project2Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == developerId && r.ProjectId == project2Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Developer Project 2.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Developer Project 2 Seed

            #region Developer Project 3 Seed

            projectUser = new ProjectUser
            {
                UserId = developerId,
                ProjectId = project3Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == developerId && r.ProjectId == project3Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Developer Project 3.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Developer Project 3 Seed

            #region Developer Project 4 Seed

            projectUser = new ProjectUser
            {
                UserId = developerId,
                ProjectId = project4Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == developerId && r.ProjectId == project4Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Developer Project 4.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Developer Project 4 Seed

            #region Submitter Project 1 Seed

            projectUser = new ProjectUser
            {
                UserId = submitterId,
                ProjectId = project1Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == submitterId && r.ProjectId == project1Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Submitter Project 1.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Submitter Project 1 Seed

            #region Submitter Project 2 Seed

            projectUser = new ProjectUser
            {
                UserId = submitterId,
                ProjectId = project2Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == submitterId && r.ProjectId == project2Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Submitter Project 2.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Submitter Project 2 Seed

            #region Submitter Project 3 Seed

            projectUser = new ProjectUser
            {
                UserId = submitterId,
                ProjectId = project3Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == submitterId && r.ProjectId == project3Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Submitter Project 3.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Submitter Project 3 Seed

            #region Submitter Project 4 Seed

            projectUser = new ProjectUser
            {
                UserId = submitterId,
                ProjectId = project4Id
            };
            try
            {
                var record = await context.ProjectUsers.FirstOrDefaultAsync(r => r.UserId == submitterId && r.ProjectId == project4Id);
                if (record == null)
                {
                    await context.ProjectUsers.AddAsync(projectUser);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Submitter Project 4.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Submitter Project 4 Seed
        }

        private static async Task SeedTicketsAsync(ApplicationDbContext context, UserManager<BTUser> userManager)
        {
            string developerId = (await userManager.FindByEmailAsync("demodeveloper@mailinator.com")).Id;
            string submitterId = (await userManager.FindByEmailAsync("demosubmitter@mailinator.com")).Id;

            int project1Id = (await context.Projects.FirstOrDefaultAsync(p => p.Name == "Portfolio Project")).Id;
            int project2Id = (await context.Projects.FirstOrDefaultAsync(p => p.Name == "Blog Project")).Id;
            int project3Id = (await context.Projects.FirstOrDefaultAsync(p => p.Name == "Bug Tracker Project")).Id;
            int project4Id = (await context.Projects.FirstOrDefaultAsync(p => p.Name == "Get A Job")).Id;

            int statusId1 = (await context.TicketStatuses.FirstOrDefaultAsync(ts => ts.Name == "Open")).Id;
            int statusId2 = (await context.TicketStatuses.FirstOrDefaultAsync(ts => ts.Name == "In Progress")).Id;
            int statusId3 = (await context.TicketStatuses.FirstOrDefaultAsync(ts => ts.Name == "Pending")).Id;
            int statusId4 = (await context.TicketStatuses.FirstOrDefaultAsync(ts => ts.Name == "Resolved")).Id;
            int statusId5 = (await context.TicketStatuses.FirstOrDefaultAsync(ts => ts.Name == "Closed")).Id;

            int typeId1 = (await context.TicketTypes.FirstOrDefaultAsync(tt => tt.Name == "General")).Id;
            int typeId2 = (await context.TicketTypes.FirstOrDefaultAsync(tt => tt.Name == "UI")).Id;
            int typeId3 = (await context.TicketTypes.FirstOrDefaultAsync(tt => tt.Name == "Runtime")).Id;
            int typeId4 = (await context.TicketTypes.FirstOrDefaultAsync(tt => tt.Name == "BackEnd")).Id;

            int priorityId1 = (await context.TicketPriorities.FirstOrDefaultAsync(tp => tp.Name == "Low")).Id;
            int priorityId2 = (await context.TicketPriorities.FirstOrDefaultAsync(tp => tp.Name == "Normal")).Id;
            int priorityId3 = (await context.TicketPriorities.FirstOrDefaultAsync(tp => tp.Name == "High")).Id;
            int priorityId4 = (await context.TicketPriorities.FirstOrDefaultAsync(tp => tp.Name == "Critical")).Id;

            #region Demo Ticket 1 Project 1

            Ticket ticket = new Ticket
            {
                Title = "Create Links for Completed Projects",
                Description = "I need to create links in my portfolios projects section to allow viewers easy access to all of my completed projects.",
                Created = DateTime.Now.AddDays(-7),
                Updated = DateTime.Now.AddHours(-30),
                ProjectId = project1Id,
                TicketPriorityId = priorityId2,
                TicketTypeId = typeId3,
                TicketStatusId = statusId1,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 1 Project 1.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 1 Project 1

            #region Demo Ticket 2 Project 1

            ticket = new Ticket
            {
                Title = "Carve in a new template for my Portfolio",
                Description = "My portfolio needs a new template that is more stylish than the previous one. This task should be easier given the experience I currently have compared to when we initially did the portfolio project.",
                Created = DateTime.Now.AddDays(-3),
                Updated = DateTime.Now.AddHours(-53),
                ProjectId = project1Id,
                TicketPriorityId = priorityId1,
                TicketTypeId = typeId4,
                TicketStatusId = statusId2,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 2 Project 1.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 2 Project 1

            #region Demo Ticket 3 Project 1

            ticket = new Ticket
            {
                Title = "Share my Portfolio on Social Media",
                Description = "I need to share my portfolio on all my social media accounts that I have relating to my professional life. LinkedIn needs to be included, possibly as well as, Twitter, Instagram and maybe Facebook. I will most likely make it a link available on my GitHub as well as any other places I think I could possible find connections.",
                Created = DateTime.Now.AddDays(-10),
                Updated = DateTime.Now.AddHours(-15),
                ProjectId = project1Id,
                TicketPriorityId = priorityId2,
                TicketTypeId = typeId1,
                TicketStatusId = statusId3,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 3 Project 1.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 3 Project 1

            #region Demo Ticket 1 Project 2

            ticket = new Ticket
            {
                Title = "Complete the functionality of my Spare Code Blog",
                Description = "I need to complete the functionality that goes into my Spare Code Blog. This task should be easy to complete as I have gained a vast amount of knowledge in the last month or two. When we initially did the Blog Project, it was tough, but now as we have finished the Bug Tracker Project, my understanding of C# and .NET Core is a lot higher. I feel more confident now and believe I can knock this task out within a day.",
                Created = DateTime.Now.AddDays(-12),
                Updated = DateTime.Now.AddHours(-58),
                ProjectId = project2Id,
                TicketPriorityId = priorityId4,
                TicketTypeId = typeId2,
                TicketStatusId = statusId4,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 1 Project 2.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 1 Project 2

            #region Demo Ticket 2 Project 2

            ticket = new Ticket
            {
                Title = "Template my Spare Code Blog to look like my Portfolio",
                Description = "I need to make both my Spare Code Blog and my Portfolio have the same template. This will allow it to look more professional and would allow the user to see that the two are related.",
                Created = DateTime.Now.AddDays(-7),
                Updated = DateTime.Now.AddHours(-30),
                ProjectId = project2Id,
                TicketPriorityId = priorityId3,
                TicketTypeId = typeId3,
                TicketStatusId = statusId5,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 2 Project 2.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 2 Project 2

            #region Demo Ticket 3 Project 2

            ticket = new Ticket
            {
                Title = "Complete Writing my Blog Posts",
                Description = "I need to create links in my portfolios projects section to allow viewers easy access to all of my completed projects.",
                Created = DateTime.Now.AddDays(-7),
                Updated = DateTime.Now.AddHours(-30),
                ProjectId = project2Id,
                TicketPriorityId = priorityId1,
                TicketTypeId = typeId1,
                TicketStatusId = statusId1,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 3 Project 2.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 3 Project 2

            #region Demo Ticket 1 Project 3

            ticket = new Ticket
            {
                Title = "Block Certain Role Access",
                Description = "I need to block role access to certain links and pages.",
                Created = DateTime.Now.AddDays(-7),
                Updated = DateTime.Now.AddHours(-30),
                ProjectId = project3Id,
                TicketPriorityId = priorityId2,
                TicketTypeId = typeId2,
                TicketStatusId = statusId2,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 1 Project 3.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 1 Project 3

            #region Demo Ticket 2 Project 3

            ticket = new Ticket
            {
                Title = "Finish styling my template",
                Description = "I need to finish adding the final touches to my template and each view.",
                Created = DateTime.Now.AddDays(-7),
                Updated = DateTime.Now.AddHours(-30),
                ProjectId = project3Id,
                TicketPriorityId = priorityId4,
                TicketTypeId = typeId4,
                TicketStatusId = statusId3,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 2 Project 3.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 2 Project 3

            #region Demo Ticket 3 Project 3

            ticket = new Ticket
            {
                Title = "Finish adding in charts to the dashboard",
                Description = "Add in multiple charts to the dashboard so that users or roles have a better view of what they are tasked with.",
                Created = DateTime.Now.AddDays(-7),
                Updated = DateTime.Now.AddHours(-30),
                ProjectId = project3Id,
                TicketPriorityId = priorityId2,
                TicketTypeId = typeId3,
                TicketStatusId = statusId3,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 3 Project 3.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 3 Project 3

            #region Demo Ticket 1 Project 4

            ticket = new Ticket
            {
                Title = "Finish all Projects to Get A Job",
                Description = "Finalize my projects so that I can get a job this year.",
                Created = DateTime.Now.AddDays(-7),
                Updated = DateTime.Now.AddHours(-30),
                ProjectId = project4Id,
                TicketPriorityId = priorityId1,
                TicketTypeId = typeId1,
                TicketStatusId = statusId5,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 1 Project 4.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 1 Project 4

            #region Demo Ticket 2 Project 4

            ticket = new Ticket
            {
                Title = "I Am Excited To Go Down This Career Path",
                Description = "I am very excited to go down this career path. I am learning a lot and most importantly I am having a lot of fun learning it. Initially it was tough, but over time the more experience I got, the better it got. Now I get this feeling of joy and fulfillment when I code and especially when I find out how to solve a very tough issue. I can't wait to finally get into the career I've wanted to a while now and start learning even more.",
                Created = DateTime.Now.AddDays(-7),
                Updated = DateTime.Now.AddHours(-30),
                ProjectId = project4Id,
                TicketPriorityId = priorityId4,
                TicketTypeId = typeId2,
                TicketStatusId = statusId1,
                DeveloperUserId = developerId,
                OwnerUserId = submitterId
            };
            try
            {
                var newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.Title == ticket.Title);
                if (newTicket == null)
                {
                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("************* ERROR *************");
                Debug.WriteLine("Error Seeding Demo Ticket 2 Project 4.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("*********************************");
                throw;
            }

            #endregion Demo Ticket 2 Project 4
        }
    }
}