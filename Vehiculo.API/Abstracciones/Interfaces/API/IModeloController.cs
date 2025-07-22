using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IModeloController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(Modelo modelo);
        Task<IActionResult> Editar(Guid Id, Modelo modelo);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
