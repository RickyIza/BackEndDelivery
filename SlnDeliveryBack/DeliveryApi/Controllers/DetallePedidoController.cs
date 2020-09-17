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
    public class DetallePedidoController : ApiController
    {
    
        public IHttpActionResult Post(DetallePedido detalle)
        {
            try
            {
                DetallePedidoBLL.Create(detalle);
                return Content(HttpStatusCode.Created, "Detalle creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
