using BEUDelivery;
using BEUDelivery.Transaction;
using System;
using System.Collections.Generic;
using System.Net;

using System.Web.Http;
using System.Web.Http.Cors;


namespace DeliveryApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductosController : ApiController
    {
       
        public IHttpActionResult Post(Producto p)
        {
            try
            {
                ProductoBLL.Create(p);
                return Content(HttpStatusCode.Created, "Producto creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      
        public IHttpActionResult Get()
        {
            List<Producto> todos = ProductoBLL.List();
            return Json(todos);
        }



        public IHttpActionResult Put(Producto p)
        {
            try
            {
                ProductoBLL.Update(p);
                return Content(HttpStatusCode.OK, "Producto actualizado correctamente");

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
                Producto result = ProductoBLL.Get(id);
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
                List<Producto> todos = ProductoBLL.List(criteria);
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
                ProductoBLL.Delete(id);
                return Ok("Producto eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
