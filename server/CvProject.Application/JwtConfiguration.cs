namespace CvProject.Application;

public record JwtConfiguration
{
    public string Secret { get; init; } = default!;

    public string ValidIssuer { get; init; } = default!;
    
    public string ValidAudience { get; init; } = default!;
}
