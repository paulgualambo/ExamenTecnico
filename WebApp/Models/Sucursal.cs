using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
	public class Sucursal
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public DateTime FechaDeRegistro { get; set; }
		public int IdBanco { get; set; }
		public Banco Banco { get; set; }
	}
}