using Newtonsoft.Json;

namespace voeairlines_blazor.Data;

public class LoginApi
{

    [JsonProperty ("Usuario")]
    public string? Usuario { get; set; }

    [JsonProperty ("DataCriacao")]
    public DateTime DataCriacao { get; set; }
}