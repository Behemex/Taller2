using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;


namespace DA
{
    public class VehiculoDA : IVehiculoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }


        #region Operaciones
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculos";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new 
            {
                Id = Guid.NewGuid()
                ,
                IdModelo = vehiculo.IdModelo
                ,
                Placa = vehiculo.Placa
                ,
                Color = vehiculo.Color
                ,
                Anio = vehiculo.Anio
                ,
                Precio = vehiculo.Precio
                ,
                CorreoPropietario = vehiculo.CorreoPropietario
                ,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            await VerificarVehiculoExiste(Id);
            string query = @"EditarVehiculos";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
                ,
                IdModelo = vehiculo.IdModelo
                ,
                Placa = vehiculo.Placa
                ,
                Color = vehiculo.Color
                ,
                Anio = vehiculo.Anio
                ,
                Precio = vehiculo.Precio
                ,
                CorreoPropietario = vehiculo.CorreoPropietario
                ,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultadoConsulta;
        }
        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarVehiculoExiste(Id);
            string query = @"EliminarVehiculos";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            String query = @"ObtenerVehiculos";
            var resultadoConsulta = await  _sqlConnection.QueryAsync<VehiculoResponse>(query);
            return resultadoConsulta;
        }

        public async Task<VehiculoDetalle> Obtener(Guid Id)
        {
            String query = @"ObtenerVehiculo";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoDetalle>(query,
                new {Id = Id});
            return resultadoConsulta.FirstOrDefault();
        }
        #endregion
        #region Helpers
        private async Task VerificarVehiculoExiste(Guid Id)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(Id);
            if (resultadoConsultaVehiculo == null)
                throw new Exception("No seencontró el vehículo");
        }
        #endregion
    }
}