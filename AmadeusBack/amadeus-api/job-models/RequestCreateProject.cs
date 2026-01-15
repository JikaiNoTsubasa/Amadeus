using System.ComponentModel.DataAnnotations;

namespace amadeus_api.job_models;

public record class RequestCreateProject
{
    [Required]
    public string Name { get; set; } = null!;
    public long? OwnerId { get; set; }
    public long? CustomerId { get; set; }
    public string? Description { get; set; }
}
