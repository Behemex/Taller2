using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Vehiculo.Web.Pages.Marcas
{
    public class DetalleModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public Marca Marca { get; set; } = default!;

        public DetalleModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            try
            {
                var endpoint = string.Format(_configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarca"), id);
                var cliente = new HttpClient();
                var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

                var respuesta = await cliente.SendAsync(solicitud);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.StatusCode == HttpStatusCode.OK)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    Marca = JsonSerializer.Deserialize<Marca>(contenido, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new Marca();
                }

                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al obtener la marca: {ex.Message}";
                return RedirectToPage("./Index");
            }
        }
    }
    
}
