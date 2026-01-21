using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace amadeus_api.database.models;

public class TodoTask : Entity
{
    [ForeignKey(nameof(Owner))]
    public long OwnerId { get; set; }
    public User Owner { get; set; } = null!;

    public TodoTaskStatus Status { get; set; } = TodoTaskStatus.TODO;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }

    public override void MarkDeleted(long? userId)
    {
        base.MarkDeleted(userId);
        Status = TodoTaskStatus.DELETED;
    }
}
