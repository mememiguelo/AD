using System;

namespace PReflection
{
	public class Categoria
	{
		//public ulong Id { get; set; }
		//public string Nombre { get; set; }

		public Categoria(ulong id, string nombre){
			this.id = id;
			this.nombre = nombre;
		}
		[Id]
		private ulong id;
		private string nombre;

		public ulong Id{
			get{ return id; }
			set{ id = value; }
		}

		public string Nombre{
			get{ return nombre; }
			set{ nombre = value; }
		}
	}
}

