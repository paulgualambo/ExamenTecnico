using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Tests.Controllers
{
	[TestClass]
	public class SucursalControllerTest
	{

		[TestMethod]
		public void ModelInsert()
		{

			SucursalFacade fcd = new SucursalFacade();
			fcd.Insert(new Sucursal()
			{
				Nombre = "Banco 3",
				Direccion = "Direccion 3",
				FechaDeRegistro = DateTime.Now,
				IdBanco = 1
			});

			// Assert
			Assert.IsNotNull(true);
		}

		[TestMethod]
		public void ModelList()
		{

			SucursalFacade fcd = new SucursalFacade();
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

			SucursalController controller = new SucursalController();
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

			SucursalController controller = new SucursalController();
			ViewResult result = controller.Form(new Models.Sucursal() {
				Nombre = "Sucursal "+ (new Random().Next()).ToString(),
				Direccion = "Direccion " + (new Random().Next()).ToString(),
				IdBanco = 2
			}) as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}


	}
}
