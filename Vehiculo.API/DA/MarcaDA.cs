using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class MarcaDA : IMarcaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public MarcaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones
        public async Task<Guid> Agregar(Marca marca)
        {
            string query = "CrearMarca";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Nombre = marca.Nombre
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, Marca marca)
        {
            await VerificarMarcaExiste(Id);
            string query = "ActualizarMarca";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Nombre = marca.Nombre
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarMarcaExiste(Id);
            string query = "EliminarMarca";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new { Id });
            return resultado;
        }

        public async Task<IEnumerable<Marca>> Obtener()
        {
            string query = "ObtenerMarcas";
            var resultado = await _sqlConnection.QueryAsync<Marca>(query);
            return resultado;
        }

        public async Task<Marca?> Obtener(Guid Id)
        {
            string query = "ObtenerMarcaPorId";
            var resultado = await _sqlConnection.QueryAsync<Marca>(query, new { Id });
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task VerificarMarcaExiste(Guid Id)
        {
            Marca? marca = await Obtener(Id);
            if (marca == null)
                throw new Exception("No se encontró la marca.");
        }
        #endregion
    }
}
