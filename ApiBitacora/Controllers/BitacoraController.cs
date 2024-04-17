using Microsoft.AspNetCore.Mvc;
using ModelsApi.Models;
using ServicesApi.InterfaceApi;

namespace ApiBitacora.Controllers
{
    [ApiController]
    [Route("bitacora")] //ruta de peticion /bitacora/00
    public class BitacoraController : Controller
    {
        private IConBitacora _service;
        public BitacoraController(IConBitacora service) => _service = service;

        [HttpGet("00")]
        public ModelApiResponse ConRegistrosBitacora()
        {
            ModelApiResponse model = new ModelApiResponse();

            model = _service.ConRegistrosBitacora();

            return model;

        }
        [HttpGet ("01")]
        public ModelApiResponse ConHistorialProspect(int id)
        {
            ModelApiResponse model = new ModelApiResponse();

            model = _service.ConHistorialProspecto(id);

            return model;
        }
    }
}
