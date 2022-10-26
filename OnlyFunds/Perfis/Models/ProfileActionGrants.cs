namespace OnlyFunds.Perfis.Models;

public class ProfileActionGrants
{
    public int IdProfile { get; set; }
    public List<SystemAction>? SystemActionGrants { get; set; } = new();
}