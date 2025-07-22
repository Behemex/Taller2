using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase, IMarcaController
    {
        private readonly IMarcaFlujo _marcaFlujo;
        private readonly ILogger<MarcaController> _logger;

        public MarcaController(IMarcaFlujo marcaFlujo, ILogger<MarcaController> logger)
        {
            _marcaFlujo = marcaFlujo;
            _logger = logger;
        }

        #region Operaciones

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _marcaFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var resultado = await _marcaFlujo.Obtener(Id);
            if (resultado == null)
                return NotFound("La marca no existe.");
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Marca marca)
        {
            var resultado = await _marcaFlujo.Agregar(marca);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, [FromBody] Marca marca)
        {
            if (await ValidarMarcaExiste(Id) == false)
                return NotFound("La marca no existe.");
            var resultado = await _marcaFlujo.Editar(Id, marca);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            if (await ValidarMarcaExiste(Id) == false)
                return NotFound("La marca no existe.");
            var resultado = await _marcaFlujo.Eliminar(Id);
            return NoContent();
        }

        #endregion

        #region Helpers

        private async Task<bool> ValidarMarcaExiste(Guid Id)
        {
            var marca = await _marcaFlujo.Obtener(Id);
            return marca != null;
        }

        #endregion
    }
}
