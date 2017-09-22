using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
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

			// регистрируем споставление типов
			// builder.RegisterType<Models.ApplicationDbContext>().As<Data.IContext>().SingleInstance();

			//builder.RegisterType<ModelView.SourceModelView>().As<ModelView.ISourceModelView>();

			//builder.RegisterType<Domain.HttpGrubber>().As<Domain.IGrubber>();

			// Мы не доверяем администратору
			//builder.RegisterType<Data.SqlContext>().WithParameter("ConnectionString",
			//	@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=EmlSoft.KBSTest.SqlContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
			//  .InstancePerLifetimeScope()
			//  .ExternallyOwned();


			foreach( var modul in AppDomain.CurrentDomain.GetAssemblies() )
			{
				var Type = modul.GetTypes().FirstOrDefault(x=>x.Name == "AutofacModule");
				if( Type != null )
				{
					var q = typeof(ModuleRegistrationExtensions);
					var p = q.GetMethods().FirstOrDefault( l=>l.Name == "RegisterModule" && l.GetParameters().Where(x=>x.Name == "builder").Any() );
					var r = p.MakeGenericMethod(Type);
					r.Invoke(null, new[] { builder} );
				}
			}

			// создаем новый контейнер с теми зависимостями, которые определены выше
			var container = builder.Build();

			// установка сопоставителя зависимостей
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			return container;
		}
	}
}