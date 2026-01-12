using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amadeus_api.database.models;

public class Entity
{
    [Key]
    public long Id { get; set; }
    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }

    [ForeignKey(nameof(CreatedBy))]
    public long? CreatedById { get; set; }
    public User? CreatedBy { get; set; }

    [ForeignKey(nameof(UpdatedBy))]
    public long? UpdatedById { get; set; }
    public User? UpdatedBy { get; set; }

    [ForeignKey(nameof(DeletedBy))]
    public long? DeletedById { get; set; }
    public User? DeletedBy { get; set; }

    [ForeignKey(nameof(ArchivedBy))]
    public long? ArchivedById { get; set; }
    public User? ArchivedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
    public bool IsArchived { get; set; } = false;

    public void MarkCreated(long? userId)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedById = userId;
    }

    public void MarkUpdated(long? userId)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedById = userId;
    }

    public void MarkDeleted(long? userId)
    {
        DeletedAt = DateTime.UtcNow;
        DeletedById = userId;
        IsDeleted = true;
    }

    public void MarkArchived(long? userId)
    {
        ArchivedAt = DateTime.UtcNow;
        ArchivedById = userId;
        IsArchived = true;
    }
}
