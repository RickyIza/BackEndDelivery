using BEUDelivery;
using BEUDelivery.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DeliveryApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ReportesController : ApiController
    {
        [HttpGet]
        [Route("ProductosVendidos")]
        public IHttpActionResult GetProductosVendidos()
        {
            try
            {
                List<rptProductosVendidos_Result> todos = ReportesBLL.GetProductosVendidos();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("PedidosClientes")]
        public IHttpActionResult GetPedidos()
        {
            List<rptNumeroPedidos_Result> todos = ReportesBLL.GetPedidosCliente();
            return Json(todos);
        }
        [HttpGet]
        [Route("PedidosClientesMes")]
        public IHttpActionResult Get()
        {
            try
            {
                List<List<rptAgrupadosPedidosClientesMes_Result>> todos = ReportesBLL.GetPedidosMes();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("ProductosVendidosMes")]
        public IHttpActionResult GetProductosMes()
        {
            List<List<rptProductosVendidosMes_Result>> todos = ReportesBLL.GetProductosMes();
            return Json(todos);
        }

        /*public IHttpActionResult GetCantidad()
        {
            List<rptNumeroPedidos_Result> ventas = ReportesBLL.GetPedidosCliente();
            return Json(ventas);
        }*/
    }
}
