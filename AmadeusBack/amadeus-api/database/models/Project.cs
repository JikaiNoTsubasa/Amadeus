using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace amadeus_api.database.models;

public class Project : Entity
{
    public string? Description { get; set; }
    public string? Summary { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.NEW;

    [ForeignKey(nameof(Owner))]
    public long OwnerId { get; set; }
    public User Owner { get; set; } = null!;

    [ForeignKey(nameof(Customer))]
    public long? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    override public void MarkDeleted(long? userId)
    {
        base.MarkDeleted(userId);
        Status = ProjectStatus.DELETED;
    }
}
