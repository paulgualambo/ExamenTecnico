using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using Mdl = WebApp.Models;

namespace WebApp.Services
{
	/// <summary>
	/// Descripción breve de OrdenDePago
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
	// [System.Web.Script.Services.ScriptService]
	public class OrdenDePago : System.Web.Services.WebService
	{

		[WebMethod]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public void List(string moneda)
		{
			Mdl.OrdenDePagoFacade fcd = new Mdl.OrdenDePagoFacade();
			var lista =  fcd.List(moneda);
			JavaScriptSerializer js = new JavaScriptSerializer();
			Context.Response.Write(js.Serialize(lista));
		}
	}
}
