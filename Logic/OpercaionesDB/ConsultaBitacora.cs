using DAOApi;
using ModelsApi;
using ModelsApi.Models;
using System.Data.SqlClient;


namespace Logic.OpercaionesDB
{
    public class ConsultaBitacora
    {
        public ModelApiResponse ConsultaBitacoraReader(SqlDataReader bitacoraReader)
        {
            ModelApiResponse model = new ModelApiResponse();
            List<ModelConBitacora> listConBitacora = new List<ModelConBitacora>();

            if (bitacoraReader.HasRows)
            {
                listConBitacora = bitacoraReader.MapToList<ModelConBitacora>();
            }
            bitacoraReader.Close();

            if(listConBitacora.Count > 0)
            {
                model.StatusCode = 1;
                model.Data = listConBitacora;
                model.Message = Constants.peticionExitosa;
            }
            else
            {
                model.StatusCode = 0;
                model.Message = Constants.peticionSinDatos;
            }

            return model;
        }

        public ModelApiResponse ConHistorialProspectoReader(SqlDataReader historialProspectoReader) {
            ModelApiResponse model = new ModelApiResponse();
            List<ModelConBitacoraHistorial> listaHistorialProspecto = new List<ModelConBitacoraHistorial>();

            if (historialProspectoReader.HasRows)
            {
                listaHistorialProspecto = historialProspectoReader.MapToList<ModelConBitacoraHistorial>();
            }
            historialProspectoReader.Close();

            if (listaHistorialProspecto.Count > 0)
            {
                model.StatusCode = 1;
                model.Data = listaHistorialProspecto;
                model.Message = Constants.peticionExitosa;
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
