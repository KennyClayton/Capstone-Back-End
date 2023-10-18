namespace DudeWorkIt.Models;

public class Registration
{
    public string Role { get; set; } // this is so a user can select their role as a worker or customer
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}