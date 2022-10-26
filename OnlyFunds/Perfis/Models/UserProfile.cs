namespace OnlyFunds.Perfis.Models;

public class UserProfile
{
    public int IdUser { get; set; }
    public List<int> ProfileIds { get; set; } = new();
}