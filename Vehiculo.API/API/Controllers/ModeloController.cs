﻿using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase, IModeloController
    {
     
        private readonly IModeloFlujo _modeloFlujo;
        private readonly ILogger<ModeloController> _logger;

        public ModeloController(IModeloFlujo modeloFlujo, ILogger<ModeloController> logger)
        {
            _modeloFlujo = modeloFlujo;
            _logger = logger;
        }

        #region Operaciones

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Modelo modelo)
        {
            var resultado = await _modeloFlujo.Agregar(modelo);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] Modelo modelo)
        {
            if (!await ValidarModeloExiste(Id))
                return NotFound("El modelo no existe");

            var resultado = await _modeloFlujo.Editar(Id, modelo);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await ValidarModeloExiste(Id))
                return NotFound("El modelo no existe");

            var resultado = await _modeloFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _modeloFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _modeloFlujo.Obtener(Id);
            if (resultado == null)
                return NotFound("El modelo no existe");

            return Ok(resultado);
        }

        #endregion Operaciones

        #region Helpers

        private async Task<bool> ValidarModeloExiste(Guid Id)
        {
            var modelo = await _modeloFlujo.Obtener(Id);
            return modelo != null;
        }

        #endregion Helpers
    }
}
