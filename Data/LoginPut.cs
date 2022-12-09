using Newtonsoft.Json;

namespace voeairlines_blazor.Data;

public class LoginPut
{
    [JsonProperty ("Usuario")]
    public string? Usuario { get; set; }

    [JsonProperty ("Senha")]
    public string? Senha { get; set; }

    [JsonProperty ("DataCriacao")]
    public DateTime DataCriacao { get; set; }
}