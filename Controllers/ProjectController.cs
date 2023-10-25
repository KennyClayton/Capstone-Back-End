using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DudeWorkIt.Data;
using Microsoft.EntityFrameworkCore;
using DudeWorkIt.Models;
using System.Security.Claims;

namespace DudeWorkIt.Controllers;

[ApiController]
[Route("api/[controller]")]
//# all of the endpoints in this controller will have URLs that start with "/api/project" (it is case insensitive?)
public class ProjectController : ControllerBase
{
    private DudeWorkItDbContext _dbContext;

    public ProjectController(DudeWorkItDbContext context)
    {
        _dbContext = context;
    }

    //^ GET - Get all projects
    [HttpGet] //# this endpoint on the server is "/api/project"
    // [Authorize(Roles = "Customer")] //! authorize only customers
    public IActionResult Get() //# this Get method is an endpoint to get all projects
    {
        var projects = _dbContext.Projects
        .Include(p => p.UserProfile)
        .ToList();
        return Ok(projects);
        //# The Ok method that gets called inside Get will create an HTTP response with a status of 200, as well as the data that's passed in.
    }

    //^ GET - Get projects by id
    [HttpGet("{id}")] //# this endpoint on the server is "/api/project/{id}"
    // [Authorize(Roles = "Customer")] //! authorize only customers
    public IActionResult GetById(int id)
    {
        Project project = _dbContext
            .Projects
            .Include(p => p.UserProfile)
            .Include(p => p.ProjectType)
            .SingleOrDefault(p => p.Id == id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    //^ GET - Get ONLY the projects where the logged-in user's UserProfile.Id matches the project's UserProfileId
    [HttpGet("user-projects")] //# this endpoint on the server is "/api/project/user-projects"
    // [Authorize(Roles = "Customer")]
    public IActionResult GetUserProjects()
    {
        // Get the currently signed-in user's ID from the claims. This uses something built into ASP.NET Core. As ChatGPT explained "You can access claims in your ASP.NET Core application code. Claims are typically stored in an instance of ClaimsPrincipal. The claims for the current user can be accessed via User.Claims. This is how you can retrieve information about the currently logged-in user." 
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Retrieve projects that belong to the current user.
        var projects = _dbContext
            .Projects
            .Include(p => p.ProjectAssignments)
            .ThenInclude(pa => pa.UserProfile)
            // .ThenInclude(up => up.FullName)
            .Include(p => p.UserProfile)
            .ThenInclude(up => up.ProjectAssignments)
            .Include(p => p.ProjectType)
            .Where(p => p.UserProfile.IdentityUserId == userId)
            .ToList();

        // var assignments = _dbContext
        // .ProjectAssignments
        // .Include(pa => pa.UserProfile)
        // .Include(pa => pa.Project)
        // .ToList();

        // var matchingProjects = projects.Cast<object>().Concat(assignments.Cast<object>()).ToList();
        // return Ok(matchingProjects);

        return Ok(projects);
    }

    //^ POST - This endpoint will map to a POST request with the url /api/project
    [HttpPost]
    // [Authorize(Roles = "Customer")]
    public IActionResult CreateProject(Project project)
    {
        // project.DateInitiated = DateTime.Now; // I am not using this property on my Project entity
        _dbContext.Projects.Add(project);
        _dbContext.SaveChanges();
        return Created($"/api/project/{project.Id}", project);
    }

    //^ DELETE - This end point will delete a single project by Id
    [HttpDelete("{id}")]
    // [Authorize(Roles = "Customer")]
    public IActionResult DeleteProjectById(int id)
    {
        // Find the project order by its ID
        Project projectToDelete = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

        if (projectToDelete == null)
        {
            // If the project with the specified ID does not exist, return a "Not Found" response
            return NotFound();
        }

        // Remove the project from the database
        _dbContext.Projects.Remove(projectToDelete);
        _dbContext.SaveChanges();

        // Return a "No Content" response to indicate successful deletion
        return NoContent();
    }

    
}

//^ NEW FOR PROJECT TYPES
//& NEW FOR PROJECT TYPES
//* NEW FOR PROJECT TYPES


[ApiController]
[Route("api/projecttype")]
//# all of the endpoints in this controller will have URLs that start with "/api/project" (it is case insensitive?)
public class ProjectTypeController : ControllerBase
{
    private DudeWorkItDbContext _dbContext;

    public ProjectTypeController(DudeWorkItDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet] //# this endpoint on the server is "/api/project"
    // [Authorize(Roles = "Customer")] //! authorize only customers
    public IActionResult Get() //# this Get method is an endpoint to get all projects
    {
        var projecttypes = _dbContext.ProjectTypes.ToList();
        return Ok(projecttypes);
        //# The Ok method that gets called inside Get will create an HTTP response with a status of 200, as well as the data that's passed in.
    }
}







//* MUY IMPORTANTE!!! On line 62, I am telling the server to look at the userProfile table in the database and to grab any ProjectAssignment objects it sees on the UserProfile table. If we look at the UserProfile class here on the server side, we can see that a List of ProjectAssignments was included in the class/table. So now we can acess those projectAssignment objects here by telling the server to Include UserProfile and ThenInclude the projectAssignments too. 
//$ Now look at the front end projectManager.js component. In there we defined a function called "getUserProjects". In that function we defined a GET request which is what sends the http GET request to this particular "user-projects" endpoint on the server. 
//& Remember! The "getUserProjects" function in projectManager.js is DEFINED in the projectManager.js module, but the "getUserProjects" function is not CALLED yet. Go look at the useEffect inside of the ProjectList.js component. You can see that the useEffect calls the getAllProjectsByUserId function which is defined just above th useEffect. Look at that getAllProjectsByUserId function and you will see that this is where "getUserProjects" is finally run and GET request is actually sent to the server at that moment (when the useEffect runs...which is when the ProjectsList component mounts). 