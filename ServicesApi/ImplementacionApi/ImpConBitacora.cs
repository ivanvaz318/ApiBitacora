using DAOApi;
using Logic.OpercaionesDB;
using ModelsApi;
using ModelsApi.Models;
using ServicesApi.InterfaceApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.ImplementacionApi
{
    public class ImpConBitacora : IConBitacora
    {

        private readonly ConexionSql _conexionSql;
        private readonly SqlServerParameterList _lista;
        private readonly ConsultaBitacora _consultaBitacora;

        public ImpConBitacora(ConexionSql conexionSql, SqlServerParameterList lista, ConsultaBitacora consultaBitacora)
        {
            _conexionSql = conexionSql;
            _lista = lista;
            _consultaBitacora = consultaBitacora;
        }

        public ModelApiResponse ConHistorialProspecto(int id)
        {
            ModelApiResponse model = new ModelApiResponse();
            try
            {
                if (_conexionSql.openConnection())
                {
                    _lista.Parameters.Insert(0, new SqlParameter { ParameterName = "@piIdProspect", SqlDbType = SqlDbType.Int, Value = id, Direction = ParameterDirection.Input });
                    SqlDataReader conHistorialProspect = _conexionSql.ExecuteStoredProcedure(Constants.schemaAuditoria + ListStoreProducers.Spconconsultahistorialprospectoid, _lista.Parameters);
                    model = _consultaBitacora.ConHistorialProspectoReader(conHistorialProspect);
                    model.StatusCode = 1;
                    model.Message = Constants.peticionExitosa;
                }
                _conexionSql.CloseConnection();
            }
            catch (Exception)
            {
                model.Message = "Error al conectar a Bd";
                model.StatusCode = 500;
                throw;
            }

            return model;
        }

        public ModelApiResponse ConRegistrosBitacora()
        {
            ModelApiResponse model = new ModelApiResponse();

            try
            {
                if (_conexionSql.openConnection())
                {
                    SqlDataReader conBitacoraReader = _conexionSql.ExecuteStoredProcedure(Constants.schemaAuditoria + ListStoreProducers.SPConRegistrosBitacora, _lista.Parameters);
                    model.StatusCode = 1;
                    model.Message = Constants.peticionExitosa;
                    model = _consultaBitacora.ConsultaBitacoraReader(conBitacoraReader);
                }
                _conexionSql.CloseConnection();
            }
            catch (Exception)
            {
                model.Message = "Error al conectar a Bd";
                model.StatusCode = 500;
                throw;
            }

            return model;
        }

    }
}
