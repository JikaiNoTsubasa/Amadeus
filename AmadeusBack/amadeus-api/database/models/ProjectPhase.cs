using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace amadeus_api.database.models;

public class ProjectPhase : Entity
{
    [ForeignKey(nameof(Project))]
    public long ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public List<ProjectTask>? Tasks { get; set; }
}
