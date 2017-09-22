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
	public class ContextFactory
	{
		public const string ProductRepositoryTypeName = "ProductRepositoryType";

		public static DbContext CreateContext()
		{
			string productRepositoryTypeName = WebConfigurationManager.AppSettings[ProductRepositoryTypeName];

			Type type = Type.GetType(productRepositoryTypeName);

			return Activator.CreateInstance(type) as DbContext;
		}
	}
}
