using System;

namespace amadeus_api.job_models;

public record class ResponseUserEmbedded
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Avatar { get; set; }
}
