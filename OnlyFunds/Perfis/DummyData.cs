using OnlyFunds.Perfis.Models;

namespace OnlyFunds.Perfis;

public static class DummyData
{
    public static List<SystemAction> SystemActions { get; set; } = new();
    public static List<Profile> Profiles { get; set; } = new();
    public static UserProfile UserProfile { get; set; } = new();
    public static List<ProfileActionGrants> ProfileActionGrants { get; set; } = new();
    private static bool _alreadyGenerated = false;

    public static void LoadInitialData()
    {
        if (_alreadyGenerated) return;
        CreateSystemActions();
        CreateProfiles();
        CreateProfileActionGrants();
        CreateUserProfiles();
        _alreadyGenerated = true;
    }

    public static IEnumerable<SystemAction>? GetProfileSystemActionGrants(int idProfile)
    {
        var profileActionGrants = ProfileActionGrants
            .FirstOrDefault(pag => pag.IdProfile == idProfile);
        
        return profileActionGrants?.SystemActionGrants;
    }
    
    private static void CreateSystemActions()
    {
        SystemActions.Add(SystemAction.LerEntidades);
        SystemActions.Add(SystemAction.AtualizarEntidades);
        SystemActions.Add(SystemAction.CriarEntidades);
    }

    private static void CreateProfiles()
    {
        Profiles.Add(new Profile(1, "Admin"));
        Profiles.Add(new Profile(2, "OnlyRead"));
    }
    
    private static void CreateProfileActionGrants()
    {
        ProfileActionGrants.Add(new ProfileActionGrants
        {
            IdProfile = 1,
            SystemActionGrants = new List<SystemAction> { SystemAction.LerEntidades }
        });
    }

    private static void CreateUserProfiles()
    {
        UserProfile = new UserProfile
        {
            IdUser = 1,
            ProfileIds = new List<int> { 1 }
        };
    }
}