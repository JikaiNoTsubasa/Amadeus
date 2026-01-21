using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace amadeus_api.database.models;

public class ProjectTask : Entity
{
    public List<User>? Assignee { get; set; }

    [ForeignKey(nameof(Project))]
    public long ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    [ForeignKey(nameof(Phase))]
    public long? PhaseId { get; set; }
    public ProjectPhase? Phase { get; set; }

    public string? Content { get; set; }
    public DateTime? DueDate { get; set; }
    public Priority Priority { get; set; }
    public int ExpectedTimeMinutes { get; set; }
    public List<RegisteredTaskTime>? RegisteredTimes { get; set; }
}
