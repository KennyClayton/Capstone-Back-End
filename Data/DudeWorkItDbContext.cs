using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DudeWorkIt.Models;
using Microsoft.AspNetCore.Identity;

namespace DudeWorkIt.Data;
public class DudeWorkItDbContext : IdentityDbContext<IdentityUser> 
    //# DudeWorkItDbContext inherits from the IdentityDbContext<IdentityUser> class, rather than from DbContext
        //# IdentityDbContext comes with a number of extra models and tables that will be added to the database. They include:
        //# IdentityUser - this will hold login credentials for users
        //# IdentityRole - this will hold the various roles that a user can have
        //# IdentityUserRole - a many-to-many table between roles and users. These define which users have which roles.

{
    private readonly IConfiguration _configuration;
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectType> ProjectTypes { get; set; }
    public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public DudeWorkItDbContext(DbContextOptions<DudeWorkItDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //# this is a method

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[] //# seeding the database with the identityrole information
        {
        new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        },
        new IdentityRole
        {
            Id = "3bc7a629-88b1-4d36-8f2e-48a7969ad5da",
            Name = "Worker",
            NormalizedName = "worker"
        },
        new IdentityRole
        {
            Id = "9008fba6-93a0-412d-bc99-84a6cafb2be5",
            Name = "Customer",
            NormalizedName = "customer"
        }}
        );

        // "Represents user accounts, such as individual workers or customers."
        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[] //# seeding the database with the identityuser information
        {
        new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "admina@strator.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
        new IdentityUser
            {
                Id = "6f36bd3b-f3b7-4815-ba2a-3788a8469028",
                UserName = "TToney",
                Email = "tyler@toney.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "5389ca0b-0fb5-4ed0-8de5-27143f289661",
                UserName = "GHilbert",
                Email = "garrett@hilbert.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d",
                UserName = "CoryC",
                Email = "cory@cotton.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "1ee32cf6-e93c-49df-9696-97e2378d2181",
                UserName = "CobyC",
                Email = "coby@cotton.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "89e2d93c-f59c-44ad-a2ce-890617777f07",
                UserName = "CJones",
                Email = "cody@jones.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "68c01fff-1c37-4fe5-be33-d2f86f716361",
                UserName = "Panda",
                Email = "panda@monium.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            }
        }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
        {
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "3bc7a629-88b1-4d36-8f2e-48a7969ad5da", //~ worker role Id
                UserId = "6f36bd3b-f3b7-4815-ba2a-3788a8469028" // Tyler Toney
            },
            new IdentityUserRole<string>
            {
                RoleId = "9008fba6-93a0-412d-bc99-84a6cafb2be5", //$ customer role Id
                UserId = "5389ca0b-0fb5-4ed0-8de5-27143f289661" // Garrett Hilbert
            },
            new IdentityUserRole<string>
            {
                RoleId = "9008fba6-93a0-412d-bc99-84a6cafb2be5", //$ customer role Id
                UserId = "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d" // Cory Cotton
            },
            new IdentityUserRole<string>
            {
                RoleId = "9008fba6-93a0-412d-bc99-84a6cafb2be5", //$ customer role Id
                UserId = "1ee32cf6-e93c-49df-9696-97e2378d2181" // Coby Cotton
            },
            new IdentityUserRole<string>
            {
                RoleId = "9008fba6-93a0-412d-bc99-84a6cafb2be5", //$ customer role Id
                UserId = "89e2d93c-f59c-44ad-a2ce-890617777f07" // Cody Jones
            },
            new IdentityUserRole<string>
            {
                RoleId = "3bc7a629-88b1-4d36-8f2e-48a7969ad5da", //~ worker role Id
                UserId = "68c01fff-1c37-4fe5-be33-d2f86f716361" // Panda Monium
            }
        }
        );

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
                Id = 1,
                FirstName = "Admina",
                LastName = "Strator",
                Address = "101 Main Street",
                UserName = "Administrator",
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                Email = "admina@strator.comx"
            },
            new UserProfile
            {
                Id = 2,
                FirstName = "Tyler",
                LastName = "Toney",
                Address = "202 Broad Street",
                UserName = "TToney",
                IdentityUserId = "6f36bd3b-f3b7-4815-ba2a-3788a8469028",
                Email = "tyler@toney.com"
            },
            new UserProfile
            {
                Id = 3,
                FirstName = "Garrett",
                LastName = "Hilbert",
                Address = "303 Frisco Blvd",
                UserName = "GHilbert",
                IdentityUserId = "5389ca0b-0fb5-4ed0-8de5-27143f289661",
                Email = "garrett@hilbert.com"
            },
            new UserProfile
            {
                Id = 4,
                FirstName = "Cory",
                LastName = "Cotton",
                Address = "2110 Gulf ROad",
                UserName = "CoryC",
                IdentityUserId = "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d",
                Email = "cory@cotton.com"
            },
            new UserProfile
            {
                Id = 5,
                FirstName = "Coby",
                LastName = "Cotton",
                Address = "1300 Atlantic Blvd",
                UserName = "CobyC",
                IdentityUserId = "1ee32cf6-e93c-49df-9696-97e2378d2181",
                Email = "coby@cotton.com"
            },
            new UserProfile
            {
                Id = 6,
                FirstName = "Cody",
                LastName = "Jones",
                Address = "1450 Terrace View Lane",
                UserName = "CJones",
                IdentityUserId = "89e2d93c-f59c-44ad-a2ce-890617777f07",
                Email = "cody@jones.com"
            },
            new UserProfile
            {
                Id = 7,
                FirstName = "Panda",
                LastName = "Monium",
                Address = "1600 Mascot Circle",
                UserName = "Panda",
                IdentityUserId = "68c01fff-1c37-4fe5-be33-d2f86f716361",
                Email = "panda@monium.com"
            }
        }
        );

        modelBuilder.Entity<Project>().HasData(new Project[]
        {
            new Project
            {
                Id = 1,
                UserProfileId = 3, //$ This is the customer's UserProfileId value. Garrett is a customer creating this project, but I also need to associate this project with a worker when the worker chooses to work this project
                ProjectTypeId = 1, // lawn maintenance
                DateOfProject = new DateTime(2023, 11, 12, 11, 0, 0), //$ this should be selected by the customer user when creating a project
                CompletedOn = new DateTime(2023, 11, 12, 14, 0, 0), //~ This is completed by the worker
                Description = "Mulch the flower beds and mow the yard" //$ Customer completes this
                },
            new Project
            {
                Id = 2,
                UserProfileId = 4, // customer Cory Cotton
                ProjectTypeId = 2, // painting
                DateOfProject = new DateTime(2023, 11, 12, 8, 0, 0), // 2pm
                CompletedOn = new DateTime(2023, 11, 12, 16, 0, 0),
                Description = "My garage needs to be painted. It's about 24 x 24 and I have all the paint and supplies. I can pay $15/hour."
                },
            new Project
            {
                Id = 3,
                UserProfileId = 5, // customer Coby Cotton
                ProjectTypeId = 3, // moving
                DateOfProject = new DateTime(2023, 11, 13, 9, 0, 0), // 9am
                CompletedOn = null,
                Description = "I need help loading a moving truck"
                },
            new Project
            {
                Id = 4,
                UserProfileId = 6, // customer Cody Jones
                ProjectTypeId = 8, // junk removal
                DateOfProject = new DateTime(2023, 11, 14, 11, 30, 0), // 11:30am
                CompletedOn = null,
                Description = "Need to haul away a bunch of old furniture"
                },
                new Project
            {
                Id = 5,
                UserProfileId = 6, // customer Cody Jones
                ProjectTypeId = 7, // gutters
                DateOfProject = new DateTime(2023, 11, 14, 11, 30, 0), // 11:30am
                CompletedOn = null,
                Description = "I think my gutters are clogged, and they ain't gonna clean themselves. Hurry up."
                }
        });

        modelBuilder.Entity<ProjectType>().HasData(new ProjectType[]
        {
            new ProjectType {Id = 1, Name = "Lawn Maintenance"},
            new ProjectType {Id = 2, Name = "Painting"},
            new ProjectType {Id = 3, Name = "Moving"},
            new ProjectType {Id = 4, Name = "Fencing"},
            new ProjectType {Id = 5, Name = "Insulation"},
            new ProjectType {Id = 6, Name = "General Labor"},
            new ProjectType {Id = 7, Name = "Gutters"},
            new ProjectType {Id = 8, Name = "Junk Removal"},
            new ProjectType {Id = 9, Name = "Organizing"},
            new ProjectType {Id = 10, Name = "Volunteer"}
        });

        modelBuilder.Entity<ProjectAssignment>().HasData(new ProjectAssignment[] //^ This class assigns a WORKER UserProfileId to a project. Remember that customers create the projects so their UserProfileId is already associated with each project.
        {
            new ProjectAssignment
            {
                Id = 1,
                UserProfileId = 2, // Tyler is the worker that will get this job
                ProjectId = 1,
                ProjectTypeId = 1
            },
            new ProjectAssignment
            {
                Id = 2,
                UserProfileId = 7, // Panda is the worker that will get this job
                ProjectId = 2,
                ProjectTypeId = 2
            },
            new ProjectAssignment
            {
                Id = 3,
                UserProfileId = null, // no worker set to this job yet
                ProjectId = 3,
                ProjectTypeId = 3
            },
            new ProjectAssignment
            {
                Id = 4,
                UserProfileId = null, // no worker set to this job yet
                ProjectId = 4,
                ProjectTypeId = 8
            },
            new ProjectAssignment
            {
                Id = 5,
                UserProfileId = 2, // Tyler is the worker that will get this job
                ProjectId = 5,
                ProjectTypeId = 7
            }
        });
    }
}