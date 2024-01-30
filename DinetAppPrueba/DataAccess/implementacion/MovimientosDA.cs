
using Dapper;
using DinetAppPrueba.DataAccess.Data;
using DinetAppPrueba.DataAccess.Interfaces;
using DinetAppPrueba.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using System.Data;

namespace DinetAppPrueba.DataAccess.implementacion
{
    public class MovimientosDA : IMovimientos
    {

        public readonly IDbConnection connection;

        public MovimientosDA(ConexionService conexionServices)
        {
            string connsql = conexionServices.getConexion();
            connection = new SqlConnection(connsql);
        }

        public async Task<dynamic> getMovimientos(filtros obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@fechaIni", obj.FECHA_INI, DbType.String);
            parameters.Add("@fechaFin", obj.FECHA_FIN, DbType.String);
            parameters.Add("@tipoMov", obj.TIPO_MOVIMIENTO, DbType.String);
            parameters.Add("@nro_doc", obj.NRO_DOCUMENTO, DbType.String);

            IEnumerable<dynamic> lista = await connection.QueryAsync<dynamic>("sp_get_MOVINVENTARIO", parameters, commandType: CommandType.StoredProcedure);
            return lista.ToList();
        }

        public async Task<dynamic> getMovimientoxUNIDAD(MovInventario obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@tipoMov", obj.TIPO_MOVIMIENTO, DbType.String);
            parameters.Add("@tipo_doc", obj.TIPO_DOCUMENTO, DbType.String);
            parameters.Add("@nro_doc", obj.NRO_DOCUMENTO, DbType.String);
            parameters.Add("@codItem2", obj.COD_ITEM_2, DbType.String);
            IEnumerable<dynamic> lista = await connection.QueryAsync<dynamic>("sp_get_MOVINVENTARIOxUnidad", parameters, commandType: CommandType.StoredProcedure);
            return lista.FirstOrDefault();
        }

        public async Task<int> InsertMovimientos(MovInventario obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@codcia", obj.COD_CIA, DbType.String);
            parameters.Add("@compven3", obj.COMPANIA_VENTA_3, DbType.String);
            parameters.Add("@almvent", obj.ALMACEN_VENTA, DbType.String);
            parameters.Add("@tipmov", obj.TIPO_MOVIMIENTO, DbType.String);
            parameters.Add("@tipdoc", obj.TIPO_DOCUMENTO, DbType.String);
            parameters.Add("@nrodoc", obj.NRO_DOCUMENTO, DbType.String);
            parameters.Add("@codit2", obj.COD_ITEM_2, DbType.String);
            //parameters.Add("@nResultado", dbType: DbType.Int32, direction: ParameterDirection.Output);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var nResultado = await connection.ExecuteAsync("sp_ins_MOVINVENTARIO", parameters, commandType: CommandType.StoredProcedure);
            //var nResultado = parameters.Get<int>("@nResultado");
            connection.Close();

            return nResultado;
        }



        public async Task<int> EditMovimientos(MovInventario obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@codcia", obj.COD_CIA, DbType.String);
            parameters.Add("@compven3", obj.COMPANIA_VENTA_3, DbType.String);
            parameters.Add("@almvent", obj.ALMACEN_VENTA, DbType.String);
            parameters.Add("@tipmov", obj.TIPO_MOVIMIENTO, DbType.String);
            parameters.Add("@tipdoc", obj.TIPO_DOCUMENTO, DbType.String);
            parameters.Add("@nrodoc", obj.NRO_DOCUMENTO, DbType.String);
            parameters.Add("@codit2", obj.COD_ITEM_2, DbType.String);
            //parameters.Add("@nResultado", dbType: DbType.Int32, direction: ParameterDirection.Output);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var nResultado = await connection.ExecuteAsync("sp_upd_MOVINVENTARIO", parameters, commandType: CommandType.StoredProcedure);
            //var nResultado = parameters.Get<int>("@nResultado");
            connection.Close();
            return nResultado;

        }

        
    }
}
