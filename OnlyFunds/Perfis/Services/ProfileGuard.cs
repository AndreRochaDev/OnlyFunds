using OnlyFunds.Perfis.Models;

namespace OnlyFunds.Perfis.Services;

public static class ProfileGuard
{
    // 2. Adicionar default false se nao tiver regras. escolher default como parametro
    public static bool CheckIfProfileHasAccessToAction(int idProfile, params SystemAction[] systemActions)
    {
        var profileActionGrants = (DummyData.GetProfileSystemActionGrants(idProfile) ?? Array.Empty<SystemAction>()).ToList();
        return profileActionGrants.Intersect(systemActions).Any();
    }
}