using System;

namespace amadeus_api.database.models;

public class Customer : Entity
{
    public string? Description { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }

    public List<Project>? Projects { get; set; }
}
