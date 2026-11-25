using Carter;
using HelpDesk.Service.Abstractions;

namespace HelpDesk.WebApi.Modules.User;

public class RevokeTokenUserModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/user/revoke/{tokenId:guid}", async (Guid tokenId, IUserService service) =>
        {
            await service.RevokeToken(tokenId);
            Results.Ok();
        }).AllowAnonymous()
        .WithTags("User");
    }
}
