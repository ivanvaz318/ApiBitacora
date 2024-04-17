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
    public class ConsultaUsuario
    {
        public ModelApiResponse consultaUsuarioReader(SqlDataReader usuarioReader)
        {
            ModelApiResponse model = new ModelApiResponse();
            List<ModelUsuario> listHistoricoProspecto = new List<ModelUsuario>();

            if (usuarioReader.HasRows)
            {
                listHistoricoProspecto = usuarioReader.MapToList<ModelUsuario>();

            }
            usuarioReader.Close();

            if (listHistoricoProspecto.Count > 0)
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
