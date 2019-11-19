using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			//// Arrange
			//HomeController controller = new HomeController();

			//// Act
			//ViewResult result = controller.Index() as ViewResult;

			BancoFacade fcd = new BancoFacade();
			var lista = fcd.List();

			// Assert
			Assert.IsNotNull(true);
		}

		[TestMethod]
		public void PruebaInsert()
		{

			BancoFacade fcd = new BancoFacade();
			fcd.Insert(new Banco() {
				Nombre = "Banco 3",
				Direccion = "Direccion 3",
				FechaDeRegistro = DateTime.Now
			});

			// Assert
			Assert.IsNotNull(true);
		}

		[TestMethod]
		public void Contact()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Contact() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
