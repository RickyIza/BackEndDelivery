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
    public class PedidoController : ApiController
    {
    
        public IHttpActionResult Post(Pedido pedido)
        {
            try
            {
                PedidoBLL.Create(pedido);
                return Content(HttpStatusCode.Created, "Materia creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      

        public IHttpActionResult Get()
        {
            try
            {
                List<Pedido> todos = PedidoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
       
        public IHttpActionResult Put(Pedido pedido)
        {
            try
            {
                PedidoBLL.Update(pedido);
                return Content(HttpStatusCode.OK, "Materia actualizado correctamente");

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
                Pedido result = PedidoBLL.Get(id);
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

      
        public IHttpActionResult Delete(int id)
        {
            try
            {
                PedidoBLL.Delete(id);
                return Ok("Materia eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
