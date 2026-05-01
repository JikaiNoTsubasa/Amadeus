using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace amadeus_api.database.models;

public class Project : Entity
{
    public string? Description { get; set; }
    public string? Summary { get; set; }
    public string? Code { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.NEW;

    [ForeignKey(nameof(Owner))]
    public long OwnerId { get; set; }
    public User Owner { get; set; } = null!;

    [ForeignKey(nameof(Customer))]
    public long? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [ForeignKey(nameof(CMDB))]
    public long? CMDBId { get; set; }
    public CMDB? CMDB { get; set; }

    [ForeignKey(nameof(Category))]
    public long? CategoryId { get; set; }
    public ProjectCategory? Category { get; set; }

    public List<ProjectPhase>? Phases { get; set; }
    public List<ProjectTask>? Tasks { get; set; }



    override public void MarkDeleted(long? userId)
    {
        base.MarkDeleted(userId);
        Status = ProjectStatus.DELETED;
    }
}
