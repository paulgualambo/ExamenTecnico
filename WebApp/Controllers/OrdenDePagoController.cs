using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrdenDePagoController : Controller
    {

		private Dictionary<string, string> ListaMoneda = new Dictionary<string, string>() {
			{"PEN", "Soles - PEN"  },
			{"USD", "Dólares - USD"  },
		};

		// pagada, declinada, fallida y anulada.
		private Dictionary<string, string> ListaEstado = new Dictionary<string, string>() {
			{"P", "Pagada"  },
			{"D", "Declinada"  },
			{"F", "Fallada"  },
			{"A", "Anulada"  }
		};

		// GET: OrdenDePago
		public ActionResult Index()
		{
			try
			{
				OrdenDePagoFacade fcd = new OrdenDePagoFacade();
				ViewBag.Lista = fcd.List();

				ViewBag.ListaMoneda = ListaMoneda;
				ViewBag.ListaEstado = ListaEstado;

				return View();
			}
			catch (Exception ex)
			{

				return View("Error");
			}

		}

		public ActionResult Form()
		{
			ViewBag.ListaSucursal = (new SucursalFacade()).List();
			ViewBag.ListaMoneda = ListaMoneda;
			ViewBag.ListaEstado = ListaEstado;

			return View();
		}

		[HttpPost]
		public ActionResult Form(OrdenDePago item)
		{
			try
			{
				item.FechaDePago = DateTime.Now;

				//Validamos los datos desde backend

				OrdenDePagoFacade fcd = new OrdenDePagoFacade();
				fcd.Insert(item);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{

				return View("Error");
			}

		}
	}
}