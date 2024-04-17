using DAOApi;
using Logic.OpercaionesDB;
using ModelsApi;
using ModelsApi.Models;
using ServicesApi.InterfaceApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.ImplementacionApi
{
    public class ImpConUser : IConUsuario
    {
        private readonly ConexionSql _conexionSql;
        private readonly SqlServerParameterList _lista;
        private readonly ConsultaUsuario _consultaUsuarioSp;

        public ImpConUser
            (
                ConexionSql conexionSql,
                SqlServerParameterList lista,
                ConsultaUsuario consultaUsuario
            )
        {
            _conexionSql = conexionSql;
            _lista = lista;
            _consultaUsuarioSp = consultaUsuario;
        }


        public ModelApiResponse ConUser(int idUser)
        {
            ModelApiResponse model = new ModelApiResponse();

            try
            {
                if (_conexionSql.openConnection())
                {


                    _lista.Parameters.Insert(0, new SqlParameter { ParameterName = "@piId", SqlDbType = SqlDbType.Int, Value = idUser, Direction = ParameterDirection.Input });

                    SqlDataReader consultaUsuarioReader = _conexionSql.ExecuteStoredProcedure(Constants.shemaUsers + ListStoreProducers.SPConUsuario, _lista.Parameters);

                    model = _consultaUsuarioSp.consultaUsuarioReader(consultaUsuarioReader);

                }

                _conexionSql.CloseConnection();
            }
            catch (Exception)
            {
                model.Message = "error al conectar a BD";
                model.StatusCode = 500;

                return model;

            }

            return model;

           
        }
    }
}
