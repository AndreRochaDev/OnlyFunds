namespace OnlyFunds.Perfis.Models;

public class Profile
{
    public int IdProfile { get; set; }
    public string? Description { get; set; }

    public Profile() { }

    public Profile(int id, string description)
    {
        IdProfile = id;
        Description = description;
    }
}