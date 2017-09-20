using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmoPoiskTest;
using FilmoPoiskTest.Controllers;
using Moq;
using System.Threading.Tasks;

namespace FilmoPoiskTest.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		private Mock<Models.ICinemaService> _rep;

		Models.ICinemaService Rep => _rep?.Object ?? (_rep = new Mock<Models.ICinemaService>()).Object;

		[TestMethod]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController(Rep);

			// Act
			var result = controller.Index();

			result.Wait();

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void About()
		{
			// Arrange
			HomeController controller = new HomeController(Rep);

			// Act
			ViewResult result = controller.About() as ViewResult;

			// Assert
			Assert.AreEqual("Your application description page.", result.ViewBag.Message);
		}

		[TestMethod]
		public void Contact()
		{
			// Arrange
			HomeController controller = new HomeController(Rep);

			// Act
			ViewResult result = controller.Contact() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
