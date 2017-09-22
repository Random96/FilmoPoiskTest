using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace FilmoPoiskTest
{
	internal class AutofacConfig
	{
		public static IComponentContext ConfigureContainer()
		{
			// получаем экземпляр контейнера
			var builder = new ContainerBuilder();

			// регистрируем контроллер в текущей сборке
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			// load external library
			Type type = Type.GetType(WebConfigurationManager.AppSettings[Model.ContextFactory.ProductRepositoryTypeName]);


			foreach (var modul in AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetTypes().Where(p => p.Name == "AutofacModule").Any()))
			{
				var Type = modul.GetTypes().FirstOrDefault(x => x.Name == "AutofacModule");

				typeof(ModuleRegistrationExtensions)
					?.GetMethods()
					?.FirstOrDefault(l => l.Name == "RegisterModule" && l.GetParameters().Where(x => x.Name == "builder").Any())
					?.MakeGenericMethod(Type)
					?.Invoke(null, new[] { builder });
			}

			// создаем новый контейнер с теми зависимостями, которые определены выше
			var container = builder.Build();

			// установка сопоставителя зависимостей
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			return container;
		}
	}
}