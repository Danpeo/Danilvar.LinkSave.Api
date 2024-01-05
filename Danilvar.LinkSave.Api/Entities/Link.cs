namespace Danilvar.LinkSave.Api.Entities;

public class Link()
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Url { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Link(string url, string description) : this()
    {
        Url = url;
        Description = description;
    }
}