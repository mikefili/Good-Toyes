using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoodToyes.Models.Handler
{
    public class SpayNeuterRequirement : AuthorizationHandler<SpayNeuterRequirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SpayNeuterRequirement requirement)
        {
            if(!context.User.HasClaim(c=> c.Type == "SpayNeuter"))
            {
                return Task.CompletedTask;
            }

            string result = context.User.FindFirst(c => c.Type == "SpayNeuter").Value;

            if(result == "True")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
