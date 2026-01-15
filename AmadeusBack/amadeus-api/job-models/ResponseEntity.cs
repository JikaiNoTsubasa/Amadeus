using amadeus_api.database.models;

namespace amadeus_api.job_models;

public record class ResponseEntity
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public ResponseUserEmbedded? CreatedBy { get; set; }
    public ResponseUserEmbedded? UpdatedBy { get; set; }
    public ResponseUserEmbedded? DeletedBy { get; set; }
    public ResponseUserEmbedded? ArchivedBy { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsArchived { get; set; }

    public void FeedEntityInfo(Entity entity)
    {
        Id = entity.Id;
        Name = entity.Name;

        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt;
        DeletedAt = entity.DeletedAt;
        ArchivedAt = entity.ArchivedAt;
        IsDeleted = entity.IsDeleted;
        IsArchived = entity.IsArchived;

        CreatedBy = entity.CreatedBy?.ToDTOEmbedded();
        UpdatedBy = entity.UpdatedBy?.ToDTOEmbedded();
        DeletedBy = entity.DeletedBy?.ToDTOEmbedded();
        ArchivedBy = entity.ArchivedBy?.ToDTOEmbedded();
    }
}
