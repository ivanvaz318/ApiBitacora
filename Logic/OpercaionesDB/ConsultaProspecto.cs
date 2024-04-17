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
    public class ConsultaProspecto
    {
        public ModelApiResponse ConsultaProspectoReader(SqlDataReader prospectoReader)
        {

            ModelApiResponse model = new ModelApiResponse();
            List<ModelProspecto> listInfoProspecto = new List<ModelProspecto>();

            if (prospectoReader.HasRows)
            {
                listInfoProspecto = prospectoReader.MapToList<ModelProspecto>();
            }
            prospectoReader.Close();

            if (listInfoProspecto.Count > 0)
            {
                model.StatusCode = 1;
                model.Data = listInfoProspecto;
            }
            else
            {
                model.StatusCode = 0;
                model.Message = Constants.peticionSinDatos;
            }



            return model;
        }

        public ModelApiResponse ConListProspects(SqlDataReader conListProspectsReader)
        {
            ModelApiResponse model = new ModelApiResponse();
            List<ModelConListProspectos> listConProspects = new List<ModelConListProspectos>();

            if (conListProspectsReader.HasRows)
            {
                listConProspects = conListProspectsReader.MapToList<ModelConListProspectos>();
            }
            conListProspectsReader.Close();

            if(listConProspects.Count > 0)
            {
                model.StatusCode = 1;
                model.Data = listConProspects;
            }
            else
            {
                model.StatusCode = 0;
                model.Message= Constants.peticionSinDatos;
            }

            return model;
        }
    }
}
