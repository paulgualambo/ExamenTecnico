using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Tests.Controllers
{
	[TestClass]
	public class BancoControllerTest
	{

		[TestMethod]
		public void ModelList()
		{

			BancoFacade fcd = new BancoFacade();
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

			BancoController controller = new BancoController();
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Insert()
		{
			//// Arrange
			//HomeController controller = new HomeController();

			//// Act
			//ViewResult result = controller.Index() as ViewResult;

			BancoController controller = new BancoController();
			ViewResult result = controller.Form(new Models.Banco() {
				Nombre = "Banco "+ (new Random().Next()).ToString(),
				Direccion = "Direccion " + (new Random().Next()).ToString()
			}) as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
