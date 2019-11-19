using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
	public class OrdenDePago
	{
		public int Id { get; set; }
		public double Monto { get; set; }
		public string Moneda { get; set; }
		public string Estado { get; set; }
		public DateTime FechaDePago { get; set; }
		public int IdSucursal { get; set; }
		public Sucursal Sucursal { get; set; }
	}
}