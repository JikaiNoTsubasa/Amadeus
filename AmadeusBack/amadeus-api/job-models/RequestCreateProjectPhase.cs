using System.ComponentModel.DataAnnotations;

namespace amadeus_api.job_models;

public record class RequestCreateProjectPhase
{
    [Required]
    public string Name { get; set; } = null!;
}
