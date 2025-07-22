using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMarcaFlujo
    {
        Task<Guid> Agregar(Marca marca);
        Task<Guid> Editar(Guid id, Marca marca);
        Task<Guid> Eliminar(Guid id);
        Task<IEnumerable<Marca>> Obtener();
        Task<Marca> Obtener(Guid id);
    }
}
