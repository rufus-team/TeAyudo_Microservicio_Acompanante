using Application.Interfaces.Querys;
using Application.Model.Responses;
using System.Text.Json;

namespace Infrastructure.Querys
{
    public class UsuarioQuery : IUsuarioQuery
    {
        public async Task<UsuarioResponse?> GetDateAt(int Id)
        {
            using (var HttpClient = new HttpClient())
            {
                var response = await HttpClient.GetAsync($"https://localhost:7064/api/Usuario/Usuario/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var Json = await response.Content.ReadAsStringAsync();
                    var DatosAt = JsonSerializer.Deserialize<UsuarioResponse>(Json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return DatosAt;
                }
                else throw new Exception(); //Personalizar exception aunque se supone jamas debe de entrar
            }
        }
    }
}
