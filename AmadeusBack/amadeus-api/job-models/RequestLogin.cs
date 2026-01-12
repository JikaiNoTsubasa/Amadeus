using System.ComponentModel.DataAnnotations;

namespace amadeus_api.job_models;

public record class RequestLogin
{
    [Required]
    public string Identifier { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
