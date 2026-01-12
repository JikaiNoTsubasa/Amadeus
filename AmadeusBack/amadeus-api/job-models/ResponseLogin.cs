using Newtonsoft.Json;

namespace amadeus_api.job_models;

public record class ResponseLogin
{
    [JsonProperty("access_token")]
    public string Token { get; set; } = null!;
}
