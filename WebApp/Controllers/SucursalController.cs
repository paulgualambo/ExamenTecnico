using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SucursalController : Controller
    {
		// GET: Sucursal
		public ActionResult Index()
		{
			try
			{
				SucursalFacade fcd = new SucursalFacade();
				ViewBag.Lista = fcd.List();

				return View();
			}
			catch (Exception ex)
			{

				return View("Error");
			}

		}

		public ActionResult Form()
		{
			ViewBag.ListaBanco = (new BancoFacade()).List();
			return View();
		}

		[HttpPost]
		public ActionResult Form(Sucursal item)
		{
			try
			{
				item.FechaDeRegistro = DateTime.Now;

				//Validanmos los datos desde backend

				SucursalFacade fcd = new SucursalFacade();
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