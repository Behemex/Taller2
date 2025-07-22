using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IMarcaDA
    {
        Task<Guid> Agregar(Marca marca);
        Task<Guid> Editar(Guid Id, Marca marca);
        Task<Guid> Eliminar(Guid Id);
        Task<IEnumerable<Marca>> Obtener();
        Task<Marca?> Obtener(Guid Id);
    }
}
