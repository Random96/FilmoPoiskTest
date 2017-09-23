using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace FilmoPoiskTest.Model
{
	/// <summary>
	/// Database context factory class 
	/// some class of asp.net not suppor of DI
	/// </summary>
	public class ContextFactory
	{
		public const string ProductRepositoryTypeName = "ProductRepositoryType";

		public static DbContext CreateContext()
		{
			// get class name from web.config
			string productRepositoryTypeName = WebConfigurationManager.AppSettings[ProductRepositoryTypeName];

			// load assembly and get type. Assembly shut be in bin directory
			Type type = Type.GetType(productRepositoryTypeName);


			return Activator.CreateInstance(type) as DbContext;
		}
	}
}
