using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace amadeus_api.job_controllers;

[ApiController]
public class AmaController : Controller
{
    protected long _loggedUserId = -1;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Get connected user
        var user = context.HttpContext.User;
        if (user is not null)
        {
            var ident = user.Identity;
            if (ident is not null && ident.IsAuthenticated)
            {
                var userIdClaim = user.Claims.FirstOrDefault(c => c.Type.Equals("userid"));
                if (userIdClaim is not null)
                {
                    _loggedUserId = long.Parse(userIdClaim.Value);
                }
            }
        }

        base.OnActionExecuting(context);
    }
}
