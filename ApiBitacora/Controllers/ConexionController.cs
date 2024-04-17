using Microsoft.AspNetCore.Mvc;
using DAOApi;
using DAOApi.Models;
using ModelsApi.Models;
using ServicesApi.InterfaceApi;
namespace ApiBitacora.Controllers
{
    [ApiController]
    [Route("consulta")]
    public class ConexionController : Controller
    {
        private InterfaceGenerica _service;
        public ConexionController (InterfaceGenerica service ) => _service = service;

        [HttpGet("01")]
        public ModelApiResponse ConsultaHistorialProspecto()
        {


            ModelApiResponse model = new ModelApiResponse();

            model = _service.conexion();

            return model;
        }
    }
}
