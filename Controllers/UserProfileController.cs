using Microsoft.AspNetCore.Authorization; // this is a namespace to "...import classes and types related to authorization in an ASP.NET Core application"
using Microsoft.AspNetCore.Mvc; // this is a namespace to "import classes and types related to creating and handling web API controllers in an ASP.NET Core application. MVC (Model-View-Controller) is a design pattern used for building web applications."
using DudeWorkIt.Data; // namespace that "contain[s] data models and context classes for your application"
using Microsoft.EntityFrameworkCore; // namespace "Entity Framework Core is an Object-Relational Mapping (ORM) framework used for database interactions in ASP.NET Core applications"
using DudeWorkIt.Models; // namespace "...containing data models or view models for your application. Models are used to represent data structures in your application."
using Microsoft.AspNetCore.Identity; // namespace "...ASP.NET Core Identity is a framework for managing user accounts, including user registration, authentication, and authorization."

namespace DudeWorkIt.Controllers; // "This line DECLARES a new namespace called DudeWorkIt.Controllers. Namespaces are used to organize and group related classes and types in C#."

[ApiController] // "This attribute is applied to the class and indicates that it's an API controller. It's part of ASP.NET Core's Web API feature, which simplifies the process of building API controllers for handling HTTP requests."
[Route("api/[controller]")] // "This attribute specifies a route template for the API controller. In this case, it indicates that this controller will handle requests under the "api" route segment, followed by the controller name. The [controller] token is a placeholder that will be replaced with the controller's name."
public class UserProfileController : ControllerBase // "This line declares a C# class named UserProfileController that inherits from ControllerBase. The class represents a controller in your application, likely responsible for handling HTTP requests related to user profiles. ControllerBase is a base class provided by ASP.NET Core for creating controllers in web applications."
{
    private DudeWorkItDbContext _dbContext;

    public UserProfileController(DudeWorkItDbContext context)
    {
        _dbContext = context;
    }

    //# "This method from the UserProfileController gets the data for all users. This data should only be available to Admin users (it will be used to terminate employees, hire new ones, as well as upgrading an employee to be an Admin). [Authorize(Roles = "Admin")] ensures that this resource will only be accessible to authenticated users that also have the Admin role associated with their user id. A logged in user that is not an Admin will receive a 403 (Forbidden) response when trying to access this resource."

//* GET all UserProfiles is working
    [HttpGet]
    // [Authorize]
    public IActionResult Get() // this method is being applied to the handler below
    {
        return Ok(_dbContext.UserProfiles.ToList());
    }

//! I don't know how to authorize in Postman. I want to make sure only worker UserProfiles are returned, but right now ALL user profiles are being returned
    [HttpGet("withworkerroles")]
    // [Authorize(Roles = "Worker")]
    public IActionResult GetWorkerRoles() // this is a method signature that returns an IActionResult
    {
        // "The query [below] gets user profiles, then searches for user roles associated with the profile, and maps each of those to role names."
        return Ok(_dbContext.UserProfiles  //* Return a list of userprofiles
        .Include(up => up.IdentityUser) // "This part of the query indicates that you want to load related data from the "IdentityUser" table when retrieving user profiles"
        .Select(up => new UserProfile //* IMPORTANT - What does this line do? "For each user profile (up), it creates a new UserProfile object with specific properties."
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.Email,
            UserName = up.UserName,
            IdentityUserId = up.IdentityUserId,
            ProjectAssignments = up.ProjectAssignments,
            // Roles = _dbContext.UserRoles
            // .Where(ur => ur.UserId == up.IdentityUserId)
            // .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            // .ToList()
        }));
    }

    [HttpGet("withcustomerroles")]
    // [Authorize(Roles = "Customer")]
    public IActionResult GetCustomerRoles()
    {
        // "The query [below] gets user profiles, then searches for user roles associated with the profile, and maps each of those to role names."
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.Email,
            UserName = up.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        })
        );
    }

    // //^GET /api/userprofile/{id}
    // [HttpGet("{id}")]
    // // [Authorize] // no role specified here so that ANY logged in user can access this

    // public IActionResult GetWorkerProfileWithProjects(int id) //? why are we using a string data type on Id property in some foreign keys? I changed it to int here as the parameter
    // {
    //     return Ok(_dbContext.UserProfiles
    //         .Include(up => up.ProjectAssignments)
    //             .ThenInclude(pa => pa.Project)
    //         .Include(up => up.ProjectAssignments)
    //             .ThenInclude(pa => pa.Project)
    //         .SingleOrDefault(up => up.Id == id)); //single out the matching results of the where filter above.
    // }

}




// 10/19/2023 at 3:05pm - Commented out below promote and demote because I won't need them in my project
// [HttpPost("promote/{id}")]
// [Authorize(Roles = "Admin")]
// public IActionResult Promote(string id)
// {
//     IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
//     // This will create a new row in the many-to-many UserRoles table.
//     _dbContext.UserRoles.Add(new IdentityUserRole<string>
//     {
//         RoleId = role.Id,
//         UserId = id
//     });
//     _dbContext.SaveChanges();
//     return NoContent();
// }

// [HttpPost("demote/{id}")]
// [Authorize(Roles = "Admin")]
// public IActionResult Demote(string id)
// {
//     IdentityRole role = _dbContext.Roles
//         .SingleOrDefault(r => r.Name == "Admin");
//     IdentityUserRole<string> userRole = _dbContext
//         .UserRoles
//         .SingleOrDefault(ur =>
//             ur.RoleId == role.Id &&
//             ur.UserId == id);

//     _dbContext.UserRoles.Remove(userRole);
//     _dbContext.SaveChanges();
//     return NoContent();
// }




//~ NOTES:
// What does this module do? This module defines the API endpoints for user profiles.
// Controllers handle incoming HTTP requests and provide responses.
// End points are where our browsers go on a server to retrieve data like images, text, code
// "These endpoints are where clients, like web browsers, interact with the server to access and manipulate user profile data."
