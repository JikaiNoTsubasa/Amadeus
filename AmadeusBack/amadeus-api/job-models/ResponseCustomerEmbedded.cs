using System;

namespace amadeus_api.job_models;

public record class ResponseCustomerEmbedded
{
    public string? Description { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
}
