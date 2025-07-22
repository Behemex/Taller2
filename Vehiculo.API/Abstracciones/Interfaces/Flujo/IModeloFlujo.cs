using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IModeloFlujo
    {
        Task<IEnumerable<Modelo>> Obtener();
        Task<Modelo> Obtener(Guid id);
        Task<Guid> Agregar(Modelo modelo);
        Task<Guid> Editar(Guid id, Modelo modelo);
        Task<Guid> Eliminar(Guid id);
    }
}
