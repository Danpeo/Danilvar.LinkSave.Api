using Danilvar.LinkSave.Api.Entities;

namespace Danilvar.LinkSave.Api.Requests;

public class CreateLinkGroupRequest
{
    public string Name { get; set; } = string.Empty;

    public ICollection<CreateLinkRequest> Links { get; set; } = new List<CreateLinkRequest>();
}