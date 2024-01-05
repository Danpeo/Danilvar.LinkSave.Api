namespace Danilvar.LinkSave.Api.Entities;

public class LinkGroup
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<Link> Links { get; set; }

    public LinkGroup()
    {
        Id = Guid.NewGuid();
        Name = string.Empty;
        Links = new List<Link>();
    }

    public LinkGroup(string name, ICollection<Link> links) : this()
    {
        Name = name;
        Links = links;
    }
}