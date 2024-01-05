namespace Danilvar.LinkSave.Api.Requests;

public class CreateLinkRequest
{
    public string Url { get; set; }

    public string Description { get; set; }

    public CreateLinkRequest(string url, string description)
    {
        Url = url;
        Description = description;
    }
}