using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class MarcaFlujo : IMarcaFlujo
    {
        private readonly IMarcaDA _marcaDA;

        public MarcaFlujo(IMarcaDA marcaDA)
        {
            _marcaDA = marcaDA;
        }

        public async Task<Guid> Agregar(Marca marca)
        {
            if (marca == null)
                throw new ArgumentException("La marca no puede ser nula.");

            if (string.IsNullOrWhiteSpace(marca.Nombre))
                throw new ArgumentException("El nombre de la marca es obligatorio.");

            return await _marcaDA.Agregar(marca);
        }

        public async Task<Guid> Editar(Guid id, Marca marca)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID proporcionado no es válido.");

            if (marca == null || string.IsNullOrWhiteSpace(marca.Nombre))
                throw new ArgumentException("La información de la marca es inválida.");

            return await _marcaDA.Editar(id, marca);
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID proporcionado no es válido.");

            return await _marcaDA.Eliminar(id);
        }

        public async Task<IEnumerable<Marca>> Obtener()
        {
            return await _marcaDA.Obtener();
        }

        public async Task<Marca> Obtener(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID proporcionado no es válido.");

            return await _marcaDA.Obtener(id);
        }
    }
}
