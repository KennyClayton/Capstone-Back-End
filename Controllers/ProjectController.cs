using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DudeWorkIt.Data;
using Microsoft.EntityFrameworkCore;
using DudeWorkIt.Models;
using System.Security.Claims;

namespace DudeWorkIt.Controllers;

//* This Controller ASSEMBLES the data from the database and stores it in an "endpoint" and then the projectManager.js file FETCHES or comes to pick up the little boxes of assembled data when called to do so.

[ApiController]
[Route("api/[controller]")]
//# all of the endpoints in this controller will have URLs that start with "/api/project" (it is case insensitive?)
public class ProjectController : ControllerBase
{
    private DudeWorkItDbContext _dbContext;
    public ProjectController(DudeWorkItDbContext context)
    {
        _dbContext = context;
        Console.WriteLine("testing");
    }

    //^1 GET - Get all projects
    [HttpGet] //# this endpoint on the server is "/api/project"
    // [Authorize(Roles = "Customer")] //! authorize only customers
    public IActionResult Get() //# this Get method is an endpoint to get all projects
    {
        var projects = _dbContext.Projects
        .Include(p => p.ProjectAssignments)
        .ThenInclude(pa => pa.UserProfile)
        .Include(p => p.UserProfile)
        .ToList();
        return Ok(projects);
        //# The Ok method that gets called inside Get will create an HTTP response with a status of 200, as well as the data that's passed in.
    }

    //^2 GET - Get projects by id
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

    //^3 GET - Get ONLY the projects where the logged-in user's UserProfile.Id matches the project's UserProfileId
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
            .Include(p => p.UserProfile)
            .ThenInclude(up => up.ProjectAssignments)
            .Include(p => p.ProjectType)
            .Where(p => p.UserProfile.IdentityUserId == userId)
            .ToList();

        // now that we have a list of projects we can shape each project and the properties on it
        // Modify the projects to include worker's full name
        var projectsWithWorkerFullNames = projects.Select(p => new
        {
            p.UserProfileId,
            p.Id,
            p.ProjectType,
            p.DateOfProject,
            p.CompletedOn,
            p.Description,
            WorkerFullName = p.ProjectAssignments
                .Select(pa => pa.UserProfile?.FullName) //* Read more about this question mark at the bottom
                .FirstOrDefault()
        }).ToList();

        return Ok(projectsWithWorkerFullNames);
    }

    //^4 POST - This endpoint will map to a POST request with the url /api/project
    [HttpPost]
    // [Authorize(Roles = "Customer")]
    public IActionResult CreateProject(Project project)
    {
        _dbContext.Projects.Add(project);
        _dbContext.SaveChanges();
        var newProjectId = project.Id;
        ProjectAssignment newProjectAssignment = new ProjectAssignment() {
            ProjectId = newProjectId,
            ProjectTypeId = project.ProjectTypeId,
            UserProfileId = null
        };
        _dbContext.ProjectAssignments.Add(newProjectAssignment);
        _dbContext.SaveChanges();
        return Created($"/api/project/{project.Id}", project);
    }

    //^5 DELETE - This end point will delete a single project by Id
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

    //^6 PUT - Update/Edit the details of a project
    [HttpPut("{id}")]
    // [Authorize(Roles = "Customer")]
    public IActionResult UpdateProject(Project project, int id)
    {
        // find the project by Id and store it in a variable
        Project projectToUpdate = _dbContext.Projects
        
        // .Include(p => p.ProjectType)
        .SingleOrDefault(p => p.Id == id);
        if (projectToUpdate == null)
        {
            return NotFound();
        }
        else if (id != project.Id)
        {
            return BadRequest();
        }
        projectToUpdate.ProjectType = project.ProjectType;
        projectToUpdate.DateOfProject = project.DateOfProject;
        projectToUpdate.Description = project.Description; // the new description value will go into the project.Description value

        _dbContext.SaveChanges(); 
        
        // now update the corresponding projectAssignment...I need the projectId from the above project to reference below
        //in the next line I am trying to capture the Id of the project which the Customer is updating, but I may be able to do that with the lines of code below that instead...?
        // var paId = projectToUpdate.Id; //the "paId" variable should now hold the same integer as the Id of the project the Customer just updated above
        // ok, now below I will get the same projectAssignment object that corresponds to the matching project and then store it in the projectAssignmentToUpdate variable
        ProjectAssignment projectAssignmentToUpdate = _dbContext.ProjectAssignments
        .SingleOrDefault(pa => pa.ProjectId == id);
        //Now take that object in the database and update its ProjectTypeId to match the project's ProjectTypeId
        // Console.WriteLine("HERE I AM:" + id);
        projectAssignmentToUpdate.ProjectType = project.ProjectType;
        // Console.WriteLine("HERE I AM AGAIN:" + project.ProjectType.Name);
        _dbContext.SaveChanges();
        return NoContent();
    }

}

//^ ---------- ENDPOINTS for ProjectTypes ---------- //^
//$ ---------- ENDPOINTS for ProjectTypes ---------- //$
//~ ---------- ENDPOINTS for ProjectTypes ---------- //~

[ApiController]
[Route("api/projecttype")]
//# all of the endpoints in this controller will have URLs that start with "/api/projecttype" (it is case insensitive?)
public class ProjectTypeController : ControllerBase
{
    private DudeWorkItDbContext _dbContext;

    public ProjectTypeController(DudeWorkItDbContext context)
    {
        _dbContext = context;
    }
    //^7 GET - This endpoint will fetch all project types from the database
    [HttpGet] //# this endpoint on the server is "/api/project"
    // [Authorize(Roles = "Customer")] //! authorize only customers
    public IActionResult Get() //# this Get method is an endpoint to get all projects
    {
        var projecttypes = _dbContext.ProjectTypes.ToList();
        return Ok(projecttypes);
        //# The Ok method that gets called inside Get will create an HTTP response with a status of 200, as well as the data that's passed in.
    }
}


//^ ---------- ENDPOINTS for ProjectAssignments ---------- //^
//$ ---------- ENDPOINTS for ProjectAssignments ---------- //$
//~ ---------- ENDPOINTS for ProjectAssignments ---------- //~

[ApiController]
[Route("api/projectassignment")]
//# all of the endpoints in this controller will have URLs that start with "/api/projectassignment"
public class ProjectAssignmentController : ControllerBase
{
    private DudeWorkItDbContext _dbContext;

    public ProjectAssignmentController(DudeWorkItDbContext context)
    {
        _dbContext = context;
    }
    //^8 GET - This endpoint will fetch a list of all projectAssignments from the database
    //! NO CURRENT NEED FOR THIS ENDPOINT
    [HttpGet] //# The URL will end with "/api/projectAssignment"
    public IActionResult GetAllProjectAssignments()
    {
        var assignments = _dbContext.ProjectAssignments
            .Include(pa => pa.UserProfile)
            .Include(pa => pa.Project)
                .ThenInclude(p => p.UserProfile)
            .Include(pa => pa.ProjectType)
            .ToList();
        if (assignments == null)
        {
            return NotFound();
        }
        return Ok(assignments);
    }

    //^9 GET - This endpoint will fetch a list of all projectAssignments by WORKER'S UserProfileId value
    [HttpGet("worker-projects/{id}")] //# this endpoint on the server is "/api/projectassignment/worker-projects/{id}"
    public IActionResult GetWorkerProjectAssignments(int id)
    {
        var workerAssignments = _dbContext.ProjectAssignments
            .Include(pa => pa.UserProfile)
            .Include(pa => pa.Project)
                .ThenInclude(p => p.UserProfile)
            .Include(pa => pa.ProjectType)
            .Where(pa => pa.UserProfile.Id == id)
            .ToList();
        if (workerAssignments == null)
        {
            return NotFound();
        }
        return Ok(workerAssignments);
    }


    //^10 GET - This endpoint will fetch a list of all projectAssignments with no UserProfile value (unassigned)
    [HttpGet("unassigned-worker-projects")] //# this endpoint on the server is "/api/projectassignment/unassigned-worker-projects"
    public IActionResult getAllUnassignedProjectAssignments() //! I think I need to make sure the ProjectTypeId gets up
    {
        var unassignedProjectAssignments = _dbContext.ProjectAssignments
            .Include(pa => pa.UserProfile)
            .Include(pa => pa.Project)
                .ThenInclude(p => p.UserProfile)
            .Include(pa => pa.ProjectType)
            //.Include(pa => pa.ProjectType) //! I am commenting this out because I don't think I need to retrieve this again...and I have realized I don't need this colun in the projectAssignments table at all!!! There is no reason to fetch the projectType from the list/table of projectAssignments...I already have the projectType under the list of projects....AND, importantly, the Customers who collectively generate that list of projects are the ones who update those details....and those updates are always reflected in the projects list...so there is no reason to separately list the projectAssignmentType under the projectAssignemnts list/table and then force myself to update that table and then fetch it .... that's pointless. I am guessing this is some sort of principle in programming where you keep a single source of truth and limit how many ways to get a piece of data.
            .Where(pa => pa.UserProfile == null)
            .ToList();
        return Ok(unassignedProjectAssignments);
    }


    //^11 - PUT - This endpoint will update a ProjectAssignment's UserProfile property
    [HttpPut("{id}")]
    // [Authorize(Roles = "Customer")]
    public IActionResult UpdateProjectAssignment(ProjectAssignment projectAssignment, int id)
    {
        // find the project by Id and store it in a variable
        ProjectAssignment projectAssignmentToUpdate = _dbContext.ProjectAssignments
        .Include(pa => pa.UserProfile)
        .SingleOrDefault(pa => pa.Id == id);
        if (projectAssignmentToUpdate == null)
        {
            return NotFound();
        }
        else if (id != projectAssignment.Id)
        {
            return BadRequest();
        }
        projectAssignmentToUpdate.UserProfile = projectAssignment.UserProfile;
        // the new description value will go into the project.Description value

        _dbContext.SaveChanges();
        return NoContent();
    }

    //^12 POST - This endpoint will map to a POST request with the url /api/projectAssignment
    [HttpPost]
    // [Authorize(Roles = "Customer")]
    public IActionResult CreateProjectAssignment(ProjectAssignment projectAssignment)
    {
        _dbContext.ProjectAssignments.Add(projectAssignment);
        _dbContext.SaveChanges();
        return Created($"/api/projectAssignment/{projectAssignment.Id}", projectAssignment);
    }


}




//* MUY IMPORTANTE!!! On line 62, I am telling the server to look at the userProfile table in the database and to grab any ProjectAssignment objects it sees on the UserProfile table. If we look at the UserProfile class here on the server side, we can see that a List of ProjectAssignments was included in the class/table. So now we can acess those projectAssignment objects here by telling the server to Include UserProfile and ThenInclude the projectAssignments too. 
//$ Now look at the front end projectManager.js component. In there we defined a function called "getUserProjects". In that function we defined a GET request which is what sends the http GET request to this particular "user-projects" endpoint on the server. 
//& Remember! The "getUserProjects" function in projectManager.js is DEFINED in the projectManager.js module, but the "getUserProjects" function is not CALLED yet. Go look at the useEffect inside of the ProjectList.js component. You can see that the useEffect calls the getAllProjectsByUserId function which is defined just above th useEffect. Look at that getAllProjectsByUserId function and you will see that this is where "getUserProjects" is finally run and GET request is actually sent to the server at that moment (when the useEffect runs...which is when the ProjectsList component mounts). 


//* IMPORTANT - Why did I have to use the question mark on this line of code <.Select(pa => pa.UserProfile?.FullName))>?
//* Because I am trying to access the FullName property of a UserProfile object, which is null for some of the ProjectAssignments.
//* Why are some of those FullName properties null? Because some of the projects are not assigned to a worker yet, so the FullName property is empty/null on those projects
//* SO what does the question mark (aka null conditional operator) do? It checks whether UserProfile is null before accessing the FullName property.
//* With the null conditional operator (?) after UserProfile, if UserProfile is null for any ProjectAssignment it will return 'null' for WorkerFullName instead of throwing a NullReferenceException.
//* From Chat GPT: "Make sure to apply this change consistently in your code wherever you are accessing properties of objects that may be null. This will help you handle potential null values and prevent exceptions."