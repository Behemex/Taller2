using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ModeloFlujo : IModeloFlujo
    {
        private readonly IModeloDA _modeloDA;

        public ModeloFlujo(IModeloDA modeloDA)
        {
            _modeloDA = modeloDA;
        }

        public async Task<Guid> Agregar(Modelo modelo)
        {
            // Validaciones básicas (según PDF)
            if (modelo == null)
                throw new ArgumentException("Datos inválidos.");

            if (modelo.IdMarca == Guid.Empty)
                throw new ArgumentException("Debe seleccionar una marca.");

            if (string.IsNullOrWhiteSpace(modelo.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            // TODO: agregar validación de duplicado o marca existente si lo requerís
            return await _modeloDA.Agregar(modelo);
        }

        public async Task<Guid> Editar(Guid id, Modelo modelo)
        {
            if (id == Guid.Empty || modelo == null)
                throw new ArgumentException("Datos inválidos.");

            return await _modeloDA.Editar(id, modelo);
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID inválido.");

            return await _modeloDA.Eliminar(id);
        }

        public async Task<IEnumerable<Modelo>> Obtener()
        {
            return await _modeloDA.Obtener();
        }

        public async Task<Modelo> Obtener(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID inválido.");

            return await _modeloDA.Obtener(id);
        }
    }
}
