using Danilvar.LinkSave.Api.Entities;

namespace Danilvar.LinkSave.Api.Infrastructure.Repositories;

public interface ILinkGroupRepository
{
    void Create(LinkGroup linkGroup);
    Task<IEnumerable<LinkGroup>> ListAsync();
}