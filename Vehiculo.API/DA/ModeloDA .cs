using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public  class ModeloDA : IModeloDA
    {
        private readonly SqlConnection _sqlConnection;

        public ModeloDA(IRepositorioDapper repositorioDapper)
        {
            _sqlConnection = repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(Modelo modelo)
        {
            var id = modelo.Id == Guid.Empty ? Guid.NewGuid() : modelo.Id;
            string query = "sp_CrearModelo";

            await _sqlConnection.ExecuteAsync(query, new
            {
                Id = id,
                IdMarca = modelo.IdMarca,
                Nombre = modelo.Nombre
            });

            return id;
        }

        public async Task<Guid> Editar(Guid id, Modelo modelo)
        {
            string query = "sp_ActualizarModelo";

            await _sqlConnection.ExecuteAsync(query, new
            {
                Id = id,
                IdMarca = modelo.IdMarca,
                Nombre = modelo.Nombre
            });

            return id;
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            string query = "sp_EliminarModelo";

            await _sqlConnection.ExecuteAsync(query, new { Id = id });

            return id;
        }

        public async Task<Modelo> Obtener(Guid id)
        {
            string query = "sp_ObtenerModeloPorId";

            var resultado = await _sqlConnection.QueryFirstOrDefaultAsync<Modelo>(query, new { Id = id });
            return resultado;
        }

        public async Task<IEnumerable<Modelo>> Obtener()
        {
            string query = "sp_ObtenerModelos";

            var resultado = await _sqlConnection.QueryAsync<Modelo>(query);
            return resultado;
        }
    }
}
