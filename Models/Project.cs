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