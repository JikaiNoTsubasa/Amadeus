using amadeus_api.database.models;

namespace amadeus_api.job_models;

public record class ResponseProject : ResponseEntity
{
    public ProjectStatus Status { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Summary { get; set; }
    public ResponseUserEmbedded Owner { get; set; } = null!;
    public ResponseCustomerEmbedded? Customer { get; set; }
    public int? PhasesCount { get; set; }
    public int? TasksCount { get; set; }
}
