using Microsoft.AspNetCore.Mvc.Filters;
using OnlyFunds.Perfis.Models;

namespace OnlyFunds.Perfis.Attributes;

public class ProfileGuardForSystemActionFilter : ActionFilterAttribute
{
    private SystemAction[] _systemActions;
  
    public ProfileGuardForSystemActionFilter(params SystemAction[] systemActions)
    {
        _systemActions = systemActions;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        Console.WriteLine("executing");
        base.OnActionExecuting(filterContext);
    }
}  