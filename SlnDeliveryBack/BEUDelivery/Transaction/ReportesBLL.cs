using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transaction
{
	public class ReportesBLL
	{
		public static List<rptProductosVendidos_Result> GetProductosVendidos()
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.rptProductosVendidos().ToList();
		}

		public static List<rptNumeroPedidos_Result> GetPedidosCliente()
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.rptNumeroPedidos().ToList();
		}

		/*public static List<rptProductosVendidosFechas_Result> GetProductosMes(DateTime fechainicial, DateTime fechafinal)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.rptProductosVendidosFechas(fechainicial,fechafinal).ToList();
		}*/

		public static List<List<rptProductosVendidosMes_Result>> GetProductosMes()
		{
			int? cantidad;
			List<Producto> producto = ProductoBLL.List();
			DeliveryEntities db = new DeliveryEntities();
			List<rptProductosVendidosMes_Result> n = db.rptProductosVendidosMes().ToList();
			List<rptProductosVendidosMes_Result> nueva = new List<rptProductosVendidosMes_Result>();
			List<List<rptProductosVendidosMes_Result>> datos = new List<List<rptProductosVendidosMes_Result>>();
			foreach (var item in producto)
			{
				for (int i = 1; i <= 12; i++)
				{
					rptProductosVendidosMes_Result p = new rptProductosVendidosMes_Result();
					cantidad = 0;
					foreach (var j in n)
					{
						if (j.MES == i && j.Producto.Equals(item.nombre))
						{
							cantidad = j.Cantidad;
						}
					}
					p.MES = i;
					p.Cantidad = cantidad;
					p.Producto = item.nombre;
					nueva.Add(p);
				}
				datos.Add(nueva);
			}
			return datos.ToList();
		}

		public static List<List<rptAgrupadosPedidosClientesMes_Result>> GetPedidosMes()
		{
			//int count;
			int? cantidad;
			//string nombre;
			List<Usuario> usuario = UsuarioBLL.List();
			DeliveryEntities db = new DeliveryEntities();
			List<rptAgrupadosPedidosClientesMes_Result> n = db.rptAgrupadosPedidosClientesMes().ToList();
			List<rptAgrupadosPedidosClientesMes_Result> nueva = new List<rptAgrupadosPedidosClientesMes_Result>();
			List<List<rptAgrupadosPedidosClientesMes_Result>> datos = new List<List<rptAgrupadosPedidosClientesMes_Result>>();
			foreach (var item in usuario)
			{
				for (int i = 1; i <= 12; i++)
				{
					rptAgrupadosPedidosClientesMes_Result pedidos = new rptAgrupadosPedidosClientesMes_Result();
					cantidad = 0;
					foreach (var j in n)
					{
						if (j.MES == i && j.Cliente.ToString().Equals(item.ToString()))
						{
							cantidad = j.Pedidos;
						}
					}
					pedidos.MES = i;
					pedidos.Pedidos = cantidad;
					pedidos.Cliente = item.ToString();
					nueva.Add(pedidos);
				}
				datos.Add(nueva);
			}
			return datos.ToList();
		}
	}
}
