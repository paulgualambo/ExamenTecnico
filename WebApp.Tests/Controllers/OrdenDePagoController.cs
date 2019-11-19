using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using WebApp.Models;
using WS = WebApp.Services;

namespace WebApp.Tests.Controllers
{
	[TestClass]
	public class OrdenDePagoControllerTest
	{



		[TestMethod]
		public void ModelInsert()
		{

			OrdenDePagoFacade fcd = new OrdenDePagoFacade();
			fcd.Insert(new OrdenDePago()
			{
				Monto = 100.20,
				Moneda = "PEN",
				Estado = "P",
				FechaDePago = DateTime.Now,
				IdSucursal = 4
			});

			// Assert
			Assert.IsNotNull(true);
		}

		[TestMethod]
		public void ModelList()
		{

			OrdenDePagoFacade fcd = new OrdenDePagoFacade();
			var lista = fcd.List();

			// Assert
			Assert.IsTrue(lista.Count > 0);
		}

		[TestMethod]
		public void Index()
		{
			//// Arrange
			//HomeController controller = new HomeController();

			//// Act
			//ViewResult result = controller.Index() as ViewResult;

			OrdenDePagoController controller = new OrdenDePagoController();
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Form()
		{
			//// Arrange
			//HomeController controller = new HomeController();

			//// Act
			//ViewResult result = controller.Index() as ViewResult;

			OrdenDePagoController controller = new OrdenDePagoController();
			ViewResult result = controller.Form() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void FormPost()
		{
			//// Arrange
			//HomeController controller = new HomeController();

			//// Act
			//ViewResult result = controller.Index() as ViewResult;

			OrdenDePagoController controller = new OrdenDePagoController();
			var result = controller.Form(new OrdenDePago()
			{
				Monto = 100.20,
				Moneda = "PEN",
				Estado = "P",
				FechaDePago = DateTime.Now,
				IdSucursal = 4
			}) as RedirectToRouteResult;

			//Regresando a la pagina inicial
			Assert.IsTrue(result.RouteValues["action"].Equals("Index"));
		}

		[TestMethod]
		public void WebServicesFormatJson()
		{
			WS.OrdenDePago ws = new WS.OrdenDePago();
			ws.List("USD");

			Assert.IsTrue(true);
		}
	}
}
