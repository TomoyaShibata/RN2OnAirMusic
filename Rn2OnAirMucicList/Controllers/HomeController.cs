using Rn2OnAirMucicList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rn2OnAirMucicList.Controllers {
	public class HomeController : Controller {
		//
		// GET: /Home/
		[HttpGet]
		public ActionResult Index() {
			var model = new RN2Feed();
			model.GetContext();
			return View();
		}

		[HttpGet]
		[OutputCache(Location=System.Web.UI.OutputCacheLocation.None)]
		public ActionResult Json() {
			return Request.IsAjaxRequest() ? Json() : new EmptyResult();
		}
	}
}
