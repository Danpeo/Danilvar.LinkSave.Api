using Danilvar.LinkSave.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Danilvar.LinkSave.Api.Infrastructure.Repositories;

public class LinkGroupGroupRepository : ILinkGroupRepository
{
    private readonly ApplicationDbContext _context;

    public LinkGroupGroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(LinkGroup linkGroup) =>
        _context.Add(linkGroup);

    public async Task<IEnumerable<LinkGroup>> ListAsync()
    {
        return await _context.LinkGroups
            .Include(lg => lg.Links)
            .ToListAsync();
    }

    public async Task<LinkGroup?> GetAsync(Guid id) => 
        await _context.LinkGroups.FirstOrDefaultAsync(lg => lg != null && lg.Id == id);
}