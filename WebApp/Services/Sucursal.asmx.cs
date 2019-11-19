using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Mdl = WebApp.Models;

namespace WebApp.Services
{
	/// <summary>
	/// Descripción breve de Sucursal
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
	// [System.Web.Script.Services.ScriptService]
	public class Sucursal : System.Web.Services.WebService
	{

		[WebMethod]
		public List<Mdl.Sucursal> Buscar(int IdBanco)
		{
			Mdl.SucursalFacade fcd = new Mdl.SucursalFacade();
			return fcd.List((int?)IdBanco);
		}
	}
}
