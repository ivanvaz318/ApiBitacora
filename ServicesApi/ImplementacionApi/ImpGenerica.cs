using DAOApi;
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
using Logic.OpercaionesDB;

namespace ServicesApi.ImplementacionApi
{
    public class ImpGenerica : InterfaceGenerica

    {
        private readonly ConexionSql _conexionSql;
        private readonly SqlServerParameterList _lista;
        private readonly ProcesaHistoricoBitacora _procesaSp;

        public ImpGenerica(
            ConexionSql conexionSql,
            SqlServerParameterList lista,
            ProcesaHistoricoBitacora procesaSp
            )
        {
            _conexionSql=conexionSql;
            _lista = lista;
            _procesaSp = procesaSp;
        }

        public ModelApiResponse conexion()
        {
           ModelApiResponse model = new ModelApiResponse();

            try
            {
                if (_conexionSql.openConnection())
                {
                    _lista.Parameters.Insert(0, new SqlParameter { ParameterName = "@piIdProspecto", SqlDbType = SqlDbType.Int, Value = 426, Direction = ParameterDirection.Input });

                    SqlDataReader historialProspectoReader = _conexionSql.ExecuteStoredProcedure(Constants.schemaAuditoria + ListStoreProducers.SPConConsultaHistorialProspecto, _lista.Parameters);

                    model = _procesaSp.procesaHistoricoBitacoraReader(historialProspectoReader);
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
