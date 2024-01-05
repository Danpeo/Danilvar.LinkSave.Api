using Danilvar.LinkSave.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Danilvar.LinkSave.Api.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Link> Links { get; set; } = null!;
    public DbSet<LinkGroup?> LinkGroups { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}