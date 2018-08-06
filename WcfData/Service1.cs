using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfData
{
	// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
	public class Service1 : IService1
	{
		private const string HashId = "Alumnos";
		IRedisClientsManager Manager;
		IRedisTypedClient<Alumno> redisClient;

		public Service1()
		{
			this.Manager = new RedisManagerPool();
			this.redisClient = Manager.GetClient().As<Alumno>();
		}

		public Alumno Add(Alumno alumno)
		{
			try
			{
				var Hash = redisClient.GetHash<string>(HashId);
				redisClient.SetEntryInHashIfNotExists(Hash, alumno.Nombre, alumno);
				return redisClient.GetFromHash(alumno.Nombre);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Alumno> GetAll()
		{
			try
			{
				var Hash = redisClient.GetHash<string>(HashId);
				return redisClient.GetHashValues(Hash);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Alumno GetByName(string name)
		{
			try
			{
				
				var Hash = redisClient.GetHash<string>(HashId);
				return redisClient.GetValueFromHash(Hash, name);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public bool Delete(string name)
		{
			try
			{
				var Hash = redisClient.GetHash<string>(HashId);
				if (redisClient.HashContainsEntry(Hash, name))
					redisClient.DeleteById(name);
				else
					return false;
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		//public Alumno Update()
		//{

		//}
	}
}
