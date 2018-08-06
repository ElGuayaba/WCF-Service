using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfData
{
	// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
	[ServiceContract]
	public interface IService1
	{
		[OperationContract]
		List<Alumno> GetAll();
		[OperationContract]
		Alumno Add(Alumno alumno);
		[OperationContract]
		Alumno GetByName(string name);
		[OperationContract]
		bool Delete(string name);
	}
}
