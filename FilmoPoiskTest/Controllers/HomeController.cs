using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FilmoPoiskTest.Utils;
using System.IO;
using System.Drawing.Imaging;

namespace FilmoPoiskTest.Controllers
{
	[Authorize]
	[CinemaException]
	public class HomeController : Controller
	{
		const int PageSize = 5;

		private readonly Model.ICinemaService m_Rep;

		public HomeController(Model.ICinemaService _Rep)
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
		public async Task<ActionResult> GetImage( int Id )
		{
			var ret = await m_Rep.GetById(Id);

			using (MemoryStream ms = new MemoryStream())
			{
				ret.Poster.Save(ms, ImageFormat.Png);

				var file = File(ms.ToArray(), "image/png");

				return file;
			}			
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

		public ActionResult Create()
		{
			return View( new Model.CinemaViewModels() );
		}

		[HttpPost]
		public async Task<ActionResult> Create(Model.CinemaViewModels model, HttpPostedFileBase image)
		{
			if (ModelState.IsValid)
			{
				var ret = AutoMapper.Mapper.Map<Model.CinemaViewModelsWithPoster>(model);

				if (image != null)
				{
					ret.Poster = new System.Drawing.Bitmap(image.InputStream);
				}

				if (model != null)
					await m_Rep.CreateAsync(User?.Identity?.Name, ret);
			}

			return RedirectToAction("Index");
		}

		public ActionResult NotEdit()
		{
			return View();
		}

		public async Task<ActionResult> Edit(int? Id)
		{
			if (Id == null)
				return RedirectToAction("Index");

			var ret = await m_Rep.GetById(Id ?? 0);

			if (ret.User != User?.Identity?.Name)
				return RedirectToAction("NotEdit");

			return View(ret);
		}

		[HttpPost]
		public async Task<ActionResult> Edit(Model.CinemaViewModelsWithPoster model, HttpPostedFileBase image)
		{
			if (ModelState.IsValid)
			{
				if (image != null)
				{
					model.Poster = new System.Drawing.Bitmap(image.InputStream);
				}
				else
				{
					var origin = await m_Rep.GetById(model.Id);

					model.Poster = origin.Poster;
				}

				model.User = User?.Identity?.Name;

				if (model != null)
					await m_Rep.EditAsync(User?.Identity?.Name, model);
			}

			return RedirectToAction("Index");
		}

	}
}