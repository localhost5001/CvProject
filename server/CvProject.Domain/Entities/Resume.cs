using System;

namespace CvProject.Domain.Entities;

public record Resume
{
    public string Body { get; init; } = default!;   

    public int UserId { get; init; } = default;

    public DateTime CreatedAt { get; init; } = default;

    public DateTime UpdatedAt { get; init; } = default;
}
