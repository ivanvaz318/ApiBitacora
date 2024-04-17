using DAOApi;
using ModelsApi.Models;
using ModelsApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.OpercaionesDB
{
    public class FaseProspectos
    {
        public ModelApiResponse ConsultaFaseProspectos(SqlDataReader faseProspectosReader)
        { 
            ModelApiResponse model = new ModelApiResponse();
            List<ModelFaseProspectos> listFaseProspectos =  new List<ModelFaseProspectos>();

            if (faseProspectosReader.HasRows)
            {
                listFaseProspectos = faseProspectosReader.MapToList<ModelFaseProspectos>();
            }
            faseProspectosReader.Close();

            if (listFaseProspectos.Count > 0)
            {
                model.StatusCode = 1;
                model.Data = listFaseProspectos;
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
