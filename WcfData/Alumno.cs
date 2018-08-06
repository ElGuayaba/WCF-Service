using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfData
{
	[DataContract]
	public class Alumno
	{
		[DataMember]
		public string Nombre { get; set; }
		[DataMember]
		public string Apellidos { get; set; }
	}
}
