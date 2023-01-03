using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
    public class _DashboardChartPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = 70;
            ViewBag.v2 = 55;

            return View();
        }
    }
}
