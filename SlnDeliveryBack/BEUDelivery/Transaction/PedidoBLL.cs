using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transaction
{
	public class PedidoBLL
	{
		public static Pedido Get(int? id)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Pedido.Find(id);
		}

		public static void Create(Pedido p)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						Config(p);
						db.Pedido.Add(p);
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
		}

		public static void Config(Pedido p)
		{
			p.fechapedido = DateTime.Now;
			//p.total = p.DetallePedido.Sum(x => x.subtotal);
		}

		public static void Update(Pedido p)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Pedido.Attach(p);
						db.Entry(p).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static void Delete(int? id)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						Pedido p = db.Pedido.Find(id);
						db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static List<Pedido> List()
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Pedido.ToList();
		}

	}
}
