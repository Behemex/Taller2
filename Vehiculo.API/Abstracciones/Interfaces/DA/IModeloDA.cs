using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IModeloDA
    {
        Task<IEnumerable<Modelo>> Obtener();
        Task<Modelo> Obtener(Guid id);
        Task<Guid> Agregar(Modelo modelo);
        Task<Guid> Editar(Guid id, Modelo modelo);
        Task<Guid> Eliminar(Guid id);
    }
}
