using amadeus_api.database.models;

namespace amadeus_api.job_models;

public record class ResponseTodoTask : ResponseEntity
{
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public TodoTaskStatus Status { get; set; }
}
