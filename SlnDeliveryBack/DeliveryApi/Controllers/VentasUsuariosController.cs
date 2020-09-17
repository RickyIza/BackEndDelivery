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
    public class VentasUsuariosController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<rptNumeroPedidos_Result> todos = ReportesBLL.GetPedidosCliente();
            return Json(todos);
        }
    }
}
