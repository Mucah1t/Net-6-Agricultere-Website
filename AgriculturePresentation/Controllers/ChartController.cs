using AgricultureUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductChart()
        {
            List<ProductClass> productClasses= new List<ProductClass>();
            productClasses.Add(new ProductClass()
            {
                productName="Wheat",
                productValue=580
                
            });
            productClasses.Add(new ProductClass
            {
                productName = "Rice",
                productValue = 480
            });
            productClasses.Add(new ProductClass
            {
                productName = "Barley",
                productValue = 250
            });
            productClasses.Add(new ProductClass
            {
                productName = "Tomato",
                productValue = 960
            });
            return Json(new {jsonlist=productClasses}); //json is the method used to transfer data to graph
        }
    }
}
