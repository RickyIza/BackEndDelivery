using BEUDelivery;
using BEUDelivery.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiMiVeci.Models;


namespace DeliveryApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(Usuario usuariosesion)
        {
            if (usuariosesion == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            usuariosesion = UsuarioBLL.Validate(usuariosesion);
            if (usuariosesion != null)
            {
                return Ok(new
                {
                    user = usuariosesion,
                    token = TokenGenerator.GenerateTokenJwt(usuariosesion)
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
    

