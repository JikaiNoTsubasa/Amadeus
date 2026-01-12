namespace amadeus_api.database.models;

public class User : Entity
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool CanLogin { get; set; }
    public string? Avatar { get; set; }
    public DateTime? LastConnection { get; set; }
}
