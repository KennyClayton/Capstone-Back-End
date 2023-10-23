using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DudeWorkIt.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string IdentityUserId { get; set; }
    public IdentityUser IdentityUser { get; set; }
    [NotMapped]
    public string UserName { get; set; }
    [NotMapped]
    public string Email { get; set; }
    [NotMapped] // not mapped means that EF Core won't create column for this property in the db
    public List<string> Roles { get; set; }
    public List<ProjectAssignment> ProjectAssignments { get; set; }
    [NotMapped] // Computed property (not stored in the database)
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

}


// Explanation for including a list here: 
// "Association: A user (worker or customer) can be associated with multiple project assignments. Each project assignment represents the connection between a user and a specific project, indicating whether they are working on that project."
// "Navigation: Including a list of ProjectAssignment objects in the UserProfile class allows you to easily navigate from a user's profile to their associated project assignments. This is important for displaying a user's list of projects in the user interface and managing their work assignments.
// "Data Retrieval: Having a reference to a user's project assignments directly in the UserProfile can simplify data retrieval. You can quickly query and retrieve a user's work assignments without the need for complex database queries."
// "Data Modeling: In a relational database model, it's common to establish relationships between entities. If users are related to project assignments, representing this relationship in the data model is a good practice."