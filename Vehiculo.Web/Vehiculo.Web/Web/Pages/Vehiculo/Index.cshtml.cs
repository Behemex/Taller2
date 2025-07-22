using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abstracciones.Reglas;
using Abstracciones.Modelos;
using System.Threading.Tasks;
using System.Text.Json;

namespace Web.Pages.Vehiculo
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public IList<VehiculoResponse> vehiculos { get; set; } = default!;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("APIEndPoints", "ObtenerVehiculos");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
            vehiculos = JsonSerializer.Deserialize<List<VehiculoResponse>>(resultado, opciones);
        }
    }
}
