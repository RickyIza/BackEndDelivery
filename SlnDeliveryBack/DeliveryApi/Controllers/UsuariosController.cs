using BEUDelivery;
using BEUDelivery.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DeliveryApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
        
        public IHttpActionResult Post(Usuario usuario)
        {
            try
            {
                UsuarioBLL.Create(usuario);
                return Content(HttpStatusCode.Created, "Usuario creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        public IHttpActionResult Get()
        {
            List<Usuario> todos = UsuarioBLL.List();
            return Json(todos);
        }
       

        public IHttpActionResult Put(Usuario alumno)
        {
            try
            {
                UsuarioBLL.Update(alumno);
                return Content(HttpStatusCode.OK, "Usuario actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        public IHttpActionResult Get(int id)
        {
            try
            {
                Usuario result = UsuarioBLL.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
       
        public IHttpActionResult Get(string criteria)
        {
            try
            {
                List<Usuario> todos = UsuarioBLL.List(criteria);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
       
        public IHttpActionResult Delete(int id)
        {
            try
            {
                UsuarioBLL.Delete(id);
                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
