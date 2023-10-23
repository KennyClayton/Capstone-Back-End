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

    [HttpGet]
    // [Authorize(Roles = "Customer")] //! authorize only customers
    public IActionResult Get() //# this Get method is an endpoint to get all projects
    {
        var projects = _dbContext.Projects
        .Include(p => p.UserProfile)
        .ToList();
        return Ok(projects);
        //# The Ok method that gets called inside Get will create an HTTP response with a status of 200, as well as the data that's passed in.
    }
    
    //^ Added this endpoint below to get projects by id
    [HttpGet("{id}")]
    // [Authorize]
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
}