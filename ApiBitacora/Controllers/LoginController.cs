using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelsApi.Models;
using Newtonsoft.Json.Linq;
using ServicesApi.InterfaceApi;

namespace ApiBitacora.Controllers
{
    [ApiController]
    [Route("login")]

    public class LoginController : Controller
    {
        private readonly IAuthServices _service;
        public LoginController(IAuthServices service) => _service = service;

        [HttpPost("00")]
        public IActionResult auth([FromBody] ModelUserLogin usuario)
        {

            IActionResult? Status = null;

            if (usuario == null)
            {
                Status = Unauthorized();
            }
            else
            {
                var token = _service.login(usuario);


                if (!String.IsNullOrEmpty(token))
                {
                    Response.Headers.Add("Authorization", $"Bearer {token}");
                    Status = Ok();
                }
                else
                {
                    Status = Unauthorized();
                }
            }

            return Status;

        }



        [HttpPost("01")]
        public IActionResult generaToken([FromBody]ModelUserLogin user) 
        {
            string token = _service.auth(user);
            Response.Headers.Add("Authorization", $"Bearer {token}");

            return StatusCode(StatusCodes.Status200OK);
        }


        [HttpPost("02")]
        public IActionResult authlogin([FromBody] ModelUserLogin usuario)
        {
            ModelApiResponse model = new ModelApiResponse();
            ModelResLogin modelResLogin = new ModelResLogin();

            IActionResult? Status = null;
            if (usuario.UserName.IsNullOrEmpty())
            {
                // Devuelve un 401 Unauthorized
                Status = Unauthorized(new { error = "Usuario no válido" });

        }
            else
            {
                // Procede con la autenticación
                model = _service.authlogin(usuario);
                modelResLogin = (ModelResLogin)model.Data;

                if (model.StatusCode==0)
                {
                    Status = Unauthorized(new { error = "Usuario no válido" });

                }
                else
                {

                    Response.Headers.Add("Authorization", $"Bearer {modelResLogin.token}");
                    Status = Ok(new { idUser = modelResLogin.IdUser });

                }




            }


            // Devuelve el resultado en el cuerpo de la respuesta
            return Status;
        }


    }
}
