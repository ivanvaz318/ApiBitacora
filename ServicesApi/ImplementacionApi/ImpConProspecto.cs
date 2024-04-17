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
    public class ImpConProspecto : IConsultaProspecto
    {
        private readonly ConexionSql _conexionSql;
        private readonly SqlServerParameterList _lista;
        private readonly ConsultaProspecto _consultaProspecto;

        public ImpConProspecto(ConexionSql conexionSql, SqlServerParameterList lista, ConsultaProspecto consultaProspecto)
        {
            _conexionSql = conexionSql;
            _lista = lista;
            _consultaProspecto = consultaProspecto;
        }

        public ModelApiResponse ConsListProspecto()
        {
            ModelApiResponse model = new ModelApiResponse();

            try
            {
                if (_conexionSql.openConnection())
                {
                    SqlDataReader listaProspectosReader = _conexionSql.ExecuteStoredProcedure(Constants.schemaProspects + ListStoreProducers.SPConProspectsLista, _lista.Parameters);
                    model = _consultaProspecto.ConListProspects(listaProspectosReader);
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

        public ModelApiResponse ConsProspecto(int idProspect)
        {
           ModelApiResponse model = new ModelApiResponse();

            try
            {
                if (_conexionSql.openConnection())
                {
                    _lista.Parameters.Insert(0, new SqlParameter { ParameterName = "@piId", SqlDbType = SqlDbType.Int, Value = idProspect, Direction = ParameterDirection.Input });
                    SqlDataReader consultaProspectReader = _conexionSql.ExecuteStoredProcedure(Constants.schemaProspects + ListStoreProducers.SPConProspects, _lista.Parameters);
                    model = _consultaProspecto.ConsultaProspectoReader(consultaProspectReader);
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
