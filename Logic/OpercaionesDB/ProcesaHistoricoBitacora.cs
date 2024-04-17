using DAOApi;
using ModelsApi;
using ModelsApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.OpercaionesDB
{
    public class ProcesaHistoricoBitacora
    {

        public ModelApiResponse procesaHistoricoBitacoraReader(SqlDataReader historicoBitacoraReader)
        {
            ModelApiResponse model = new ModelApiResponse();
            List<ModelHistoricoProspecto> listHistoricoProspecto = new List<ModelHistoricoProspecto>();

            if (historicoBitacoraReader.HasRows)
            {
                listHistoricoProspecto = historicoBitacoraReader.MapToList<ModelHistoricoProspecto>();

            } 
            historicoBitacoraReader.Close();

            if(listHistoricoProspecto.Count > 0)
            {
                model.StatusCode = 1;
                model.Data = listHistoricoProspecto;

            }
            else
            {
                model.StatusCode = 0;
                model.Message = Constants.peticionSinDatos;
            }


           return model;

        }
    }
}
