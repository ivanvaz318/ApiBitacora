using Microsoft.AspNetCore.Mvc;

namespace ApiBitacora.Controllers
{
    [ApiController]
    [Route("status")]
    public class StatusController : ControllerBase
    {

        [HttpGet("100")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string Status()
        {

            return "Servicio Funcionando Correctamente";
        }
    }
}
