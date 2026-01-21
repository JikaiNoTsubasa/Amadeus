using System.ComponentModel.DataAnnotations;

namespace amadeus_api.job_models;

public record class RequestCreateTodoTask
{
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}
