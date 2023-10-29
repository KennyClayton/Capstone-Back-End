namespace DudeWorkIt.Models;

public class ProjectAssignment
{
    public int Id { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; } // "A navigation property, allowing you to access the user associated with this assignment."
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    // public List<Project> Projects { get; set; }
    public int ProjectTypeId { get; set; }
    public ProjectType? ProjectType { get; set; }

}