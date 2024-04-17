using Microsoft.AspNetCore.Mvc;
using ModelsApi.Models;
using ServicesApi.InterfaceApi;

namespace ApiBitacora.Controllers
{
    [ApiController]
    [Route("prospectos")]// ruta de la peticion ejemplo /prospectos/00
    public class ProspectosController : Controller
    {
        private IFaseProspectos _service;
        private IConsultaProspecto _conProspecto;
        public ProspectosController(IFaseProspectos service, IConsultaProspecto conProspecto )
        {
             _service = service;
            _conProspecto = conProspecto;
        }

        [HttpPost("00")]
        public ModelApiResponse ConsultaProspecto(int idProspect)
        {
            ModelApiResponse model = new ModelApiResponse();

            model = _conProspecto.ConsProspecto(idProspect);

            return model;
        }




        [HttpGet("01")]
        public ModelApiResponse ConFaseProspectos()
        {

            ModelApiResponse model = new ModelApiResponse();

            model = _service.FaseProspectos();

            return model;
        }

        [HttpGet("02")]
        public ModelApiResponse ConListaProspectos()
        {
            ModelApiResponse model = new ModelApiResponse();
            model = _conProspecto.ConsListProspecto();

            return model;
        }
    }
}
