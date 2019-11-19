using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
	public class Banco
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public DateTime FechaDeRegistro { get; set; }
	}
}