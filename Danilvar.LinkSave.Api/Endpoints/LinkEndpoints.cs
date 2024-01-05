using Danilvar.LinkSave.Api.Entities;
using Danilvar.LinkSave.Api.Infrastructure;
using Danilvar.LinkSave.Api.Infrastructure.Repositories;
using Danilvar.LinkSave.Api.Requests;
using Danilvar.UnitOfWork;

namespace Danilvar.LinkSave.Api.Endpoints;

public static class LinkEndpoints
{
    public static void MapLinkEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("api/Links");

        group.MapPost("", CreateLinkAsync);
        group.MapGet("", ListLinkGroupsAsync);
    }

    private static async Task<IResult> CreateLinkAsync(CreateLinkGroupRequest groupRequest,
        ILinkGroupRepository groupRepository,
        UnitOfWork<ApplicationDbContext> unitOfWork)
    {
        var links = groupRequest.Links
            .Select(linkRequest => new Link(linkRequest.Url, linkRequest.Description))
            .ToList();
        
        var linkGroup = new LinkGroup(groupRequest.Name, links);

        groupRepository.Create(linkGroup);
        if (await unitOfWork.CompleteAsync())
            return Results.Ok(linkGroup);

        return Results.BadRequest();
    }

    private static async Task<IResult> ListLinkGroupsAsync(ILinkGroupRepository linkGroupRepository)
    {
        var linkGroups = await linkGroupRepository.ListAsync();

        List<LinkGroup> groups = linkGroups.ToList();
        if (groups.Any())
            return Results.Ok(groups);

        return Results.NoContent();
    }
}