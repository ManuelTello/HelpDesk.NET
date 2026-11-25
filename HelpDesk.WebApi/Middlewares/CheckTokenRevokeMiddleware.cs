using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HelpDesk.Service.Abstractions;

namespace HelpDesk.WebApi.Middlewares;

public class CheckTokenRevokeMiddleware : IEndpointFilter
{
    private readonly IUserService _service;

    public CheckTokenRevokeMiddleware(IUserService service)
    {
        this._service = service;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        string? userIdClaim = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
        {
            return Results.Unauthorized();
        }

        Guid tokenIdClaim = Guid.Parse(context.HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Jti)!);
        bool tokenIsValid = await _service.IsTokenRevoked(tokenIdClaim);
        if (!tokenIsValid)
        {
            return Results.Unauthorized();
        }

        return await next(context);
    }
}
