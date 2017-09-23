using System;
using System.Web.Mvc;
using NLog;

namespace FilmoPoiskTest.Utils
{
	public class CinemaExceptionAttribute : FilterAttribute, IExceptionFilter
	{
		private static readonly ILogger Logger = LogManager.GetLogger("UnhandledException");

		public void OnException(ExceptionContext filterContext)
		{
			Logger.Error(filterContext.Exception, filterContext.Exception.Message);
		}
	}
}