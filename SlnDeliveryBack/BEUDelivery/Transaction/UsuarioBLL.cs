using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transaction
{
	public class UsuarioBLL
	{
		public static Usuario Get(int? id)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Usuario.Find(id);
		}

		public static void Create(Usuario u)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Usuario.Add(u);
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

		public static void Update(Usuario usuario)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Usuario.Attach(usuario);
						db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
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
						Usuario usuario = db.Usuario.Find(id);
						db.Entry(usuario).State = System.Data.Entity.EntityState.Deleted;
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

		public static List<Usuario> List()
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Usuario.ToList();
		}

		

		public static List<Usuario> List(string criterio)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Usuario.Where(x => x.cedula.Contains(criterio)).ToList();
		}

		public static Usuario Validate(Usuario usuario)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Usuario.FirstOrDefault(x => x.usuariosesion == usuario.usuariosesion
				&& x.contrasena == usuario.contrasena);

			/*            foreach (var item in db.Usuarios.ToList())
						{
							if (item.correo == persona.correo && item.password == persona.password)
							{
								return item;
							}
						}
						return null;*/

		}


	}
}
