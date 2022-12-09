using Newtonsoft.Json;

namespace voeairlines_blazor.Data;

public class LoginCrud
{
    [JsonProperty ("Id")]
    public int Id { get; set; }
    [JsonProperty ("Usuario")]
    public string? Usuario { get; set; }

    [JsonProperty ("DataCriacao")]
    public DateTime DataCriacao { get; set; }
}