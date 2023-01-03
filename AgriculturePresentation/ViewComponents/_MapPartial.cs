using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _MapPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext agContenx= new AgricultureContext();
			var values = agContenx.Adresses.Select(x => x.Location).FirstOrDefault();
			ViewBag.v = values;
			return View();
		}
	}
}
