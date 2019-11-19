using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
			try
			{
				BancoFacade fcd = new BancoFacade();
				ViewBag.Lista = fcd.List();

				return View();
			}
			catch (Exception ex)
			{

				return View("Error");
			}

        }

		public ActionResult Form() {
			return View();
		}

		[HttpPost]
		public ActionResult Form(Banco item)
		{
			try
			{
				item.FechaDeRegistro = DateTime.Now;

				//Validanmos los datos desde backend

				BancoFacade fcd = new BancoFacade();
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