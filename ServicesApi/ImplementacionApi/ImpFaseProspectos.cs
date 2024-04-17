using DAOApi;
using Logic.OpercaionesDB;
using ModelsApi;
using ModelsApi.Models;
using ServicesApi.InterfaceApi;
using System.Data.SqlClient;

namespace ServicesApi.ImplementacionApi
{
    public class ImpFaseProspectos : IFaseProspectos
    {
        private readonly ConexionSql _conexionSql;
        private readonly SqlServerParameterList _lista;
        private readonly FaseProspectos _faseProspecto;

        public ImpFaseProspectos(ConexionSql conexionSql, SqlServerParameterList lista, FaseProspectos faseProspecto)
        {
            _conexionSql = conexionSql;
            _lista = lista;
            _faseProspecto = faseProspecto;
        }

        public ModelApiResponse FaseProspectos()
        {
            ModelApiResponse model = new ModelApiResponse();

            try
            {
                if (_conexionSql.openConnection())
                {
                    SqlDataReader faseProspectReader = _conexionSql.ExecuteStoredProcedure(Constants.schemaAuditoria + ListStoreProducers.SPConFaseProspectos, _lista.Parameters);
                    model = _faseProspecto.ConsultaFaseProspectos(faseProspectReader);
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
