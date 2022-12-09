using voeairlines_blazor.Data;
using Newtonsoft.Json;
using System.Text;

namespace voeairlines_blazor.Pages;

public partial class CrudLogin 
{
    //* Post User
    private string? InputUsuario;
    private string? InputSenha;

    //* Update User
    public string? AtualizarUsuario;
    public string? AtualizarSenha;
    public int? AtualizarId;
    public DateTime AtualizarData;
    public int Mostrar = 0;


    List<LoginCrud>? Usuarios;
    
    private async void GetUser()
    {
        var apiName = "http://jezielalmeida-001-site1.btempurl.com/api/login/";
        var httpResponse = await client.GetAsync(apiName);
        if (httpResponse.IsSuccessStatusCode)
        {
            Usuarios = new List<LoginCrud>();
            var apiConteudo = await httpResponse.Content.ReadAsStringAsync();
            Usuarios = JsonConvert.DeserializeObject<List<LoginCrud>>(apiConteudo);
            StateHasChanged();
        }
    }

    protected override void OnInitialized()
    {
        GetUser();
    }

    private async void PostUser()
    {
        var apiName = "http://jezielalmeida-001-site1.btempurl.com/api/login/";
        var login = new LoginPost
        {
            Usuario = InputUsuario,
            Senha = InputSenha,
        };
        var json = JsonConvert.SerializeObject(login);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        var httpResponse = await client.PostAsync(apiName, httpContent);
        if (httpResponse.IsSuccessStatusCode)
        {
            GetUser();
        }

        InputUsuario = "";
        InputSenha = "";
    }

    private async void DeleteUser(int id)
    {
        var apiName = $"http://jezielalmeida-001-site1.btempurl.com/api/login/{id}";
        var httpResponse = await client.DeleteAsync(apiName);
        if (httpResponse.IsSuccessStatusCode)
        {
            GetUser();
        }
    }

    private void PreencherAtualizar(int id, string? usuario, DateTime dataCriacao) 
    {
        AtualizarId = id;
        AtualizarUsuario = usuario;
        AtualizarData = dataCriacao;
        Mostrar = 1;
        
    }
    private async void UpdateUser()
    {
        var apiName = $"http://jezielalmeida-001-site1.btempurl.com/api/login/{AtualizarId}";

        var login = new LoginPut
        {
            Usuario = AtualizarUsuario,
            Senha = AtualizarSenha,
            DataCriacao = AtualizarData
        };
        var json = JsonConvert.SerializeObject(login);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        var httpResponse = await client.PutAsync(apiName, httpContent);
        if (httpResponse.IsSuccessStatusCode)
        {
            GetUser();
        }
        AtualizarId = 0;
        AtualizarUsuario = "";
        AtualizarSenha = "";
        AtualizarData = DateTime.Now;
        Mostrar = 0;
    }

    private void CancelarUpdate()
    {
        AtualizarId = 0;
        AtualizarUsuario = "";
        AtualizarSenha = "";
        AtualizarData = DateTime.Now;
        Mostrar = 0;
    }
}