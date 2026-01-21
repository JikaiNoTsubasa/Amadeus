using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace amadeus_api.database.models;

public class RegisteredTaskTime : Entity
{
    [ForeignKey(nameof(User))]
    public long UserId { get; set; }
    public User User { get; set; } = null!;
}
