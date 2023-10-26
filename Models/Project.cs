namespace DudeWorkIt.Models;

public class Project
{
    public int Id { get; set; }
    public int UserProfileId { get; set; } 
    public UserProfile UserProfile { get; set; }
    public int ProjectTypeId { get; set; } 
    public ProjectType? ProjectType { get; set; }
    public DateTime DateOfProject { get; set; }
    public DateTime? CompletedOn { get; set; }
    public string Description { get; set; }
    public List<ProjectAssignment>? ProjectAssignments { get; set; }

}

//* IMPORTANT
//$ FOR FUTURE REFERENCE: It is much easier to reference a worker's userprofile and a customer's userprofile by adding two UserProfile types here in the Project entity. Like we did in Shepherd's Pies, I should have had a public UserProfile Worker and public UserProfile Customer. Below is how we entered them in Order.cs of Shepherd's Pies:
//~     [ForeignKey("DriverId")]
//~     public UserProfile Driver { get; set; }    
//~     [ForeignKey("EmployeeId")]
//~     public UserProfile Employee { get; set; }