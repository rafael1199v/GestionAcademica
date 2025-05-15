using Microsoft.AspNetCore.Authorization;

namespace GestionAcademica.API;

public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
    {
        //Debug necesario para los permisos
        // var allClaims = context.User.Claims.ToList();
        //
        // foreach (var claim in allClaims)
        // {
        //     Console.WriteLine(claim.Issuer);
        // }
        //
        // Console.WriteLine(requirement.Scope);
        // Console.WriteLine(requirement.Issuer);
        
        if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Scope))
            return Task.CompletedTask;
        
        var permissions = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Scope).Value.Split(' ');
        
        if(permissions != null && permissions.Any(s => s == requirement.Issuer))
           context.Succeed(requirement);
           
        return Task.CompletedTask;
    }

    
}