using Newtonsoft.Json;

namespace voeairlines_blazor.Data;

public class AeronaveApi
{

    [JsonProperty ("id")]
    public int Id { get; set; }

    [JsonProperty ("modelo")]
    public string? Modelo { get; set; }

    [JsonProperty ("codigo")]
    public string? Codigo { get; set; }
}