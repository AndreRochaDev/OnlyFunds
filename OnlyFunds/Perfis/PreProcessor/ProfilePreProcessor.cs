using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using OnlyFunds.Perfis.Models;
using OnlyFunds.Perfis.Services;

namespace OnlyFunds.Perfis.PreProcessor;

public class UserProfilePreProcessor<TRequest> : IPreProcessor<TRequest>
{
    private readonly int _idProfile;
    private readonly SystemAction _systemAction;
    
    public UserProfilePreProcessor(int idProfile, SystemAction systemAction)
    {
        DummyData.LoadInitialData();
        _idProfile = idProfile;
        _systemAction = systemAction;
    }
    
    public Task PreProcessAsync(TRequest req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        var hasAccess = ProfileGuard.CheckIfProfileHasAccessToAction(_idProfile, _systemAction);

        if (hasAccess) return Task.CompletedTask;
        
        failures.Add(new ValidationFailure("MissingPermissions", 
            $"The profile {_idProfile} does not have permission to the system action {_systemAction.ToString()}."));
        return ctx.Response.SendForbiddenAsync(cancellation: ct);
    }
}