﻿using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase, IVehiculoController
    {
        private IVehiculoFlujo _vehiculoFlujo;
        private ILogger<VehiculoController> _logger;

        public VehiculoController(IVehiculoFlujo vehiculoFlujo, ILogger<VehiculoController> logger)
        {
            _vehiculoFlujo = vehiculoFlujo;
            _logger = logger;
        }
        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] VehiculoRequest vehiculo)
        {
            var resultado = await _vehiculoFlujo.Agregar(vehiculo);
            return CreatedAtAction(nameof(Obtener), new {Id = resultado}, null);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] VehiculoRequest vehiculo)
        {
            if (await ValidarVehiculoExiste(Id))
                return NotFound("El vehiculo no existe");
            var resultado = await _vehiculoFlujo.Editar(Id, vehiculo);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (await ValidarVehiculoExiste(Id))
                return NotFound("El vehiculo no existe");
            var resultado = await _vehiculoFlujo.Eliminar(Id);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _vehiculoFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _vehiculoFlujo.Obtener(Id);
            return Ok(resultado);
        }
        #endregion Operaciones

        #region Helpers
        private async Task<bool> ValidarVehiculoExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoVehiculoExiste = await _vehiculoFlujo.Obtener(Id);
            if (resultadoVehiculoExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion Helpers
    }
}
