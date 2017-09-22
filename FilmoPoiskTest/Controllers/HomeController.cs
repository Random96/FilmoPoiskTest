using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FilmoPoiskTest.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		const int PageSize = 5;

		private readonly Models.ICinemaService m_Rep;

		public HomeController(Models.ICinemaService _Rep)
		{
			m_Rep = _Rep;
		}

		[AllowAnonymous]
		public async Task<ActionResult> Index(int id = 0, int Direction = 1 )
		{
			var ret = await m_Rep.GetListAsync(id, Direction, PageSize);

			return View(ret);
		}


		[AllowAnonymous]
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[AllowAnonymous]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}