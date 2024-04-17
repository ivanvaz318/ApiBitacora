using Microsoft.AspNetCore.Mvc;
using ModelsApi.Models;
using ServicesApi.InterfaceApi;

namespace ApiBitacora.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class ConsultaUsuarioController : Controller
    {

        private IConUsuario _service;
        public ConsultaUsuarioController (IConUsuario service) => _service = service;

        [HttpGet("01")]
        public ModelApiResponse ConsultaUsuario([FromQuery] int idUser)
        {
         
            ModelApiResponse model = new ModelApiResponse();
            
            model = _service.ConUser(idUser);

            return model;
        }
    }
}
